using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace Helmet_Harbour_MK2
{
    public partial class ActivationForm : Form
    {
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;
        string Usertype;
        string LoggedUsername;
        bool RootAdminAction;
        public ActivationForm(string RFID, string LoggedUsernameConstruct, bool RootAdminActionConstruct)
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            string RFID_ID = string.Empty;
            LoggedUsername = LoggedUsernameConstruct;
            RootAdminAction = RootAdminActionConstruct;
            InitializeComponent();
            RiderType.SelectedIndex = 0;
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "Select `idRFIDs` FROM `rfids` WHERE `RFID Number` = @RFID";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@RFID", RFID);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            RFID_ID = reader["idRFIDs"].ToString();
                        }   
                    }
                }
            }
            CardIDlbl.Text = RFID_ID;
            RFIDlbl.Text = RFID;
        }

        private void ActivationForm_Load(object sender, EventArgs e)
        {

        }

        readonly string pattern = @"^[A-Za-z]{3} \d{4}$";
        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            if (Platetxtbox.Text.Equals(""))
            {
                MessageBox.Show("No license plate entered");
                return;
            }
            if (!Regex.IsMatch(Platetxtbox.Text, pattern))
            {
                MessageBox.Show("Invalid input\n\n" +
                                 "- Must start with exactly 3 letters\n" +
                                 "- Must have 1 space after the letters\n" +
                                 "- Must end with exactly 4 digits\n\n" +
                                 "Example format: ABC 1234");
                return;
            }

            var result = MessageBox.Show("Are you sure?", "Confirmation",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "Update `rfids` " +
                    "SET `Status` = 'Active', `Failed Attempts` = 0, `Activation Time` = NOW(), `Plate Number` = @PlateNum, `TempHolder` = @Holder, `HolderType` = @UserType " +
                    "WHERE `RFID Number` = @RFID";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@Holder", nametextbox.Text.Trim());
                    command.Parameters.AddWithValue("@PlateNum", Platetxtbox.Text.Trim());
                    command.Parameters.AddWithValue("@RFID", RFIDlbl.Text);
                    command.Parameters.AddWithValue("@UserType", RiderType.Text);
                    command.ExecuteNonQuery();

                }
            }
            if (!RootAdminAction)
            {
                GetUserInfo(LoggedUsername);
                InsertAction(ActionName, EmpNum, "Activated Card");

            }
            this.Close();

        }

        private void Returnbtn_Click(object sender, EventArgs e)
        {
            if (!RootAdminAction)
            {
                GetUserInfo(LoggedUsername);
                InsertAction(ActionName, EmpNum, "Card activation canceled");
            }
            var result = MessageBox.Show("Cancel Activation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;
            this.Close();
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

        private void invalidsymbol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
