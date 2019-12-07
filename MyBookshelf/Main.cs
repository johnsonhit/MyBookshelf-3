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
        private int rowIndex; //Indeks wiersza edytowanego
        private bool isEdit = false; //Czy włączona jest edycja wiersza
        private bool isAdded = false; //Czy jest dodany nowy pusty wiersz
        readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security = True";
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private DataTable dt = new DataTable();
        private List<string> listDeleted = new List<string>(); //ID usuniętych wierszy

        readonly string login;
        public Main(string login)
        {
            this.login = login;
            InitializeComponent();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            using (Login login = new Login())
            {
                Hide();
                login.ShowDialog();
                Close();
            }
        }

        private void BooksButton_Click(object sender, EventArgs e)
        {
            AddButton.Enabled = true;
            SaveButton.Enabled = true;
            RightPanelLibraries.Visible = false;
            RightPanel.Visible = true;
            sqlConnection = new SqlConnection(connectionString);
            string sql;
            if (login == "admin")
            {
                sql = "SELECT ID,Login,Book,Author,TimeToReturn,Library FROM Books";
                sqlCommand = new SqlCommand(sql, sqlConnection);
            }
            else
            {
                sql = "SELECT ID,Login,Book, Author, TimeToReturn, Library FROM Books WHERE Login=@log";
                sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@log", login);
            }

            sqlConnection.Open();
            dt.Clear();



            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            {
                adapter.Fill(dt);
                MainView.DataSource = dt;

            }
            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dr["Login"] = login;
                dr["Book"] = DBNull.Value;
                dr["Author"] = DBNull.Value;
                dr["TimeToReturn"] = DBNull.Value;
                dr["Library"] = DBNull.Value;
                dt.Rows.Add(dr);
                MainView.ReadOnly = true;
                isAdded = true;
            }
            sqlConnection.Close();
            var col = MainView.Columns;
            col[0].Visible = false;
            col[1].Visible = false;
            col[2].HeaderText = "Tytuł";
            col[3].HeaderText = "Autor";
            col[4].HeaderText = "Termin zwrotu";
            col[4].Name = "ReturnTime";
            col[5].Name = "Library";
            col[5].HeaderText = "Biblioteka";
            col[5].Visible = false;
            col[3].DefaultCellStyle.BackColor = Color.Gainsboro;
            col[5].DefaultCellStyle.BackColor = Color.Gainsboro;
            col[3].DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            col[5].DefaultCellStyle.SelectionBackColor = Color.Gainsboro;


            if (MainView.Columns.Count == 6)
            {
                sqlCommand = new SqlCommand("SELECT L.Id,L.Name,B.Name FROM Libraries as L, Books as B", sqlConnection);
                DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                comboBoxColumn.HeaderText = "Biblioteka";
                MainView.Columns.Add(comboBoxColumn);
                DataTable table = new DataTable();
                foreach (DataGridViewRow row in MainView.Rows)
                {
                    table = new DataTable();


                    sql = "SELECT Id, Name FROM Libraries";
                    using (sqlConnection = new SqlConnection(connectionString))
                    {
                        using (sqlCommand = new SqlCommand(sql, sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.Text;
                            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                            {
                                adapter.Fill(table);
                            }
                        }
                    }
                }
                comboBoxColumn.ValueMember = "Name";
                comboBoxColumn.DisplayMember = "Name";
                comboBoxColumn.DataSource = table;

                foreach (DataGridViewRow row in MainView.Rows)
                {
                    DataGridViewComboBoxCell comboBoxCell = row.Cells[6] as DataGridViewComboBoxCell;
                    try
                    {
                        comboBoxCell.Value = row.Cells[5].Value.ToString();
                    }
                    catch (Exception)
                    {

                    }
                   
                }

                var graphics = CreateGraphics();

                if (table.Rows.Count > 0)
                {
                    comboBoxColumn.DropDownWidth = (from width in
           (from DataRow item in table.Rows
            select Convert.ToInt32(graphics.MeasureString(item["Name"].ToString(), Font).Width))
                                                    select width).Max();
                }

            }



            if (MainView.Columns.Count == 7)
            {
                DataGridViewButtonColumn EditColumn = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    Text = "Edytuj",
                    FlatStyle = FlatStyle.Flat,
                    UseColumnTextForButtonValue = true,
                    HeaderText = "",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Width = 55
                };
                MainView.Columns.Add(EditColumn);

                DataGridViewButtonColumn DeleteColumn = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    Text = "Usuń",
                    FlatStyle = FlatStyle.Flat,
                    UseColumnTextForButtonValue = true,
                    HeaderText = "",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Width = 55
                };
                MainView.Columns.Add(DeleteColumn);
            }

            foreach (DataGridViewRow row in LibrariesView.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    row.Cells[i].Style.BackColor = default;
                }
            }

            CheckDate();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet.Libraries' table. You can move, or remove it, as needed.
            this.librariesTableAdapter.Fill(this.databaseDataSet.Libraries);

            string sql;
            MainView.AllowUserToAddRows = false;
            sqlConnection = new SqlConnection(connectionString);

            if (login == "admin")
            {
                SaveButton.Visible = true;
                AddButton.Visible = true;
                sql = "SELECT COUNT(*) FROM Books";
                sqlCommand = new SqlCommand(sql, sqlConnection);
            }
            else
            {
                SaveButton.Visible = true;
                AddButton.Visible = true;
                sql = "SELECT COUNT(*) FROM Books WHERE Login=@log";
                sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@log", login);
            }

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

        //----------------------------------- Usuwanie i Edytowanie -----------------------------------

        private void MainView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            //Usuwanie wiersza
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.ColumnIndex == 8 && e.RowIndex < senderGrid.Rows.Count)
            {
                try
                {
                    if (e.RowIndex == rowIndex)
                    {
                        isEdit = false;
                    }

                    DataRow dr = dt.Rows[e.RowIndex];
                    if (senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
                    {
                        listDeleted.Add(dr[0].ToString());
                    }

                    senderGrid.Rows.RemoveAt(e.RowIndex);
                    dt.Rows.Remove(dr);
                    senderGrid.ReadOnly = true;
                    //dt.AcceptChanges();
                    BooksButton.Text = "Książki     " + dt.Rows.Count.ToString();
                    CheckDate();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                    //MessageBox.Show("BŁĄD");
                    isAdded = false;
                    isEdit = false;
                    return;
                }
            }

            //Edytowanie wiersza
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.ColumnIndex == 7 && isEdit == false)
            {
                senderGrid.ReadOnly = false;
                isEdit = true;
                rowIndex = e.RowIndex;
                for (int i = 0; i <= 5; i++)
                {
                    senderGrid.Rows[e.RowIndex].Cells[i].Style.SelectionBackColor = Color.LimeGreen;
                    senderGrid.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.LightGreen;
                }
            }

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && e.RowIndex >= 0 && e.ColumnIndex == 6 && isEdit == true)
            {
                senderGrid.Rows[rowIndex].Cells[6].Value = senderGrid.Rows[rowIndex].Cells[5].Value;
            }
        }

        //Dodawanie nowego wiersza
        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (isEdit || isAdded)
                {
                    if (dt.Rows.Count != 0)
                    {
                        //Czy wprowadzona data nie jest wcześniejsza od obecnej
                        DateTime date = (DateTime)MainView.Rows[rowIndex].Cells["ReturnTime"].Value;
                        if (date.Date < DateTime.Today.Date)
                        {
                            MessageBox.Show("Wprowadź prawidłową datę");
                            return;
                        }
                        CheckDate();

                        for (int i = 0; i <= 6; i++)
                        {
                            MainView.Rows[rowIndex].Cells[i].Style.SelectionBackColor = default;
                            MainView.Rows[rowIndex].Cells[i].Style.BackColor = default;
                        }
                    }

                    isEdit = false;
                    isAdded = true;
                    MainView.ReadOnly = true;

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
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                MessageBox.Show("Żadne pole nie może pozostać puste");
            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            try
            {
                if (!isAdded && !isEdit)
                {
                    using (sqlConnection = new SqlConnection(connectionString))
                    {
                        //Update bazy danych
                        sqlConnection.Open();
                        //Adapter do porównania bazy danych z DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter())
                        {
                            adapter.SelectCommand = new SqlCommand("SELECT * FROM Books", sqlConnection);
                            using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                            {
                                adapter.Update(dt);

                                //Usuwanie z bazy danych
                                if (listDeleted.Count != 0)
                                {
                                    foreach (var index in listDeleted)
                                    {
                                        adapter.DeleteCommand = new SqlCommand("DELETE FROM Books WHERE Id=@id", sqlConnection);
                                        adapter.DeleteCommand.Parameters.Clear();
                                        adapter.DeleteCommand.Parameters.AddWithValue("@id", index);
                                        adapter.DeleteCommand.ExecuteNonQuery();
                                    }
                                    listDeleted.Clear();
                                }

                                MainView.DataSource = dt;
                                sqlConnection.Close();
                            }
                        }

                        //Update licznika książek
                        if (login != "admin")
                        {
                            string sql = "SELECT COUNT(Book) FROM Books WHERE Login=@log";
                            sqlConnection.Open();
                            sqlCommand = new SqlCommand(sql, sqlConnection);

                            sqlCommand.Parameters.Clear();
                            sqlCommand.Parameters.AddWithValue("@log", login);
                            BooksButton.Text = "Książki     " + sqlCommand.ExecuteScalar().ToString();
                            sqlConnection.Close();
                        }
                        else
                        {
                            string sql = "SELECT COUNT(Book) FROM Books";
                            sqlConnection.Open();
                            sqlCommand = new SqlCommand(sql, sqlConnection);

                            BooksButton.Text = "Książki     " + sqlCommand.ExecuteScalar().ToString();
                            sqlConnection.Close();
                        }

                        MainView.AllowUserToAddRows = false;
                        MainView.DataSource = dt;
                        CheckDate();
                        LibrariesButton.Enabled = true;
                    }
                    MainView.AllowUserToAddRows = false;
                }


            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                MainView.AllowUserToAddRows = false;
                MessageBox.Show("Żadne pole nie może pozostać puste");
            }
        }

        private void CheckDate()
        {

            foreach (DataRow item in dt.Rows)
            {
                try
                {
                    DateTime date = (DateTime)item[4];
                    DateTime start = DateTime.Now.Date;
                    if ((date - start).Days <= 7)
                    {
                        MainView.Rows[dt.Rows.IndexOf(item)].Cells["ReturnTime"].Style.BackColor = Color.Red;
                        MainView.Rows[dt.Rows.IndexOf(item)].Cells["ReturnTime"].Style.SelectionBackColor = Color.Red;
                    }
                }
                catch (Exception)
                {

                }

            }
        }

        private void MainView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (!DateTime.TryParse(senderGrid.Rows[e.RowIndex].Cells["ReturnTime"].Value.ToString(), out _))
            {
                //MessageBox.Show("Data powinna być w formacie dd.mm.rrrr");
                //senderGrid.Rows[e.RowIndex].Cells[6].Value = senderGrid.Rows[e.RowIndex].Cells[6].Tag;
                senderGrid.Rows[e.RowIndex].Cells[4].Value = DateTime.Today.Date.ToString();
            }
        }

        private void MainView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !DateTime.TryParse(senderGrid.Rows[e.RowIndex].Cells["ReturnTime"].Value.ToString(), out _))
            {
                //MessageBox.Show("Data powinna być w formacie dd/mm/rrrr");
                return;
            }

            if (e.RowIndex != rowIndex && e.RowIndex >= 0 && e.ColumnIndex >= 0 && isEdit == true)
            {
                try
                {
                    senderGrid.Rows[rowIndex].Cells[5].Value = senderGrid.Rows[rowIndex].Cells[6].Value.ToString();
                    DateTime date = (DateTime)senderGrid.Rows[rowIndex].Cells["ReturnTime"].Value;
                    if (date.Date < DateTime.Today.Date)
                    {
                        senderGrid.Rows[rowIndex].Cells["ReturnTime"].Selected = true;
                        MessageBox.Show("Wprowadź prawidłową datę");
                        return;
                    }
                    for (int i = 0; i <= 6; i++)
                    {
                        if (senderGrid.Rows[rowIndex].Cells[i].Value.ToString() == "" && (i == 2 || i == 3 || i == 4 || i == 6))
                        {
                            MessageBox.Show("Żadne pole nie może pozostać puste");
                            return;
                        }
                        senderGrid.Rows[rowIndex].Cells[i].Style.SelectionBackColor = default;
                        senderGrid.Rows[rowIndex].Cells[i].Style.BackColor = default;
                        CheckDate();
                        isEdit = false;
                        isAdded = false;
                        senderGrid.ReadOnly = true;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Żadne pole nie może pozostać puste");
                }
            }
        }

        private void LibrariesButton_Click(object sender, EventArgs e)
        {
            //RightPanel.Visible = false;
            RightPanelLibraries.Visible = true;
            LibrariesView.Columns[0].Visible = false;
            AddButton.Enabled = false;
            SaveButton.Enabled = false;

        }

        private void LibrariesView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < LibrariesView.Columns.Count; i++)
            {
                for (int j = 0; j < LibrariesView.Rows.Count; j++)
                {
                    LibrariesView.Rows[j].Cells[i].Style.BackColor = default;
                }
            }
        }

        private void MainView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (!isEdit)
                {
                    CheckDate();
                }
                else
                {
                    MainView.Rows[rowIndex].Selected = true;
                }
                
            }
            catch (Exception)
            {

                return;
            }
            
        }

        private void MainView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == 6 && e.RowIndex >= 0 && !isEdit && !isAdded)
            {
                try
                {
                    sqlConnection = new SqlConnection(connectionString);
                    string sql = "SELECT ID FROM Libraries WHERE Name=@name";
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@name", senderGrid.Rows[e.RowIndex].Cells[6].Value.ToString());
                    sqlConnection.Open();
                    var index = sqlCommand.ExecuteScalar();
                    sqlConnection.Close();
                    if (index != null)
                    {
                        LibrariesButton_Click(sender, e);
                        for (int i = 0; i < LibrariesView.Rows.Count; i++)
                        {
                            for (int j = 0; j < LibrariesView.Columns.Count; j++)
                            {
                                LibrariesView.Rows[i].Cells[j].Style.BackColor = default;
                            }
                        }
                        for (int i = 0; i < LibrariesView.Columns.Count; i++)
                        {
                            LibrariesView.Rows[(int)index].Cells[i].Style.BackColor = Color.LightGreen;
                        }
                    }


                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
