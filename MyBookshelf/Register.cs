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
        public Register()
        {
            InitializeComponent();
        }

        //Rejestracja

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string tempLog;
            string tempEmail;
            LoginTXT.Text = LoginTXT.Text.Trim();
            PasswordTXT.Text = PasswordTXT.Text.Trim();
            EmailTXT.Text = EmailTXT.Text.Trim();
            FNameTXT.Text = FNameTXT.Text.Trim();
            SNameTXT.Text = SNameTXT.Text.Trim();
            Regex regexLogin = new Regex(@"^[A-Za-z0-9]{4,20}$");
            Regex regexPwd = new Regex(@"^[\w\*\/\\\?\:\.\^\+\=]{5,20}$");
            //Regex regexEmail = new Regex(@"^[\w@]{1,50}$");


            int error = 0;
            if (LoginTXT.Text == "" || !regexLogin.IsMatch(LoginTXT.Text))
            {
                labelLoginBottom.BackColor = Color.Red;
                error++;
            }
            else
            {
                labelLoginBottom.BackColor = Color.DarkGray;
            }
            if (PasswordTXT.Text == "" || !regexPwd.IsMatch(PasswordTXT.Text))
            {
                labelPassBottom.BackColor = Color.Red;
                error++;
            }
            else
            {
                labelPassBottom.BackColor = Color.DarkGray;
            }
            if (FNameTXT.Text == "")
            {
                labelFnameBottom.BackColor = Color.Red;
                error++;
            }
            else
            {
                labelFnameBottom.BackColor = Color.DarkGray;
            }
            if (SNameTXT.Text == "")
            {
                labelSnameBottom.BackColor = Color.Red;
                error++;
            }
            else
            {
                labelSnameBottom.BackColor = Color.DarkGray;
            }
            if (EmailTXT.Text == "")
            {
                labelEmailBottom.BackColor = Color.Red;
                error++;
            }
            else
            {
                labelEmailBottom.BackColor = Color.DarkGray;
            }

            if (error > 0)
            {
                return;
            }


            //Operacje na bazie danych
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //sqlConnection = new SqlConnection(connectionString);
                string sql = "SELECT COUNT(Login) FROM Users WHERE Login=@log";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@log", LoginTXT.Text);

                    connection.Open();
                    tempLog = command.ExecuteScalar().ToString();
                }

                sql = "SELECT COUNT(Email) FROM Users WHERE Email=@email";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@email", EmailTXT.Text);
                    tempEmail = command.ExecuteScalar().ToString();

                    if (tempLog != "0")
                    {
                        MessageBox.Show("Nazwa użytkownika zajęta");
                        connection.Close();
                        connection.Dispose();
                        return;
                    }
                    if (tempEmail != "0")
                    {
                        MessageBox.Show("E-mail zajęty");
                        return;
                    }
                }

                //Hashowanie hasła
                //Hash hash = new Hash();
                var salt = Hash.PasswordSalt;
                var pass = Hash.EncodePassword(PasswordTXT.Text, salt);

                sql = "INSERT INTO Users (Login,Password,Salt,Email,FName,SName) VALUES (@log,@pwd,@slt,@email,@fname,@sname)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@log", LoginTXT.Text);
                    command.Parameters.AddWithValue("@pwd", pass.ToString());
                    command.Parameters.AddWithValue("@slt", salt.ToString());
                    command.Parameters.AddWithValue("@email", EmailTXT.Text);
                    command.Parameters.AddWithValue("@fname", FNameTXT.Text);
                    command.Parameters.AddWithValue("@sname", SNameTXT.Text);

                    command.ExecuteNonQuery();
                }
            }
            


            Hide();
            using (Login login = new Login())
            {
                login.LoginTXT.Text = LoginTXT.Text;
                login.PasswordTXT.Text = PasswordTXT.Text;
                login.labelLogin.Visible = false;
                login.LabelPass.Visible = false;
                login.ShowDialog();
                Close();
            }

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Hide();
            using (Login login = new Login())
            {
                login.ShowDialog();
                Dispose();
                Close();
            }
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
            panel.Focus();
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

        private void Register_Load(object sender, EventArgs e)
        {
            panelRegister.Select();
        }
    }
}
