using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helmet_Harbour_MK2.Properties;
using MySql.Data.MySqlClient;
using ESCPOS_NET;
using ESCPOS_NET.Emitters;

namespace Helmet_Harbour_MK2
{
    public partial class Security_Form : Form
    {
        string LoggedUsername;
        bool RootAdminAction;
        private System.Windows.Forms.Timer flashTimer;
        private System.Drawing.Color color1 = System.Drawing.Color.White;  // Normal state
        private System.Drawing.Color color2 = System.Drawing.Color.Red;    // Alarm color
        private float fadeProgress = 0f;     // 0 = color1, 1 = color2
        private bool fadingIn = true;
        private float fadeSpeed = 0.05f;
        public Security_Form(string LoggedUsernameConstruct, bool RootAdminActionConstruct)
        {
            InitializeComponent();

            LoggedUsername = LoggedUsernameConstruct;
            RootAdminAction = RootAdminActionConstruct;

        }
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;

        private void Form11_Load(object sender, EventArgs e)
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            flashTimer = new System.Windows.Forms.Timer();
            flashTimer.Interval = 30;
            flashTimer.Tick += FlashTimer_Tick;
            flashTimer.Start();
            SecurityCheck_Timer.Start();
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "SELECT * FROM helmetharbour.`helmet racks` WHERE Security = 'Breached'";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        SecurityDB.DataSource = dataTable;
                        SecurityDB.ClearSelection();
                        SecurityDB.CurrentCell = null;
                    }
                }
            }
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, SecurityDB, new object[] { true });
        }
        private void SafeButton(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == SecurityDB.Columns["Safe"].Index)
            {

                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {

                    if (e.RowIndex == -1) { return; }
                    int CellSelect = e.RowIndex;
                    DataGridViewRow row = SecurityDB.Rows[CellSelect];
                    string Secslot = row.Cells["Slot"].Value.ToString();
                    string query = "UPDATE `helmet racks` SET `Security` = 'Safe', `Alarm` = 1 WHERE `Rack Slot` = @Secslot ";
                    mySqlConnection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        command.Parameters.AddWithValue("@Secslot", Secslot);
                        command.ExecuteNonQuery();
                        if (!RootAdminAction)
                        {
                            GetUserInfo(LoggedUsername);
                            InsertAction(ActionName, EmpNum, "Clicked Safe " + Secslot);
                        }
                    }
                }
            }
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "SELECT * FROM helmetharbour.`helmet racks` WHERE Security = 'Breached'";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        SecurityDB.DataSource = dataTable;
                        SecurityDB.ClearSelection();
                        SecurityDB.CurrentCell = null;
                    }
                }
            }
        }
        SoundPlayer soundPlayer = new SoundPlayer(Path.Combine(Application.StartupPath, "Sounds", "Alarm.wav"));
        private void Alarm_Timer_Tick(object sender, EventArgs e)
        {
            bool playAlarm = false;

            foreach (DataGridViewRow row in SecurityDB.Rows)
            {
                if (row.IsNewRow) continue;

                object cellValue = row.Cells["Alarm"].Value;
                bool isChecked = cellValue != null && cellValue != DBNull.Value && Convert.ToBoolean(cellValue);

                if (isChecked)
                {
                    playAlarm = true;
                    break;
                }
            }

            if (playAlarm)
            {
                soundPlayer.PlayLooping();
            }
            else
            {
                soundPlayer.Stop();
            }
        }

        private void SecurityDB_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            int CellSelect = e.RowIndex;
            DataGridViewRow row = SecurityDB.Rows[CellSelect];
            object cellValue = SecurityDB.Rows[e.RowIndex].Cells["Alarm"].Value;
            bool isChecked = false;
            if (cellValue != null && cellValue != DBNull.Value) isChecked = cellValue.ToString() == "1" || cellValue.ToString().ToLower() == "true";
            string Secslot = row.Cells["Slot"].Value.ToString();
            Console.WriteLine(isChecked);
            Console.WriteLine(Secslot);
            Console.WriteLine("TEST");
            string query = "UPDATE helmetharbour.`helmet racks` SET `Alarm` = @alarm WHERE `Rack Slot` = @slot";

            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@alarm", isChecked ? 1 : 0);
                    command.Parameters.AddWithValue("@slot", Secslot);
                    command.ExecuteNonQuery();
                }
            }
        }


        private void SecurityDB_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (SecurityDB.IsCurrentCellDirty)
            {
                SecurityDB.CommitEdit(DataGridViewDataErrorContexts.Commit);
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
            if (!SecurityCheckStatus)
            {
                SecurityCheck_Timer.Stop();
                soundPlayer.Stop();
                this.Close();
            }
        }
        private DataTable rackTable = new DataTable();

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(conphrase))
            {
                string query = "SELECT * FROM `helmet racks` WHERE `Security` = 'Breached'";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                DataTable newTable = new DataTable();
                adapter.Fill(newTable);
                if (!DataTablesAreEqual(rackTable, newTable))
                {
                    rackTable = newTable;
                    SecurityDB.DataSource = rackTable;
                    SecurityDB.ClearSelection();
                    SecurityDB.CurrentCell = null;
                }
            }
        }

        private bool DataTablesAreEqual(DataTable dt1, DataTable dt2)
        {
            if (dt1.Rows.Count != dt2.Rows.Count || dt1.Columns.Count != dt2.Columns.Count)
                return false;

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                for (int j = 0; j < dt1.Columns.Count; j++)
                {
                    if (!dt1.Rows[i][j].Equals(dt2.Rows[i][j]))
                        return false;
                }
            }
            return true;
        }

        private void Security_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Alarm_Timer.Stop();
            soundPlayer.Stop();
            soundPlayer.Dispose();
        }

        private void Muteall_Click(object sender, EventArgs e)
        {
            string query = "UPDATE helmetharbour.`helmet racks` SET `Alarm` = '0'";

            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void Safeall_Click(object sender, EventArgs e)
        {
            string query = "UPDATE helmetharbour.`helmet racks` SET `Security` = 'Safe', `Alarm` = true";

            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
            if (!RootAdminAction)
            {
                GetUserInfo(LoggedUsername);
                InsertAction(ActionName, EmpNum, "Clicked Safe All");
            }
        }
        string EmpNum;
        string ActionName = "Security";

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

        private void FlashTimer_Tick(object sender, EventArgs e)
        {
            if (fadingIn)
            {
                fadeProgress += fadeSpeed;
                if (fadeProgress >= 1f)
                {
                    fadeProgress = 1f;
                    fadingIn = false;
                }
            }
            else
            {
                fadeProgress -= fadeSpeed;
                if (fadeProgress <= 0f)
                {
                    fadeProgress = 0f;
                    fadingIn = true;
                }
            }
            int r = (int)(color1.R + (color2.R - color1.R) * fadeProgress);
            int g = (int)(color1.G + (color2.G - color1.G) * fadeProgress);
            int b = (int)(color1.B + (color2.B - color1.B) * fadeProgress);

            this.BackColor = System.Drawing.Color.FromArgb(r, g, b);
        }

    }
}

