using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Drawing.Printing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;



namespace Helmet_Harbour_MK2
{
    public partial class RecordsForm : Form
    {
        string LoggedUsername;
        bool RootAdminAction;
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;
        private System.Timers.Timer debounceTimer;
        private PrintDocument printDocument = new PrintDocument();
        private int currentRow = 0;
        public RecordsForm(string LoggedUsernameConstruct, bool RootAdminActionConstruct)
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            LoggedUsername = LoggedUsernameConstruct;
            RootAdminAction = RootAdminActionConstruct;
            InitializeComponent();
            SearchCon.SelectedIndex = 0;
            InitializeDatePickers();

            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        private void RecordsForm_Load(object sender, EventArgs e)
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
            if (SearchCon.Text.Equals("Operator"))
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {
                    mySqlConnection.Open();
                    string query = "SELECT * FROM helmetharbour.`records` WHERE `Date Time Recorded` BETWEEN @start AND @end AND `Operator` LIKE @search ;";

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
            else if (SearchCon.Text.Equals("Transaction Number"))
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {
                    mySqlConnection.Open();
                    string query = "SELECT * FROM helmetharbour.`records` WHERE `Date Time Recorded` BETWEEN @start AND @end AND `Transaction Num` LIKE @search ;";

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
                    string query = "SELECT * FROM helmetharbour.`records` WHERE `Date Time Recorded` BETWEEN @start AND @end AND `RFID #` LIKE @search ;";

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
                    string query = "SELECT * FROM helmetharbour.`records` WHERE `Date Time Recorded` BETWEEN @start AND @end AND `Slot` LIKE @search ;";

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
            else if (SearchCon.Text.Equals("Record Number"))
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {
                    mySqlConnection.Open();
                    string query = "SELECT * FROM helmetharbour.`records` WHERE `Date Time Recorded` BETWEEN @start AND @end AND `Record_Number` LIKE @search ;";

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
                    string query = "SELECT * FROM helmetharbour.`records` WHERE `Date Time Recorded` BETWEEN @start AND @end;";

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

        private void CreateFClose_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainMinimizebtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void titlebarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
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
        private void printbtn_click(object sender, EventArgs e)
        {
            printDocument.DefaultPageSettings.Landscape = true;
            printDocument.DefaultPageSettings.Margins = new Margins(20, 20, 20, 20);
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDocument;
            preview.ShowDialog();
            if (!RootAdminAction)
            {
                GetUserInfo(LoggedUsername);
                InsertAction(ActionName, EmpNum, "Printed record");
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            int topMargin = e.MarginBounds.Top;
            int leftMargin = e.MarginBounds.Left;
            int yPos = topMargin;
            int cellHeight = 30;
            int totalColumnWidth = 0;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                totalColumnWidth += col.Width;
            float scaleFactor = (float)e.MarginBounds.Width / totalColumnWidth;
            int xPos = leftMargin;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                int colWidth = (int)(col.Width * scaleFactor);
                Rectangle rect = new Rectangle(xPos, yPos, colWidth, cellHeight);
                e.Graphics.FillRectangle(Brushes.LightGray, rect);
                e.Graphics.DrawRectangle(Pens.Black, rect);
                e.Graphics.DrawString(col.HeaderText, dataGridView1.Font, Brushes.Black, rect,
                    new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                xPos += colWidth;
            }
            yPos += cellHeight;
            while (currentRow < dataGridView1.Rows.Count)
            {
                xPos = leftMargin;
                DataGridViewRow row = dataGridView1.Rows[currentRow];

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    int colWidth = (int)(col.Width * scaleFactor);
                    Rectangle rect = new Rectangle(xPos, yPos, colWidth, cellHeight);

                    Brush brush = (currentRow % 2 == 0) ? Brushes.White : Brushes.LightYellow;
                    e.Graphics.FillRectangle(brush, rect);
                    e.Graphics.DrawRectangle(Pens.Black, rect);

                    e.Graphics.DrawString(row.Cells[col.Index].Value?.ToString(), dataGridView1.Font, Brushes.Black, rect,
                        new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    xPos += colWidth;
                }
                currentRow++;
                yPos += cellHeight;

                if (yPos + cellHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
            currentRow = 0;
            e.HasMorePages = false;
        }
        string EmpNum;
        string ActionName = "Records";

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

