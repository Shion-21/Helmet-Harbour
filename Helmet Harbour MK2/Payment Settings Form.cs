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
    public partial class PaymentSettingsForm : Form
    {
        string LoggedUsername;
        bool RootAdminAction;
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;
        public PaymentSettingsForm(string LoggedUsernameConstruct, bool RootAdminActionConstruct)
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            InitializeComponent();
            Payment_mode_set.Text = Properties.Settings.Default.Payment_type;
            Fee_Textbox.Text = Properties.Settings.Default.Fee_Amount.ToString();
            Initial_Payment_Enabler.Checked = Properties.Settings.Default.Initial_Payment;
            Initial_Payment_Textbox.Text = Properties.Settings.Default.Initial_Payment_Value.ToString();
            ParkingVal.Text = Properties.Settings.Default.Parking_Fee.ToString();
            LoggedUsername = LoggedUsernameConstruct;
            RootAdminAction = RootAdminActionConstruct;
        }

        private void PaymentSettingsForm_Load(object sender, EventArgs e)
        {
            Payment_mode_set.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Save_Settings_Click(object sender, EventArgs e)
        {
            Double Initial_Value = 0.0;
            if (Double.TryParse(Initial_Payment_Textbox.Text, out Initial_Value))
            {
                Properties.Settings.Default.Initial_Payment_Value = Initial_Value;
            }
            else
            {
                MessageBox.Show("Please input a valid base rate amount");
                return;
            }

            Double Fee_Value = 0.0;
            if (Double.TryParse(Fee_Textbox.Text, out Fee_Value))
            {
                Properties.Settings.Default.Fee_Amount = Fee_Value;
            }
            else
            {
                MessageBox.Show("Please input a valid fee amount");
                return;
            }

            Double Parking_Value = 0.0;
            if (Double.TryParse(ParkingVal.Text, out Parking_Value))
            {
                Properties.Settings.Default.Parking_Fee = Parking_Value;
            }
            else
            {
                MessageBox.Show("Please input a valid parking fee amount");
                return;
            }
            Properties.Settings.Default.Payment_type = Payment_mode_set.Text;
            Properties.Settings.Default.Initial_Payment = Initial_Payment_Enabler.Checked;
            Properties.Settings.Default.Save();

            if (!RootAdminAction)
            {
                GetUserInfo(LoggedUsername);
                InsertAction(ActionName, EmpNum, "Payment option changed");
            }
            this.Close();
        }

        private void Cancel_Settings_Click(object sender, EventArgs e)
        {
            if (!RootAdminAction)
            {
                GetUserInfo(LoggedUsername);
                InsertAction(ActionName, EmpNum, "Payment option change canceled");
            }
            this.Close();
        }
        string EmpNum;
        string ActionName = "Payment";

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
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
