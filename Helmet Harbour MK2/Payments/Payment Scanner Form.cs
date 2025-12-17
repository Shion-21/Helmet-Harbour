using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

namespace Helmet_Harbour_MK2
{
    public partial class PayScanForm : Form
    {
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;
        string RFID, Slot, Status, LoggedUsername;
        public PayScanForm(string Username)
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            InitializeComponent();
            timer1.Enabled = true;
            LoggedUsername = Username;
        }

        private void ScanCheck_Tick(object sender, EventArgs e)
        {

            timer1.Enabled = false;

            string scannedRFID = null;
            string slot = null;
            string status = null;

            using (var conn = new MySqlConnection(conphrase))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("SELECT `RFID scan` FROM `rfid controller` WHERE `idRFID controller` = 1", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        scannedRFID = reader["RFID scan"]?.ToString();
                }

                if (string.IsNullOrWhiteSpace(scannedRFID))
                {
                    timer1.Enabled = true;
                    return;
                }
                using (var cmd = new MySqlCommand("SELECT `Rack Slot` FROM `helmet racks` WHERE `RFID #` = @RFID", conn))
                {
                    cmd.Parameters.AddWithValue("@RFID", scannedRFID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            slot = reader["Rack Slot"]?.ToString();
                    }
                }
                using (var cmd = new MySqlCommand("SELECT `Status` FROM `rfids` WHERE `RFID Number` = @RFID", conn))
                {
                    cmd.Parameters.AddWithValue("@RFID", scannedRFID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            status = reader["Status"]?.ToString();
                    }
                }
                using (var cmd = new MySqlCommand("UPDATE `rfid controller` SET `RFID scan` = '' WHERE `idRFID controller` = 1", conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            if (string.IsNullOrWhiteSpace(status) || !status.Equals("Active"))
            {
                MessageBox.Show("Card is Locked or Inactive.");
            }
            else
            {
                var payConForm = new PayConForm(scannedRFID, slot, LoggedUsername);
                payConForm.ShowDialog();
                this.Close();
                return;
            }
            timer1.Enabled = true;
        }
        private void Form9_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Returnbtn_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void PayScanForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
        }
    }
}
