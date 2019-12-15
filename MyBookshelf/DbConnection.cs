using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyBookshelf
{
    class dbConnection
    {
        readonly static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security = True";
        public static List<object> CreateAdapter(List<string> listDeleted, DataTable dt)
        {
            List<object> list = new List<object>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
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
                        sqlConnection.Close();
                    }
                }
            }
            list.Add(listDeleted);
            list.Add(dt);
            return list;
        }

        public static string UpdateCounter(string login)
        {
            if (login != "admin")
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string sql = "SELECT COUNT(Book) FROM Books WHERE Login=@log";
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        sqlCommand.Parameters.Clear();
                        sqlCommand.Parameters.AddWithValue("@log", login);
                        string number = "Książki     " + sqlCommand.ExecuteScalar().ToString();
                        sqlConnection.Close();
                        return number;
                    }
                }
            }
            else
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string sql = "SELECT COUNT(Book) FROM Books";
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        string number = "Książki     " + sqlCommand.ExecuteScalar().ToString();
                        sqlConnection.Close();
                        return number;
                    }
                }
            }
        }

        public static DataTable FillTable(string login, DataTable dt)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                
                sqlConnection.Open();
                string sql;
                if (login == "admin")
                {
                    sql = "SELECT ID,Login,Book,Author,TimeToReturn,Library FROM Books";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                        {
                            dt.Clear();
                            adapter.Fill(dt);
                        }
                    }
                }
                else
                {
                    sql = "SELECT ID,Login,Book, Author, TimeToReturn, Library FROM Books WHERE Login=@log";
                    using (SqlCommand sqlCommand = new SqlCommand(sql,sqlConnection))
                    {
                        sqlCommand.Parameters.Clear();
                        sqlCommand.Parameters.AddWithValue("@log", login);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                        {
                            dt.Clear();
                            adapter.Fill(dt);
                        }
                    }

                }
                sqlConnection.Close();

                return dt;
            }
        }

        public static int ReturnIndex(string CellValue)
        {
            int index;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sql = "SELECT COUNT(ID) FROM Libraries WHERE Name=@name";
                using (SqlCommand sqlCommand = new SqlCommand(sql,sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@name", CellValue);
                    sqlConnection.Open();
                    index = (int)sqlCommand.ExecuteScalar();
                    sqlConnection.Close();
                    
                }
            }
            return index;
        }

        public static DataTable ComboBoxQuery(DataGridView MainView)
        {
            DataTable table = new DataTable();
            foreach (DataGridViewRow row in MainView.Rows)
            {
                table = new DataTable();

                string sql = "SELECT Id, Name FROM Libraries";
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                        {
                            adapter.Fill(table);
                        }
                    }
                }
            }
            return table;
        }

    }
}
