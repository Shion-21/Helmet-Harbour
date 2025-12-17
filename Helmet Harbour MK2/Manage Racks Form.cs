using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace Helmet_Harbour_MK2
{
    public partial class RackManageForm : Form
    {
        string LoggedUsername;
        bool RootAdminAction;
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;

        public RackManageForm(string LoggedUsernameConstruct, bool RootAdminActionConstruct)
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            InitializeComponent();
            LoadDataGrid();
            GetUserInfo(LoggedUsernameConstruct);
            LoggedUsername = LoggedUsernameConstruct;
            RootAdminAction = RootAdminActionConstruct;
        }
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        private void LoadDataGrid()
        {
            using (MySqlConnection conn = new MySqlConnection(conphrase))
            {
                string query = "SELECT * FROM helmetharbour.`helmet racks`";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                RackManageDB.DataSource = dt;
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
        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (RackManageDB.SelectedRows.Count == 0)
            {
                MessageBox.Show("No Rack selected.");
                return;
            }
            DataGridViewRow row = RackManageDB.SelectedRows[0];
            string Slot = row.Cells["Rack_slot"].Value?.ToString();
            if (checkinuse(Slot))
            {
                MessageBox.Show("Slot is in use");
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
                    string query = "DELETE FROM helmetharbour.`helmet racks` WHERE `Rack Slot`= @Slot";
                    mySqlConnection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        command.Parameters.AddWithValue("@Slot", Slot);
                        command.ExecuteNonQuery();
                    }

                }
                MessageBox.Show("Deleted");
                if (!RootAdminAction)
                {
                    InsertAction(ActionName, EmpNum, "Rack deleted");
                }
            }
            else
            {
                MessageBox.Show("Action cancelled.");
            }
            LoadDataGrid();
        }

        private void RackManageForm_Load(object sender, EventArgs e)
        {
            RackManageDB.ClearSelection();
        }
        private void titlebarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Add_Rack add_Rack = new Add_Rack(LoggedUsername, RootAdminAction);
            if (add_Rack.ShowDialog() == DialogResult.OK)
            {
                {
                    LoadDataGrid();
                }
            }
        }

        private bool checkinuse(string Slot)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "SELECT `RFID #` FROM helmetharbour.`helmet racks` WHERE `Rack Slot` = @Slot";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@Slot", Slot);
                    using (var reader = command.ExecuteReader())
                    {
                        try
                        {
                            if (reader.Read())
                            {
                                string RFIDused = reader.GetString("RFID #");
                                if (string.IsNullOrEmpty(RFIDused))
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }

                            }
                            else
                            {
                                return true;
                            }
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }
            }
        }

        private void CreateFClose_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainMinimizebtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void RackManageDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                RackManageDB.ClearSelection();
                RackManageDB.Rows[e.RowIndex].Selected = true;
                RackManageDB.MultiSelect = false;
            }
        }
    }
}
