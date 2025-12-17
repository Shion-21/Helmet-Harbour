using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Helmet_Harbour_MK2
{
    public partial class Form5 : Form
    {
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;
        public Form5()
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            InitializeComponent();
        }
        string generatedpasskey;
        private void Form5_Load(object sender, EventArgs e)
        {
            generatedpasskey = GenerateResetKey();
            Passkeytxtbox.Text = generatedpasskey;
        }
        private string GenerateResetKey(int length = 32)
        {
            byte[] data = new byte[length];
            RandomNumberGenerator.Fill(data);
            return BitConverter.ToString(data).Replace("-", "").Substring(0, length);
        }
        private void PassKeyToFile(string key)
        {
            using (SaveFileDialog Passkey = new SaveFileDialog())
            {
                Passkey.Filter = "Text File|*.txt";
                Passkey.Title = "Reset Key";
                Passkey.FileName = "ResetKey.txt";

                if (Passkey.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(Passkey.FileName, generatedpasskey);
                    MessageBox.Show("Saved to:\n" + Passkey.FileName);
                }
            }
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            PassKeyToFile(Passkeytxtbox.Text);
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "UPDATE helmetharbour.`key` SET `Reset Key` = @Key WHERE `idkey` = 1 ";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@Key", HashKey(generatedpasskey));
                    command.ExecuteNonQuery();
                }
            }
            this.Close();
        }
        private string HashKey(string Key)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Key));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
