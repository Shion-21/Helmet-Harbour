using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Helmet_Harbour_MK2
{
    public partial class UsageForm : Form
    {
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;
        private System.Timers.Timer debounceTimer;
        private int currentRow = 0;
        public UsageForm()
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            InitializeComponent();
            SearchCon.SelectedIndex = 0;
            InitializeDatePickers();
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        private void UsageForm_Load(object sender, EventArgs e)
        {

            InitializeSearchDebounce();
            LoadData(StarDateSelector.Value, EndDateSelector.Value, searchtxtbox.Text);
        }

        private void InitializeDatePickers()
        {
            DateTime minDate = new DateTime(2025, 8, 1);
            DateTime maxDate = DateTime.Now.Date;

            StarDateSelector.MinDate = minDate;
            StarDateSelector.MaxDate = maxDate;
            EndDateSelector.MinDate = minDate;
            EndDateSelector.MaxDate = maxDate;

            StarDateSelector.Value = minDate;
            EndDateSelector.Value = maxDate;

            StarDateSelector.ValueChanged += (s, e) =>
            {
                EndDateSelector.MinDate = StarDateSelector.Value;
                if (EndDateSelector.Value < StarDateSelector.Value)
                    EndDateSelector.Value = StarDateSelector.Value;

                LoadData(StarDateSelector.Value, EndDateSelector.Value, searchtxtbox.Text);
            };

            EndDateSelector.ValueChanged += (s, e) =>
            {
                StarDateSelector.MaxDate = EndDateSelector.Value;
                if (StarDateSelector.Value > EndDateSelector.Value)
                    StarDateSelector.Value = EndDateSelector.Value;

                LoadData(StarDateSelector.Value, EndDateSelector.Value, searchtxtbox.Text);
            };
        }

        private void InitializeSearchDebounce()
        {
            debounceTimer = new System.Timers.Timer();
            debounceTimer.Interval = 300;
            debounceTimer.AutoReset = false;
            debounceTimer.Elapsed += DebounceTimer_Elapsed;

            searchtxtbox.TextChanged += (s, e) =>
            {
                debounceTimer.Stop();
                debounceTimer.Start();
            };
        }

        private void DebounceTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                LoadData(StarDateSelector.Value, EndDateSelector.Value, searchtxtbox.Text);
            });
        }

        private void LoadData(DateTime startDate, DateTime endDate, string search)
        {
            endDate = endDate.Date.AddDays(1).AddSeconds(-1);
            if (SearchCon.Text.Equals("Usage ID"))
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {
                    mySqlConnection.Open();
                    string query = "SELECT * FROM helmetharbour.`usage log` WHERE `Date & Time` BETWEEN @start AND @end AND `idusage log` LIKE @search ;";

                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        command.Parameters.AddWithValue("@start", startDate);
                        command.Parameters.AddWithValue("@end", endDate);
                        command.Parameters.AddWithValue("@search", "%" + search + "%");

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            else if (SearchCon.Text.Equals("Slot"))
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {
                    mySqlConnection.Open();
                    string query = "SELECT * FROM helmetharbour.`usage log` WHERE `Date & Time` BETWEEN @start AND @end AND `Slot` LIKE @search ;";

                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        command.Parameters.AddWithValue("@start", startDate);
                        command.Parameters.AddWithValue("@end", endDate);
                        command.Parameters.AddWithValue("@search", "%" + search + "%");

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            else if (SearchCon.Text.Equals("RFID Number"))
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {
                    mySqlConnection.Open();
                    string query = "SELECT * FROM helmetharbour.`usage log` WHERE `Date & Time` BETWEEN @start AND @end AND `RFID No.` LIKE @search ;";

                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        command.Parameters.AddWithValue("@start", startDate);
                        command.Parameters.AddWithValue("@end", endDate);
                        command.Parameters.AddWithValue("@search", "%" + search + "%");

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            else if (SearchCon.Text.Equals("Card ID"))
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {
                    mySqlConnection.Open();
                    string query = "SELECT * FROM helmetharbour.`usage log` WHERE `Date & Time` BETWEEN @start AND @end AND `Card ID` LIKE @search ;";

                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        command.Parameters.AddWithValue("@start", startDate);
                        command.Parameters.AddWithValue("@end", endDate);
                        command.Parameters.AddWithValue("@search", "%" + search + "%");

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            else if (SearchCon.Text.Equals("None"))
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {
                    mySqlConnection.Open();
                    string query = "SELECT * FROM helmetharbour.`usage log` WHERE `Date & Time` BETWEEN @start AND @end;";

                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        command.Parameters.AddWithValue("@start", startDate);
                        command.Parameters.AddWithValue("@end", endDate);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }

        }

        private void UsageClose_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsageMinimizebtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void titlebarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }
    }
}


