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
    public partial class Login : Form
    {
        readonly Register reg = new Register();
        readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security = True";
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        int tries = 5;
        bool isValid = false;
        string FName;
        string SName;
        public Login()
        {
            InitializeComponent();
        }

        //Logowanie
        private void LoginButton_Click(object sender, EventArgs e)
        {
            
            /*if (tries == 0)
            {
                Login.ActiveForm.Close();
            }
            LoginTXT.Text = LoginTXT.Text.Trim();
            PasswordTXT.Text = PasswordTXT.Text.Trim();
            Regex regexLogin = new Regex(@"^[A-Za-z0-9]{4,20}$");
            Regex regexPwd = new Regex(@"^[\w\*\/\\\?\:\.\^\+\=]{5,20}$");
            if (LoginTXT.Text == "" || PasswordTXT.Text == "" || !regexLogin.IsMatch(LoginTXT.Text) || !regexPwd.IsMatch(PasswordTXT.Text))
            {
                tries--;
                MessageBox.Show(String.Format("Błędna nazwa użytkownika lub hasło.\n Pozostało prób: {0}", tries));
                return;
            }
            Hash hash = new Hash();

            sqlConnection = new SqlConnection(connectionString);
            string sql = "SELECT Password, Salt, FName, SName FROM Users WHERE Login=@log";
            sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@log", LoginTXT.Text);

            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            if (!dataReader.HasRows)
            {
                tries--;
                MessageBox.Show(String.Format("Błędna nazwa użytkownika lub hasło.\n Pozostało prób: {0}", tries));
                sqlConnection.Close();
                return;
            }

            while (dataReader.Read())
            {
                FName = dataReader[2].ToString();
                SName = dataReader[3].ToString();
                var tempSalt = dataReader[1];
                if (hash.EncodePassword(PasswordTXT.Text, tempSalt.ToString()) == dataReader[0].ToString())
                {
                    tries = 5;
                    isValid = true;
                }
                else
                {
                    tries--;
                    MessageBox.Show(String.Format("Błędna nazwa użytkownika lub hasło.\nPozostało prób: {0}", tries));
                    sqlConnection.Close();
                    return;
                }
            }

            sqlCommand.Dispose();
            sqlConnection.Dispose();

            if (isValid)
            {*/
                Main main = new Main(LoginTXT.Text);
                main.NameLabel.Text = FName + "\n" + SName;
                this.Hide();
                main.ShowDialog();
                this.Close();
           //}
        }


        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            reg.ShowDialog();
            this.Close();
        }


        private void PasswordTXT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginButton.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void LoginTXT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginButton.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
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
