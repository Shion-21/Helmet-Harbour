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

namespace Helmet_Harbour_MK2
{

    public partial class MasterkeyForm : Form
    {
        string LoggedUsername;
        bool RootAdminAction;
        string oldRFID, newRFID;
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;
        public MasterkeyForm(string LoggedUsernameConstruct, bool RootAdminActionConstruct)
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            LoggedUsername = LoggedUsernameConstruct;
            RootAdminAction = RootAdminActionConstruct;
            InitializeComponent();
            ScanCheck.Enabled = true;
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "Select `master card` FROM `rfid controller` WHERE `idRFID controller` = 1";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        try
                        {
                            if (reader.Read())
                            {
                                oldRFID = reader["RFID scan"].ToString();
                            }
                        }
                        catch
                        {
                            oldRFID = string.Empty;
                        }

                    }
                }
            }
        }

        private void Returnbtn_Click(object sender, EventArgs e)
        {
            ScanCheck.Enabled = false;
            this.Close();
        }
        private void ScanCheck_Tick(object sender, EventArgs e)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "Select `RFID scan` FROM `rfid controller` WHERE `idRFID controller` = 1";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            newRFID = reader["RFID scan"].ToString();
                        }
                    }
                }
            }
            if (string.IsNullOrEmpty(newRFID)) return;
            ScanCheck.Enabled = false;
            this.TopMost = false;
            MasterConfirmForm masterConfirmForm = new MasterConfirmForm(oldRFID, newRFID, LoggedUsername, RootAdminAction);
            masterConfirmForm.ShowDialog();
            this.Close();
        }

        private void MasterkeyForm_Load(object sender, EventArgs e)
        {
            ScanCheck.Start();
        }

        private void MasterkeyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ScanCheck.Stop(); 
            ScanCheck.Dispose();
        }
    }
}
