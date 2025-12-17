using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace Helmet_Harbour_MK2
{
    public partial class Form3 : Form
    {
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;
        public Form3()
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Return_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmbtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {
                    string query = "SELECT `Reset Key` FROM helmetharbour.`key` WHERE `idkey` = 1";
                    mySqlConnection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string KeyFromDB = reader["Reset Key"].ToString();
                                string KeyInput = HashPassword(Key_txtbox.Text);
                                if (KeyInput.Equals(KeyFromDB))
                                {
                                    Form4 NewPass = new Form4();
                                    NewPass.ShowDialog();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect Key");
                                }
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
    }
}
