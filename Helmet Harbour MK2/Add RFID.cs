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
    public partial class AddRFIDForm : Form
    {
        string LoggedUsername;
        bool RootAdminAction;

        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;
        public AddRFIDForm(string LoggedUsernameConstruct, bool RootAdminActionConstruct)
        {

            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            LoggedUsername = LoggedUsernameConstruct;
            RootAdminAction = RootAdminActionConstruct;
            InitializeComponent();
            ScanCheck.Enabled = true;
            ScanCheck.Start();
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
            ScanCheck.Enabled = false;
            if (ExistDeletedRFID())
            {
                DialogResult Existresult = MessageBox.Show(
                "Restore RFID?",
                "Confirmation",
                MessageBoxButtons.YesNo
                );

                if (Existresult == DialogResult.No) return;
                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {
                    string query = "Update helmetharbour.`rfids` SET `Status` = 'Inactive' WHERE `RFID Number` = @RFID";
                    mySqlConnection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {

                        command.Parameters.AddWithValue("@RFID", newRFID);
                        command.ExecuteNonQuery();
                    }
                }
                if (!RootAdminAction)
                {
                    GetUserInfo(LoggedUsername);
                    InsertAction(ActionName, EmpNum, "Restored RFID");
                }
                this.Close();
            }
            if (ExistRFID())
            {
                MessageBox.Show("RFID already exists");
                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {
                    string query = "Update helmetharbour.`rfid controller` SET `RFID scan` = '' WHERE `idRFID controller` = 1";
                    mySqlConnection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        command.ExecuteNonQuery();
                        ScanCheck.Enabled = true;
                    }
                }
                return;
            }


            DialogResult result = MessageBox.Show(
            "Are you sure you want to continue?",
            "Confirmation",
            MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {


                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {
                    string query = "INSERT INTO helmetharbour.`rfids` (`RFID Number`, `Status`) VALUES (@RFID, 'Inactive')";
                    mySqlConnection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {

                        command.Parameters.AddWithValue("@RFID", newRFID);
                        command.ExecuteNonQuery();
                    }

                }
                MessageBox.Show("Successfully added");
            }
            else
            {
                MessageBox.Show("Action cancelled");
            }
            if (!RootAdminAction)
            {
                GetUserInfo(LoggedUsername);
                InsertAction(ActionName, EmpNum, "Added RFID");
            }
            ScanCheck.Enabled = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void returnbtn_Click(object sender, EventArgs e)
        {
            ScanCheck.Enabled = false;

            this.Close();
        }
        private bool ExistRFID()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "SELECT EXISTS (SELECT 1 FROM helmetharbour.`rfids` WHERE `RFID Number` = @RFID AND (`Status` = 'Active' OR `Status` = 'Locked' OR `Status` = 'Inactive' OR `Status` = 'Deleted'))";
                mySqlConnection.Open();
                using (MySqlCommand cmdexist = new MySqlCommand(query, mySqlConnection))
                {
                    cmdexist.Parameters.AddWithValue("@RFID", newRFID);
                    object result = cmdexist.ExecuteScalar();
                    return result != null && Convert.ToBoolean(result);
                }
            }
        }
        private bool ExistDeletedRFID()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "SELECT EXISTS (SELECT 1 FROM helmetharbour.`rfids` WHERE `RFID Number` = @RFID AND `Status` = 'Deleted')";
                mySqlConnection.Open();
                using (MySqlCommand cmdexist = new MySqlCommand(query, mySqlConnection))
                {
                    cmdexist.Parameters.AddWithValue("@RFID", newRFID);
                    object result = cmdexist.ExecuteScalar();
                    return result != null && Convert.ToBoolean(result);
                }
            }
        }

        private void Returnbtn_Click_1(object sender, EventArgs e)
        {
            if (!RootAdminAction)
            {
                GetUserInfo(LoggedUsername);
                InsertAction(ActionName, EmpNum, "Add RFID canceled");
            }
            this.Close();
        }
        string EmpNum;
        string ActionName = "RFID";

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

        private void AddRFIDForm_Load(object sender, EventArgs e)
        {
            ScanCheck.Start();
        }

        private void AddRFIDForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ScanCheck.Stop();
            ScanCheck.Dispose();
        }

    }

}
