using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace Helmet_Harbour_MK2
{
    public partial class RFIDsForm : Form
    {
        string LoggedUsername;
        bool RootAdminAction;
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;
        public RFIDsForm(string LoggedUsernameConstruct, bool RootAdminActionConstruct)
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            LoggedUsername = LoggedUsernameConstruct;
            RootAdminAction = RootAdminActionConstruct;
            InitializeComponent();
            RFIDsDB.ClearSelection();
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        private void titlebarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }


        private void AddRFID_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "Update helmetharbour.`rfid controller` SET `RFID scan` = '' WHERE `idRFID controller` = 1";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
            AddRFIDForm addRFIDForm = new AddRFIDForm(LoggedUsername, RootAdminAction);
            if (addRFIDForm.ShowDialog() == DialogResult.OK)
            {
                DbLoad();
            }
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (RFIDsDB.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                "Are you sure you want to continue?",
                "Confirmation",
                MessageBoxButtons.YesNo
                );

                if (result == DialogResult.Yes)
                {
                    DataGridViewRow row = RFIDsDB.SelectedRows[0];
                    int ID = Convert.ToInt32(RFIDsDB.SelectedRows[0].Cells["idRFIDs"].Value);

                    using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                    {
                        string query = "Update helmetharbour.`rfids` SET `Status` = 'Deleted' WHERE `idRFIDs` = @id";
                        mySqlConnection.Open();
                        using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                        {
                            command.Parameters.AddWithValue("@id", ID);
                            command.ExecuteNonQuery();
                        }

                    }
                    MessageBox.Show("Deleted");
                    DbLoad();
                    if (!RootAdminAction)
                    {
                        GetUserInfo(LoggedUsername);
                        InsertAction(ActionName, EmpNum, "RFID Deleted");
                    }
                }
                else
                {
                    MessageBox.Show("Action cancelled.");
                }

            }
        }

        private void RFIDsDB_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dataTable = sender as DataGridView;


                if (dataTable.Columns[e.ColumnIndex].Name == "Status")
                {
                    int ID = Convert.ToInt32(RFIDsDB.Rows[e.RowIndex].Cells["idRFIDs"].Value);
                    string Status = dataTable.Rows[e.RowIndex].Cells["Status"].Value?.ToString();
                    using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                    {
                        string query = "Update helmetharbour.`rfids` SET `Status` = @Status, `Failed Attempts` = Case WHEN @Status = 'Active' THEN 0 ELSE `Failed Attempts` END WHERE `idRFIDs` = @id";
                        mySqlConnection.Open();
                        using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                        {
                            command.Parameters.AddWithValue("@id", ID);
                            command.Parameters.AddWithValue("@Status", Status);
                            command.ExecuteNonQuery();
                        }

                    }

                }
            }
        }
        string EmpNum;
        string ActionName = "RFIDs";

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

        private void CreateFClose_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RFIDsForm_Load(object sender, EventArgs e)
        {
            DbLoad();
            RFIDsDB.ClearSelection();
        }
        private void RFIDsDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex != 3)
            {
                RFIDsDB.ClearSelection();
                RFIDsDB.Rows[e.RowIndex].Selected = true;
            }
        }

        private void DbLoad()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {

                string query = "SELECT * FROM helmetharbour.`rfids` WHERE `Status` != 'Deleted'";


                if (!string.IsNullOrWhiteSpace(txtSearch.Text) && comboSearch.SelectedItem != null)
                {
                    string searchcon = comboSearch.SelectedItem.ToString();
                    string columnName = "";
                    switch (searchcon)
                    {
                        case "Card ID":
                            columnName = "idRFIDs";
                            break;
                        case "RFID Number":
                            columnName = "RFID Number";
                            break;
                        case "Status":
                            columnName = "Status";
                            break;
                        case "Activation Time":
                            columnName = "Activation Time";
                            break;
                        case "Plate Number":
                            columnName = "Plate Number";
                            break;
                        case "Holder Name":
                            columnName = "TempHolder";
                            break;
                    }
                    query += $" AND `{columnName}` LIKE @searchText";
                }

                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text) && comboSearch.SelectedItem != null)
                    {
                        command.Parameters.AddWithValue("@searchText", "%" + txtSearch.Text + "%");
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        RFIDsDB.DataSource = dataTable;
                        RFIDsDB.ClearSelection();
                        RFIDsDB.CurrentCell = null;
                    }
                }
            }
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


        private void RFIDsDB_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (RFIDsDB.IsCurrentCellDirty)
            {
                RFIDsDB.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void RFIDsDB_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            RFIDsDB.ClearSelection();
        }
    }
}
