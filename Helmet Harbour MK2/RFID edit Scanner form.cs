using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Helmet_Harbour_MK2
{
    public partial class ScannerForm : Form
    {
        string oldRFID, newRFID;
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;
        string LoggedUsername;
        bool RootAdminAction;

        public ScannerForm(string RFID, string LoggedUsernameConstruct, bool RootAdminActionConstruct)
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            LoggedUsername = LoggedUsernameConstruct;
            RootAdminAction = RootAdminActionConstruct;
            InitializeComponent();
            oldRFID = RFID;
            this.TopMost = true;
            ScanCheck.Enabled = true;

        }

        private void ScannerForm_Load(object sender, EventArgs e)
        {
            ScanCheck.Start();

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
            EdittingForm edittingForm = new EdittingForm(oldRFID, newRFID, LoggedUsername, RootAdminAction);
            edittingForm.ShowDialog();
            this.Close();
        }

        private void returnbtn_Click(object sender, EventArgs e)
        {
            ScanCheck.Enabled = false;
            this.Close();
        }

        private void ScannerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ScanCheck.Stop();
            ScanCheck.Dispose();
        }
    }
}
