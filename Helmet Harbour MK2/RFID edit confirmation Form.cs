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
using Org.BouncyCastle.Ocsp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Helmet_Harbour_MK2
{
    public partial class EdittingForm : Form
    {
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;
        string LoggedUsername;
        bool RootAdminAction;
        public EdittingForm(string OldRFID, string NewRFID, string LoggedUsernameConstruct, bool RootAdminActionConstruct)
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
            ScannerForm scannerForm = new ScannerForm(OldRFIDlbl.Text, LoggedUsername, RootAdminAction);
            scannerForm.Show();
            this.Close();
        }

        private void Canceltbn_Click(object sender, EventArgs e)
        {
            if (!RootAdminAction)
            {
                GetUserInfo(LoggedUsername);
                InsertAction(ActionName, EmpNum, "Rack RFID edit canceled");
            }
            this.Close();
        }

        private void confirmbtn_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            if (!checkifregistered()) { MessageBox.Show("RFID is not registered"); return; }
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                if (ExistRFID()) { MessageBox.Show("RFID already in use 1"); return; }
                if (checkifinuse()) { MessageBox.Show("RFID already in use 2"); return; }

                String query = "UPDATE helmetharbour.`helmet racks` SET `RFID #` = @NEWRFID WHERE `RFID #` = @OLDRFID;";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@NEWRFID", NewRFIDlbl.Text?.Trim());
                    command.Parameters.AddWithValue("@OLDRFID", OldRFIDlbl.Text?.Trim());
                    command.ExecuteNonQuery();
                }
                query = "Update `rfid controller` SET `RFID scan` = '' WHERE `idRFID controller` = 1";
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.ExecuteNonQuery();
                }
                DateTime? activationTime = null;
                string tempHolder = null;
                string plateNumber= null;
                string Usertype = null;
                query = "SELECT `Activation Time`, `Plate Number`, `TempHolder`, `HolderType` FROM helmetharbour.`rfids` WHERE `RFID Number` = @RFID";
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@RFID", OldRFIDlbl.Text);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            activationTime = reader.IsDBNull(reader.GetOrdinal("Activation Time"))? (DateTime?)null: reader.GetDateTime("Activation Time");

                            plateNumber = reader.IsDBNull(reader.GetOrdinal("Plate Number"))? null: reader.GetString("Plate Number");

                            tempHolder = reader.IsDBNull(reader.GetOrdinal("TempHolder"))? null: reader.GetString("TempHolder");

                            Usertype = reader.IsDBNull(reader.GetOrdinal("HolderType")) ? null : reader.GetString("HolderType");
                        }

                    }
                }
                query = "UPDATE helmetharbour.`rfids` SET `Status` = 'Active', `Activation Time` = @Activation, `Plate Number` = @Plate, `TempHolder` = @Holder, `HolderType`= @Usertype WHERE `RFID Number` = @RFID";
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@Activation", activationTime);
                    command.Parameters.AddWithValue("@Plate", plateNumber ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Holder", tempHolder ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RFID", NewRFIDlbl.Text);
                    command.Parameters.AddWithValue("@Usertype", Usertype);
                    command.ExecuteNonQuery();
                }
                query = "UPDATE helmetharbour.`rfids` SET `Status` = 'Inactive', `Activation Time` = NULL, `Plate Number` = NULL, `TempHolder` = NULL, `HolderType` = NULL WHERE `RFID Number` = @RFID";
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@RFID", OldRFIDlbl.Text);
                    command.ExecuteNonQuery();
                }
            }
            if (!RootAdminAction)
            {
                GetUserInfo(LoggedUsername);
                InsertAction(ActionName, EmpNum, "Rack RFID edited");
            }
            this.Close();
        }
        private bool ExistRFID()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "SELECT EXISTS (SELECT 1 FROM `helmet racks` WHERE `RFID #` = @NEWRFID)";
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
        string ActionName = "Rack";

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
        private bool checkifinuse()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "Select `Activation Time` FROM helmetharbour.`rfids` WHERE `RFID Number` = @RFID AND `Activation Time` IS NOT NULL";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@RFID", NewRFIDlbl.Text);
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }
        private bool checkifregistered()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "Select `RFID Number` FROM helmetharbour.`rfids` WHERE `RFID Number` = @RFID AND `Status` != 'Deleted'";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@RFID", NewRFIDlbl.Text);
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }
    }
}
