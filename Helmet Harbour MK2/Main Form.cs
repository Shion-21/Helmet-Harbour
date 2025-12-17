using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices;

namespace Helmet_Harbour_MK2
{
    public partial class MainForm : Form
    {
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;
        bool isAdmin = false;
        bool isRootAdmin = false;
        string LoggedUsername;
        bool RootAdminAction = false;
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        public MainForm(string Username)
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "SELECT `Access` FROM helmetharbour.`accounts` WHERE `Username` = @username";
                mySqlConnection.Open();

                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@username", Username);

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        string accessLevel = result.ToString();
                        if (accessLevel.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                        {
                            isAdmin = true;
                        }
                        else if (accessLevel.Equals("RootAdmin", StringComparison.OrdinalIgnoreCase))
                        {
                            isAdmin = true;
                            isRootAdmin = true;
                            RootAdminAction = isRootAdmin;
                        }
                        else
                        {
                            isAdmin = false;
                        }
                    }
                }

            }


            InitializeComponent();
            Welcomelbl.TextAlign = ContentAlignment.MiddleRight;
            string WelcomeName = char.ToUpper(Username[0]) + Username.Substring(1);
            Welcomelbl.Text = "Welcome, " + WelcomeName;
            LoggedUsername = Username;

            if (!RootAdminAction)
            {
                GetUserInfo(LoggedUsername);
                InsertAction(ActionName, EmpNum, "Logged in");
            }
        }

        private void MainFClose_Btn_Click(object sender, EventArgs e)
        {
            if (!RootAdminAction)
            {
                GetUserInfo(LoggedUsername);
                InsertAction(ActionName, EmpNum, "Logged out");
            }
            this.Close();
        }
        private void MainFClose_MouseHover(object sender, EventArgs e)
        {
            CreateFClose_Btn.ForeColor = Color.Red;
        }

        private void MainFClose_MouseLeave(object sender, EventArgs e)
        {
            CreateFClose_Btn.ForeColor = Color.Black;
        }

        private void MainFMinimize_Btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void MainFMinimize_MouseHover(object sender, EventArgs e)
        {
            MainMinimizebtn.ForeColor = Color.Blue;
        }

        private void MainFMinimize_MouseLeave(object sender, EventArgs e)
        {
            MainMinimizebtn.ForeColor = Color.Black;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            records_panel.Height = 0;
            Settings_Panel.Height = 0;
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "SELECT * FROM helmetharbour.`helmet racks`";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        RackDB.DataSource = dataTable;
                        RackDB.ClearSelection();
                        RackDB.CurrentCell = null;
                    }
                }
            }
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, RackDB, new object[] { true });
        }
        bool settings_extend = false;
        private void Settingsbtn_Click(object sender, EventArgs e)
        {
            if (settings_extend)
            {
                if (records_extend)
                {
                    records_panel.Height = 0;
                    records_extend = false;

                }
                Settings_Panel.Height = 0;
                settings_extend = false;
            }
            else
            {
                if (records_extend)
                {
                    records_panel.Height = 0;
                    records_extend = false;
                }
                Settings_Panel.Height = 246;
                settings_extend = true;
            }
        }


        private void Settings_transitionTick_Tick(object sender, EventArgs e)
        {

        }

        private void PaymentSettingsbtn_Click(object sender, EventArgs e)
        {
            Settings_Panel.Height = 0;
            settings_extend = false;
            if (!isAdmin) return;
            PaymentSettingsForm paymentSettingsForm = new PaymentSettingsForm(LoggedUsername, RootAdminAction);
            paymentSettingsForm.ShowDialog();
        }

        private void Mastercard_btn_Click(object sender, EventArgs e)
        {
            Settings_Panel.Height = 0;
            settings_extend = false;
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "Update helmetharbour.`rfid controller` SET `RFID scan` = '' WHERE `idRFID controller` = 1";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
            if (!isAdmin) return;
            MasterkeyForm masterkeyForm = new MasterkeyForm(LoggedUsername, RootAdminAction);
            masterkeyForm.ShowDialog();
        }

        private void RackDB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == RackDB.Columns["Edit_Btn"].Index)
            {
                if (e.RowIndex < 0) return;

                int CellSelect = e.RowIndex;
                DataGridViewRow row = RackDB.Rows[CellSelect];
                string Editting = row.Cells["RFID"]?.Value?.ToString();
                if (string.IsNullOrEmpty(Editting)) return;

                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {
                    string query = "Update `rfid controller` SET `RFID scan` = '' WHERE `idRFID controller` = 1";
                    mySqlConnection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        command.ExecuteNonQuery();
                    }

                }
                using (ScannerForm scannerForm = new ScannerForm(Editting, LoggedUsername, RootAdminAction)) { scannerForm.ShowDialog(); }
            }
            else { }
        }

        private DataTable rackTable = new DataTable();
        private string currentSearchText = "";
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            currentSearchText = SearchBox.Text.Trim();
        }
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            int firstDisplayedRowIndex = 0;
            int selectedRowIndex = -1;

            if (RackDB.Rows.Count > 0)
            {
                try
                {
                    firstDisplayedRowIndex = RackDB.FirstDisplayedScrollingRowIndex;
                    if (RackDB.SelectedRows.Count > 0)
                        selectedRowIndex = RackDB.SelectedRows[0].Index;
                }
                catch { }
            }

            using (MySqlConnection connection = new MySqlConnection(conphrase))
            {

                string query = "SELECT `Rack Slot`, `RFID #`, `Time Start`, `Time End`, `RFIDSet`, `Security`, `Alarm` FROM `helmet racks`";

                if (!string.IsNullOrEmpty(currentSearchText))
                {
                    query += " WHERE `Rack Slot` LIKE @search";
                }

                MySqlCommand command = new MySqlCommand(query, connection);
                if (!string.IsNullOrEmpty(currentSearchText))
                {
                    command.Parameters.AddWithValue("@search", "%" + currentSearchText + "%");
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                rackTable.Clear();
                adapter.Fill(rackTable);

                RackDB.DataSource = rackTable.DefaultView;
            }


            int insertIndexForDuration = RackDB.Columns["Time_Start"].Index + 1;
            if (!RackDB.Columns.Contains("Duration"))
                RackDB.Columns.Insert(insertIndexForDuration, new DataGridViewTextBoxColumn() { Name = "Duration", HeaderText = "Duration" });


            int insertIndexForFee = insertIndexForDuration + 1;
            if (!RackDB.Columns.Contains("Fee"))
                RackDB.Columns.Insert(insertIndexForFee, new DataGridViewTextBoxColumn() { Name = "Fee", HeaderText = "Fee" });
            double feeAmount = Properties.Settings.Default.Fee_Amount;
            string paymentType = Properties.Settings.Default.Payment_type;
            RackDB.Columns["Duration"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RackDB.Columns["Fee"].Width = 100;
            foreach (DataGridViewRow row in RackDB.Rows)
            {
                if (row.Cells["Time_Start"]?.Value != null && DateTime.TryParse(row.Cells["Time_Start"].Value.ToString(), out DateTime start))
                {
                    TimeSpan duration = DateTime.Now - start;
                    double totalMinutes = duration.TotalMinutes;
                    double totalHours = duration.TotalHours;

                    double fee = 0;
                    switch (paymentType)
                    {
                        case "Per Hour": fee = (int)totalHours * feeAmount; break;
                        case "Per 30 Mins": fee = ((int)totalMinutes / 30) * feeAmount; break;
                        case "Per 15 Mins": fee = ((int)totalMinutes / 15) * feeAmount; break;
                        case "Per 10 Mins": fee = ((int)totalMinutes / 10) * feeAmount; break;
                        case "Per 5 Mins": fee = ((int)totalMinutes / 5) * feeAmount; break;
                        case "Per 1 Min": fee = (int)totalMinutes * feeAmount; break;
                    }
                    if (Properties.Settings.Default.Initial_Payment) fee += Properties.Settings.Default.Initial_Payment_Value;
                    row.Cells["Fee"].Value = fee.ToString("F2");

                    int hours = (int)duration.TotalHours;
                    int minutes = duration.Minutes;
                    string durationDisplay = "";

                    if (hours > 0) durationDisplay += $"{hours} hr" + (hours > 1 ? "s " : " ");
                    if (minutes > 0) durationDisplay += $"{minutes} min" + (minutes > 1 ? "s" : "");
                    if (string.IsNullOrEmpty(durationDisplay)) durationDisplay = "0 min";

                    row.Cells["Duration"].Value = durationDisplay.Trim();
                    row.Cells["Fee"].Value = fee.ToString("F2");
                }
                else
                {
                    row.Cells["Fee"].Value = "";
                    row.Cells["Duration"].Value = "";
                }
            }
            RackDB.Columns["Edit_Btn"].DisplayIndex = 2;
            RackDB.ClearSelection();
            RackDB.CurrentCell = null;
            foreach (DataGridViewColumn col in RackDB.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            if (RackDB.Rows.Count > firstDisplayedRowIndex)
            {
                try { RackDB.FirstDisplayedScrollingRowIndex = firstDisplayedRowIndex; }
                catch { }
            }

            if (selectedRowIndex >= 0 && selectedRowIndex < RackDB.Rows.Count)
            {
                try { RackDB.Rows[selectedRowIndex].Selected = true; }
                catch { }
            }
        }
        private void RackDB_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (RackDB.Columns[e.ColumnIndex].Name == "Edit_Btn")
                {
                    Refresher.Stop();
                    Hovertimer.Start();
                }
            }
        }

        private void RackDB_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (RackDB.Columns[e.ColumnIndex].Name == "Edit_Btn")
                {
                    Refresher.Start();
                    Hovertimer.Stop();
                }
            }
        }
        private void RackDB_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RackDB.ClearSelection();
            RackDB.CurrentCell = null;
        }

        private void Hovertimer_Tick(object sender, EventArgs e)
        {
            Refresher.Start();
            Hovertimer.Stop();
        }
        private void invalidsymbol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ' ' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Paybtn_Click(object sender, EventArgs e)
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
            PayScanForm payScanForm = new PayScanForm(LoggedUsername);
            payScanForm.ShowDialog();
        }
        bool records_extend = false;
        private void Recordstbn_Click(object sender, EventArgs e)
        {

            if (records_extend)
            {
                if (settings_extend)
                {
                    Settings_Panel.Height = 0;
                    settings_extend = false;
                }
                records_panel.Height = 0;
                records_extend = false;
            }
            else
            {
                if (settings_extend)
                {
                    Settings_Panel.Height = 0;
                    settings_extend = false;
                }
                records_panel.Height = 184;
                records_extend = true;
            }
        }
        bool SecurityCheckStatus;
        private void SecurityCheckTimer_Tick(object sender, EventArgs e)
        {
            string query = "SELECT EXISTS(SELECT 1 FROM `helmet racks` WHERE `Security` = 'Breached');";

            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    SecurityCheckStatus = Convert.ToBoolean(command.ExecuteScalar());
                }
            }
            if (SecurityCheckStatus)
            {
                SecurityCheckTimer.Stop();
                Security_Form security_Form = new Security_Form(LoggedUsername, RootAdminAction);
                security_Form.ShowDialog();
            }
        }
        private void SecurityCheckTimer_Enabler(object sender, EventArgs e)
        {
            string query = "SELECT EXISTS(SELECT 1 FROM `helmet racks` WHERE `Security` = 'Breached');";

            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    SecurityCheckStatus = Convert.ToBoolean(command.ExecuteScalar());
                }
            }
            if (!SecurityCheckStatus)
            {
                SecurityCheckTimer.Start();
            }
        }

        private void Accountsbtn_Click(object sender, EventArgs e)
        {
            if (!isAdmin) return;

            AccountsForm accountsForm = new AccountsForm(isRootAdmin, LoggedUsername);
            accountsForm.ShowDialog();
        }

        private void RFIDsbtn_Click(object sender, EventArgs e)
        {
            Settings_Panel.Height = 0;
            settings_extend = false;
            RFIDsForm rFIDsForm = new RFIDsForm(LoggedUsername, RootAdminAction);
            rFIDsForm.ShowDialog();
        }

        private void Activationbtn_Click(object sender, EventArgs e)
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
            ActivationScanner activationScanner = new ActivationScanner(LoggedUsername, isRootAdmin);
            activationScanner.ShowDialog();
        }

        private void Logoutbtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to log out?", "Logging out", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (!RootAdminAction)
                {
                    GetUserInfo(LoggedUsername);
                    InsertAction(ActionName, EmpNum, "Logged out");
                }
                System.Windows.Forms.Application.Restart();
            }
        }

        private void ActionsLogbtn_Click(object sender, EventArgs e)
        {
            records_panel.Height = 0;
            records_extend = false;
            if (!isAdmin) return;
            ActionsForm actionsform = new ActionsForm(LoggedUsername, RootAdminAction);
            actionsform.Show();
        }

        private void Transactionsbtn_Click(object sender, EventArgs e)
        {
            records_panel.Height = 0;
            records_extend = false;
            RecordsForm recordsForm = new RecordsForm(LoggedUsername, RootAdminAction);
            recordsForm.Show();
        }
        private void titlebarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void Usagelogbtn_Click(object sender, EventArgs e)
        {
            records_panel.Height = 0;
            records_extend = false;
            UsageForm usageForm = new UsageForm();
            usageForm.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Settings_Panel.Height = 0;
            settings_extend = false;
            if (!isAdmin) return;
            RackManageForm rackManageForm = new RackManageForm(LoggedUsername, RootAdminAction);
            rackManageForm.Show();
        }

        private void Settings_Panel_MouseLeave(object sender, EventArgs e)
        {
            Point cursor = Settings_Panel.PointToClient(Cursor.Position);

            if (!Settings_Panel.ClientRectangle.Contains(cursor))
            {
                Settings_Panel.Height = 0;
                settings_extend = false;

            }
        }

        private void Records_Panel_MouseLeave(object sender, EventArgs e)
        {
            Point cursor = records_panel.PointToClient(Cursor.Position);

            if (!records_panel.ClientRectangle.Contains(cursor))
            {
                records_panel.Height = 0;
                records_extend = false;

            }
        }

        private void helpwindowbtn_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.Show();
        }
    }
}
