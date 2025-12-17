using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;
using System.Diagnostics.Eventing.Reader;

namespace Helmet_Harbour_MK2
{
    public partial class ActivationScanner : Form
    {
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;
        string LoggedUsername;
        bool RootAdminAction;
        public ActivationScanner(string LoggedUsernameConstruct, bool RootAdminActionConstruct)
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            LoggedUsername = LoggedUsernameConstruct;
            RootAdminAction = RootAdminActionConstruct;
            InitializeComponent();
            timer1.Enabled = true;

        }

        string newRFID;


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
            timer1.Enabled = false;
            CheckStatus();
            Checkmasterkey();
            if (CardStatus.Equals("Active") || CardStatus.Equals("Locked") || newRFID.Equals(masterkey))
            {
                MessageBox.Show("Card is already active or locked");
                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {
                    string query = "UPDATE helmetharbour.`rfid controller` SET `RFID scan` = NULL WHERE `idRFID controller` = 1";
                    mySqlConnection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        command.ExecuteNonQuery();
                    }
                    timer1.Enabled = true;
                    return;
                }
            }
            ActivationForm activationForm = new ActivationForm(newRFID, LoggedUsername, RootAdminAction);
            activationForm.ShowDialog();
            this.Close();
        }


        private void Returnbtn_Click_1(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Cancel Activation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;
            timer1.Enabled = false;
            this.Close();
        }
        string CardStatus;
        private void CheckStatus()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "Select `Status` FROM `rfids` WHERE `RFID Number` = @RFID";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@RFID", newRFID);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CardStatus = reader["Status"].ToString();
                        }
                    }
                }
            }
        }
        string EmpNum;
        string ActionName = "Card Activation";

        private void GetUserInfo(string Usernameforlog)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "SELECT * FROM helmetharbour.`accounts` WHERE `Username` = @Username";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@Username", Usernameforlog);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            EmpNum = reader.GetString("Employee ID");
                        }
                    }
                }
            }
        }

        private void InsertAction(string Action, string EmpID, string Remark)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "INSERT INTO helmetharbour.`actions log` (`Employee Number`, `User`, `Action`, `Remarks`, `Date & Time`) VALUES (@EmpID, @Username, @Action, @Remark, NOW())";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@EmpID", EmpID);
                    command.Parameters.AddWithValue("@Username", LoggedUsername);
                    command.Parameters.AddWithValue("@Action", Action);
                    command.Parameters.AddWithValue("@Remark", Remark);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void ActivationScanner_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
        }

        private void ActivationScanner_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        string masterkey;
        private void Checkmasterkey()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "Select `master card` FROM `rfid controller` WHERE `idRFID controller` = 1";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            masterkey = reader["master card"].ToString();
                        }
                        else
                        {
                            masterkey = "";
                        }
                    }
                }
            }
        }
    }
}
