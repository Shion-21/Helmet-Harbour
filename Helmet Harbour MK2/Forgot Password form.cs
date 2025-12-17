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
    public partial class Form4 : Form
    {
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;
        public Form4()
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (Pass_txtbox.Text.Equals(""))
                {
                    Pass_bullet.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (!IsPasswordValid(Pass_txtbox.Text))
                {
                    Pass_bullet.ForeColor = System.Drawing.Color.Red;                    
                    return;
                }
                if (!Pass_txtbox.Text.Equals(RePass_txtbox.Text))
                {
                    RePass_bullet.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {
                    string query = "UPDATE helmetharbour.`accounts` SET `Password` = @Password WHERE `Access` = 'RootAdmin'";
                    mySqlConnection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        command.Parameters.AddWithValue("@Password", HashPassword(Pass_txtbox.Text));
                        command.ExecuteNonQuery();
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Account Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsPasswordValid(string password)
        {
            if (password.Length < 8)
            {
                MessageBox.Show("Too short");
                return false;
            }
            bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else if (!char.IsLetterOrDigit(c)) hasSpecial = true;

            }
            if (!hasUpper) MessageBox.Show("Missing uppercase");
            if (!hasLower) MessageBox.Show("Missing lowercase");
            if (!hasDigit) MessageBox.Show("Missing digit");
            if (!hasSpecial) MessageBox.Show("Missing special character");
            return hasUpper && hasLower && hasDigit && hasSpecial;
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
