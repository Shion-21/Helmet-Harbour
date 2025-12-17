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
    public partial class MasterConfirmForm : Form
    {
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;
        string LoggedUsername;
        bool RootAdminAction;
        public MasterConfirmForm(string OldRFID, string NewRFID, string LoggedUsernameConstruct, bool RootAdminActionConstruct)
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            LoggedUsername = LoggedUsernameConstruct;
            RootAdminAction = RootAdminActionConstruct;
            this.TopMost = true;
            InitializeComponent();
            OldRFIDlbl.Text = OldRFID;
            NewRFIDlbl.Text = NewRFID;
        }

        private void Rescanbtn_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "Update `rfid controller` SET `RFID scan` = '' WHERE `idRFID controller` = 1";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
            MasterkeyForm masterkeyform = new MasterkeyForm(LoggedUsername, RootAdminAction);
            masterkeyform.Show();
            this.Close();
        }

        private void Canceltbn_Click(object sender, EventArgs e)
        {
            if (!RootAdminAction)
            {
                GetUserInfo(LoggedUsername);
                InsertAction(ActionName, EmpNum, "Masterkey change cancelled");
            }
            this.Close();
        }

        private void confirmbtn_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                if (ExistRFID()) { MessageBox.Show("RFID already in use"); return; }

                String query = "UPDATE helmetharbour.`rfid controller` SET `master card` = @NEWRFID WHERE `idRFID controller` = 1;";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@NEWRFID", NewRFIDlbl.Text?.Trim());

                    command.ExecuteNonQuery();
                }
                query = "Update helmetharbour.`rfid controller` SET `RFID scan` = '' WHERE `idRFID controller` = 1";
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.ExecuteNonQuery();
                }

            }
            if (!RootAdminAction)
            {
                GetUserInfo(LoggedUsername);
                InsertAction(ActionName, EmpNum, "Masterkey changed");
            }
            this.Close();
        }
        private bool ExistRFID()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "SELECT EXISTS (SELECT 1 FROM `rfids` WHERE `RFID Number` = @NEWRFID)";
                mySqlConnection.Open();
                using (MySqlCommand cmdexist = new MySqlCommand(query, mySqlConnection))
                {
                    cmdexist.Parameters.AddWithValue("@NEWRFID", NewRFIDlbl.Text?.Trim());
                    object result = cmdexist.ExecuteScalar();
                    return result != null && Convert.ToBoolean(result);
                }
            }
        }
        string EmpNum;
        string ActionName = "Masterkey";

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
    }
}
