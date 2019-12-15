using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MyBookshelf
{
    class dbConnection
    {
        readonly static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security = True";
        public static DataTable CreateAdapter(List<string> listDeleted, DataTable dt, SqlConnection sqlConnection)
        {
            sqlConnection.Open();
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

                }
            }
            sqlConnection.Close();
            return dt;
        }

        public static string UpdateCounter(SqlConnection sqlConnection, string login)
        {
            if (login != "admin")
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
            else
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
}
