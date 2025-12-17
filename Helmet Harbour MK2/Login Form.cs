using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Helmet_Harbour_MK2
{
    public partial class LoginForm : Form
    {
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;
        public LoginForm()
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            InitializeComponent();
        }

        public string Username { get; set; }
        private void NameTextbox_clickevent(object sender, EventArgs e)
        {
            if (NameTextbox.Text.Equals("Username:")) NameTextbox.Text = "";
            NameTextbox.ForeColor = System.Drawing.Color.Black;
        }
        private void PassTextbox_clickevent(object sender, EventArgs e)
        {
            if (PassTextbox.Text.Equals("Password:")) PassTextbox.Text = "";
            PassTextbox.UseSystemPasswordChar = true;
            PassTextbox.ForeColor = System.Drawing.Color.Black;
        }
        private void checktextbox(object sender, EventArgs e)
        {
            if (PassTextbox.Text.Equals(""))
            {
                PassTextbox.Text = "Password:";
                PassTextbox.ForeColor = SystemColors.WindowFrame;
                PassTextbox.UseSystemPasswordChar = false;
            }
            if (NameTextbox.Text.Equals(""))
            {
                NameTextbox.Text = "Username:";
                NameTextbox.ForeColor = SystemColors.WindowFrame;
            }
        }
        private void invalidsymbol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ' ' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {
                    string query = "SELECT `Password` FROM helmetharbour.`accounts` WHERE `Username` = @Username";
                    mySqlConnection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        command.Parameters.AddWithValue("@Username", NameTextbox.Text.ToLower());
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string PasswordFromDB = reader["Password"].ToString();
                                if (string.IsNullOrEmpty(PasswordFromDB)) return;
                                string PasswordInput = HashPassword(PassTextbox.Text);
                                if (PasswordInput.Equals(PasswordFromDB))
                                {
                                    Username = NameTextbox.Text.ToLower();
                                    this.DialogResult = DialogResult.OK;

                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect Username or Password");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Username or Password");
                            }
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Incorrect Username or Password");
            }
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        private void Forgotbtn_Click(object sender, EventArgs e)
        {
            Form3 ForgotpassForm = new Form3();
            ForgotpassForm.ShowDialog();
        }

        private void forgotbtn_MouseHover(object sender, EventArgs e)
        {
            forgotbtn.ForeColor = Color.Blue;
        }

        private void forgotbtn_MouseLeave(object sender, EventArgs e)
        {
            forgotbtn.ForeColor = SystemColors.ControlText;
        }

        private void LoginClose_MouseHover(object sender, EventArgs e)
        {
            LoginFClose_Btn.ForeColor = Color.Red;
        }

        private void LoginClose_MouseLeave(object sender, EventArgs e)
        {
            LoginFClose_Btn.ForeColor = Color.Black;
        }

        private void LoginFMinimize_Btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void LoginFMinimize_MouseHover(object sender, EventArgs e)
        {
            LoginMinimizebtn.ForeColor = Color.Blue;
        }

        private void LoginFMinimize_MouseLeave(object sender, EventArgs e)
        {
            LoginMinimizebtn.ForeColor = Color.Black;
        }

        private void LoginFClose_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
