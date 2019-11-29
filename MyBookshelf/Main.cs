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

namespace MyBookshelf
{
    public partial class Main : Form
    {
        readonly Register reg = new Register();
        readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security = True";
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

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

            string sql = "SELECT COUNT(*) FROM Books WHERE Login=@log";
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@log", login);
            sqlConnection.Open();
            int number = (int)sqlCommand.ExecuteScalar();


            sql = "SELECT Book,Author,TimeToReturn,Library FROM Books WHERE Login=@log";
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@log", login);


            SqlDataReader dataReader = sqlCommand.ExecuteReader();



            while (dataReader.Read())
            {

            }



            sqlConnection.Close();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            login = "admin";
            sqlConnection = new SqlConnection(connectionString);
            string sql = "SELECT COUNT(*) FROM Books WHERE Login=@log";
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@log", login);
            sqlConnection.Open();
            BooksButton.Text = "Książki     " + sqlCommand.ExecuteScalar().ToString();
            sqlConnection.Close();
        }
    }
}
