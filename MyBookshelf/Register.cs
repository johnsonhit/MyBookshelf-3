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
    public partial class Register : Form
    {
        readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security = True";
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        public Register()
        {
            InitializeComponent();
        }

        //Rejestracja

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            LoginTXT.Text = LoginTXT.Text.Trim();
            PasswordTXT.Text = PasswordTXT.Text.Trim();
            EmailTXT.Text = EmailTXT.Text.Trim();
            FNameTXT.Text = FNameTXT.Text.Trim();
            SNameTXT.Text = SNameTXT.Text.Trim();
            Regex regexLogin = new Regex(@"^[A-Za-z0-9]{4,20}$");
            Regex regexPwd = new Regex(@"^[\w\*\/\\\?\:\.\^\+\=]{5,20}$");
            Regex regexEmail = new Regex(@"^[\w]{1,30}@[\w]{1,10}\.[\w]{1,8}$");
            if (LoginTXT.Text == "" || PasswordTXT.Text == "" || EmailTXT.Text == "" || !regexLogin.IsMatch(LoginTXT.Text) || !regexPwd.IsMatch(PasswordTXT.Text) || !regexEmail.IsMatch(EmailTXT.Text))
            {
                MessageBox.Show("Błąd");
                return;
            }

            sqlConnection = new SqlConnection(connectionString);
            string sql = "SELECT COUNT(Login) FROM Users WHERE Login=@log";
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@log", LoginTXT.Text);

            sqlConnection.Open();
            string tempLog = sqlCommand.ExecuteScalar().ToString();

            sql = "SELECT COUNT(Email) FROM Users WHERE Email=@email";
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@email", EmailTXT.Text);
            string tempEmail = sqlCommand.ExecuteScalar().ToString();

            if (tempLog != "0")
            {
                MessageBox.Show("Nazwa użytkownika zajęta");
                sqlConnection.Dispose();
                return;
            }
            if (tempEmail != "0")
            {
                MessageBox.Show("E-mail zajęty");
            }


            //Hashowanie hasła
            Hash hash = new Hash();
            var salt = hash.PasswordSalt;
            var pass = hash.EncodePassword(PasswordTXT.Text, salt);

            sql = "INSERT INTO Users (Login,Password,Salt,Email,FName,SName) VALUES (@log,@pwd,@slt,@email,@fname,@sname)";
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@log", LoginTXT.Text);
            sqlCommand.Parameters.AddWithValue("@pwd", pass.ToString());
            sqlCommand.Parameters.AddWithValue("@slt", salt.ToString());
            sqlCommand.Parameters.AddWithValue("@email", EmailTXT.Text);
            sqlCommand.Parameters.AddWithValue("@fname", FNameTXT.Text);
            sqlCommand.Parameters.AddWithValue("@sname", SNameTXT.Text);


            sqlCommand.ExecuteNonQuery();

            sqlConnection.Dispose();

            this.Hide();
            Login login = new Login();
            login.label3.Visible = true;
            login.ShowDialog();
            login.Dispose();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Dispose();
            this.Close();
        }


        private void FindEnter(object sender, EventArgs e)
        {
            var textbox = sender as TextBox;
            var parent = textbox.Parent;
            
            foreach (Control item in parent.Controls)
            {
                if (item is Label)
                {
                    item.Visible = false;
                    return;
                }
            }
        }

        private void FindLeave(object sender, EventArgs e)
        {
            var textbox = sender as TextBox;
            var parent = textbox.Parent;

            if (textbox.Text == "" || textbox.Text == null)
            {
                foreach (Control item in parent.Controls)
                {
                    if (item is Label)
                    {
                        item.Visible = true;
                        return;
                    }
                }
            }
        }

        private void LoginPanel_MouseClick(object sender, MouseEventArgs e)
        {
            var panel = sender as Panel;
            foreach (Control item in panel.Controls)
            {
                if (item is Panel)
                {
                    foreach (Control control in item.Controls)
                    {
                        if (control is TextBox)
                        {
                            FindLeave(control, new EventArgs());
                        }
                    }
                }
            }
        }

        private void OnClick(object sender, MouseEventArgs e)
        {
            var textbox = sender as TextBox;
            var parent = textbox.Parent;

            foreach (Control item in parent.Controls)
            {
                if (item is Label)
                {
                    item.Visible = false;
                    return;
                }
            }
        }

    }
}
