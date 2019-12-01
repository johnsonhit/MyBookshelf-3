using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace MyBookshelf
{
    public partial class Main : Form
    {
        int rowIndex;
        bool isEdit = false;
        bool isAdded = false;
        readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security = True";
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        DataTable dt = new DataTable();

        string login;
        public Main(string login)
        {
            this.login = login;
            InitializeComponent();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
            login.Dispose();
            this.Close();
        }

        private void BooksButton_Click(object sender, EventArgs e)
        {
            login = "admin";
            sqlConnection = new SqlConnection(connectionString);
            string sql = "SELECT ID,Login,Book,Author,TimeToReturn,Library FROM Books WHERE Login=@log";
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@log", login);
            sqlConnection.Open();
            dt.Clear();
            
            if (MainView.Columns.Count==0)
            {
                DataGridViewButtonColumn DeleteColumn = new DataGridViewButtonColumn();
                DeleteColumn.Name = "Delete";
                DeleteColumn.Text = "Usuń";
                DeleteColumn.FlatStyle = FlatStyle.Flat;
                DeleteColumn.UseColumnTextForButtonValue = true;
                DeleteColumn.HeaderText = "";
                DeleteColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DeleteColumn.Width = 26;
                MainView.Columns.Insert(0, DeleteColumn);

                DataGridViewButtonColumn EditColumn = new DataGridViewButtonColumn();
                EditColumn.Name = "Edit";
                EditColumn.Text = "Edytuj";
                EditColumn.FlatStyle = FlatStyle.Flat;
                EditColumn.UseColumnTextForButtonValue = true;
                EditColumn.HeaderText = "";
                EditColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                EditColumn.Width = 26;
                MainView.Columns.Insert(1, EditColumn);
            }

            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            {

                adapter.Fill(dt);
                MainView.DataSource = dt;
            }
            var col = MainView.Columns;
            col[2].Visible = false;
            col[3].Visible = false;
            col[4].HeaderText = "Tytuł";
            col[5].HeaderText = "Autor";
            col[6].HeaderText = "Termin zwrotu";
            col[6].Name = "ReturnTime";
            col[7].HeaderText = "Biblioteka";
            col[5].DefaultCellStyle.BackColor = Color.Gainsboro;
            col[7].DefaultCellStyle.BackColor = Color.Gainsboro;
            col[5].DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            col[7].DefaultCellStyle.SelectionBackColor = Color.Gainsboro;


            sqlConnection.Close();

            CheckDate();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            MainView.AllowUserToAddRows = false;
            login = "admin";
            sqlConnection = new SqlConnection(connectionString);
            string sql = "SELECT COUNT(*) FROM Books WHERE Login=@log";
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@log", login);
            sqlConnection.Open();
            BooksButton.Text = "Książki     " + sqlCommand.ExecuteScalar().ToString();
            sqlConnection.Close();
            BooksButton_Click(BooksButton, e);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Dispose();
            this.Hide();
            this.Close();
        }

        private void MainView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            //Usuwanie wiersza
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.ColumnIndex == 0 && e.RowIndex < senderGrid.Rows.Count)
            {
                try
                {
                    if (e.RowIndex==rowIndex)
                    {
                        isEdit = false;
                    }
                    DataRow dr = dt.Rows[e.RowIndex];
                    senderGrid.ReadOnly = true;
                    senderGrid.Rows.RemoveAt(e.RowIndex);
                    dt.Rows.Remove(dr);
                }
                catch (Exception)
                {
                    return;
                }
            }

            //Edytowanie wiersza
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.ColumnIndex == 1 && isEdit == false)
            {
                /*                senderGrid.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                                MessageBox.Show(e.RowIndex.ToString());
                                senderGrid.Rows[e.RowIndex].ReadOnly = default;*/
                senderGrid.ReadOnly = false;
                isEdit = true;
                rowIndex = e.RowIndex;
                for (int i = 4; i <= 7; i++)
                {
                    senderGrid.Rows[e.RowIndex].Cells[i].Style.SelectionBackColor = Color.LimeGreen;
                    senderGrid.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.LightGreen;
                }
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (isEdit || isAdded)
                {
                    for (int i = 4; i <= 7; i++)
                    {
                        DateTime date = (DateTime)MainView.Rows[rowIndex].Cells[6].Value;
                        if (date.Date < DateTime.Today.Date)
                        {
                            MessageBox.Show("Wprowadź prawidłową datę");
                            return;
                        }
                        CheckDate();
                        MainView.Rows[rowIndex].Cells[i].Style.SelectionBackColor = default;
                        MainView.Rows[rowIndex].Cells[i].Style.BackColor = default;

                        isEdit = false;
                        isAdded = true;
                        MainView.ReadOnly = true;
                    }
                }
                isAdded = true;
                DataRow dr = dt.NewRow();
                dr["Login"] = login;
                dr["Book"] = DBNull.Value;
                dr["Author"] = DBNull.Value;
                dr["TimeToReturn"] = DBNull.Value;
                dr["Library"] = DBNull.Value;
                dt.Rows.Add(dr);
                MainView.ReadOnly = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Żadne pole nie może pozostać puste");
            }
            //Dodanie nowego wiersza

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (var bulkCopy = new SqlBulkCopy(connectionString))
            {
                try
                {
                    using (sqlConnection = new SqlConnection(connectionString))
                    {
                        MainView.AllowUserToAddRows = true;
                        //Update bazy danych
                        foreach (DataRow item in dt.Rows)
                        {
                            DateTime date = (DateTime)item[4];
                            if (date.Date < DateTime.Today.Date)
                            {
                                MessageBox.Show("Wprowadź prawidłową datę");
                                return;
                            }
                        }
                        sqlConnection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter())
                        {
                            
                            adapter.SelectCommand = new SqlCommand("SELECT * FROM Books", sqlConnection);
                            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                            adapter.Update(dt);
                            MainView.DataSource = dt;
                        }


                        //Update licznika książek
                        string sql = "SELECT COUNT(Book) FROM Books WHERE Login=@log";
                        sqlCommand = new SqlCommand(sql, sqlConnection);
                        sqlCommand.Parameters.Clear();
                        sqlCommand.Parameters.AddWithValue("@log", login);
                        BooksButton.Text = "Książki     " + sqlCommand.ExecuteScalar().ToString();
                        sqlConnection.Close();
                        MainView.AllowUserToAddRows = false;
                    }
                }
                catch (Exception)
                {
                    MainView.AllowUserToAddRows = false;
                    MessageBox.Show("Żadne pole nie może pozostać puste");
                }
            }
        }

        private void MainView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CheckDate()
        {
            foreach (DataRow item in dt.Rows)
            {
                DateTime date = (DateTime)item[4];
                DateTime start = DateTime.Now.Date;
                if ((date - start).Days <= 7)
                {
                    MainView.Rows[dt.Rows.IndexOf(item)].Cells[6].Style.BackColor = Color.Red;
                    MainView.Rows[dt.Rows.IndexOf(item)].Cells[6].Style.SelectionBackColor = Color.Red;
                }
            }
        }

        private void MainView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            DateTime temp;
            if (!DateTime.TryParse(senderGrid.Rows[e.RowIndex].Cells["ReturnTime"].Value.ToString(), out temp))
            {
                MessageBox.Show("Data powinna być w formacie dd.mm.rrrr");
                //senderGrid.Rows[e.RowIndex].Cells[6].Value = senderGrid.Rows[e.RowIndex].Cells[6].Tag;
                senderGrid.Rows[e.RowIndex].Cells[6].Value = DateTime.Today.Date.ToString();
            }
        }

        private void MainView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            DateTime temp;
            if (!DateTime.TryParse(senderGrid.Rows[e.RowIndex].Cells[6].Value.ToString(), out temp))
            {
                //MessageBox.Show("Data powinna być w formacie dd/mm/rrrr");
                return;
            }

            if (e.RowIndex != rowIndex && e.RowIndex >= 0 && isEdit == true)
            {
                try
                {
                    DateTime date = (DateTime)senderGrid.Rows[rowIndex].Cells[6].Value;
                    if (date.Date < DateTime.Today.Date)
                    {
                        MessageBox.Show("Wprowadź prawidłową datę");
                        return;
                    }
                    for (int i = 4; i <= 7; i++)
                    {
                        CheckDate();
                        senderGrid.Rows[rowIndex].Cells[i].Style.SelectionBackColor = default;
                        senderGrid.Rows[rowIndex].Cells[i].Style.BackColor = default;
                        
                        isEdit = false;
                        isAdded = false;
                        senderGrid.ReadOnly = true;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Żadne pole nie może pozostać puste xDDDDDDD");
                }
            }

        }

        private void LibrariesButton_Click(object sender, EventArgs e)
        {

        }
    }
}
