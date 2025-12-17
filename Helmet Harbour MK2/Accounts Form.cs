using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

namespace Helmet_Harbour_MK2
{
    public partial class AccountsForm : Form
    {
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;
        bool isRootAdmin = false;
        string InUsername;
        string EmpNum;
        string ActionName = "Employee";
        public AccountsForm(bool RootAdminAccess, string LoggedUsername)
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            isRootAdmin = RootAdminAccess;
            InUsername = LoggedUsername;
            InitializeComponent();
        }
        
        private void Addbtn_Click(object sender, EventArgs e)
        {
            Emp_addForm emp_AddForm = new Emp_addForm(InUsername);
            if (emp_AddForm.ShowDialog() == DialogResult.OK)
            {
                if (isRootAdmin)
                {
                    LoadTableRootAdmin();
                }
                else
                {
                    LoadTableAdmin();
                    GetUserInfo(InUsername);
                }

            }
        }

        private void AccountsForm_Load(object sender, EventArgs e)
        {
            if (isRootAdmin)
            {
                LoadTableRootAdmin();
            }
            else
            {
                LoadTableAdmin();
            }
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, AccountDB, new object[] { true });
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            if (AccountDB.SelectedRows.Count == 0)
            {
                MessageBox.Show("No account selected.");
                return;
            }
            if (CheckSubAdmin())
            {
                if (!InUsername.Equals(AccountDB.SelectedRows[0].Cells["Username"].Value.ToString()))
                {
                    DataGridViewRow row = AccountDB.SelectedRows[0];
                    string AccessLevel = AccountDB.SelectedRows[0].Cells["Access"].Value.ToString();
                    if (AccessLevel.Equals("Admin"))
                    {
                        MessageBox.Show("Cannot Edit Admin");
                        return;
                    }
                }
            }

            if (AccountDB.SelectedRows.Count > 0)
            {
                DataGridViewRow row = AccountDB.SelectedRows[0];
                string Username = row.Cells["Username"].Value.ToString();
                string Fname = row.Cells["FirstName"].Value.ToString();
                string Lname = row.Cells["LastName"].Value.ToString();
                string EmpID = row.Cells["Employee_ID"].Value.ToString();
                string Access = row.Cells["Access"].Value.ToString();
                int ID = Convert.ToInt32(AccountDB.SelectedRows[0].Cells["idAccounts"].Value);
                EditAccountForm editAccountForm = new EditAccountForm(Username, Fname, Lname, Access, EmpID, ID, InUsername, isRootAdmin);
                if (editAccountForm.ShowDialog() == DialogResult.OK)
                {
                    if (isRootAdmin)
                    {
                        LoadTableRootAdmin();
                    }
                    else
                    {
                        LoadTableAdmin();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (AccountDB.SelectedRows.Count == 0)
            {
                MessageBox.Show("No account selected.");
                return;
            }
            if (InUsername.Equals(AccountDB.SelectedRows[0].Cells["Username"].Value.ToString()))
            {
                MessageBox.Show("Cannot Delete Self");
                return;
            }

            if (CheckSubAdmin())
            {
                DataGridViewRow row = AccountDB.SelectedRows[0];
                string AccessLevel = AccountDB.SelectedRows[0].Cells["Access"].Value.ToString();
                if (AccessLevel.Equals("Admin"))
                {
                    MessageBox.Show("Cannot Delete Admin");
                    return;
                }
            }

            DialogResult result = MessageBox.Show(
            "Are you sure you want to continue?",
            "Confirmation",
            MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                DataGridViewRow row = AccountDB.SelectedRows[0];
                int ID = Convert.ToInt32(AccountDB.SelectedRows[0].Cells["idAccounts"].Value);

                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {
                    string query = "DELETE FROM helmetharbour.`accounts` WHERE `idAccounts`= @id";
                    mySqlConnection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        command.Parameters.AddWithValue("@id", ID);
                        command.ExecuteNonQuery();
                    }

                }
                MessageBox.Show("Deleted");
                if (isRootAdmin)
                {
                    LoadTableRootAdmin();
                }
                else
                {
                    InsertAction(ActionName, EmpNum, "Employee deleted");
                    LoadTableAdmin();
                }
            }
            else
            {
                MessageBox.Show("Action cancelled.");
            }

        }


        private void CreateFClose_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadTableRootAdmin()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {

                string query = "SELECT * FROM helmetharbour.`accounts`";


                if (!string.IsNullOrWhiteSpace(txtSearch.Text) && comboSearch.SelectedItem != null)
                {
                    string searchcon = comboSearch.SelectedItem.ToString();
                    string columnName = "";
                    switch (searchcon)
                    {
                        case "Username":
                            columnName = "Username";
                            break;
                        case "Employee ID":
                            columnName = "Employee ID";
                            break;
                        case "Firstname":
                            columnName = "First Name";
                            break;
                        case "Lastname":
                            columnName = "Last Name";
                            break;
                        case "Access":
                            columnName = "Access";
                            break;
                        case "Remarks":
                            columnName = "Remarks";
                            break;
                    }
                    query += $" WHERE `{columnName}` LIKE @searchText";
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
                        AccountDB.DataSource = dataTable;
                        AccountDB.ClearSelection();
                        AccountDB.CurrentCell = null;
                    }
                }
            }
        }
        private void LoadTableAdmin()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {

                string query = "SELECT * FROM helmetharbour.`accounts` WHERE `Access` != 'RootAdmin' ";


                if (!string.IsNullOrWhiteSpace(txtSearch.Text) && comboSearch.SelectedItem != null)
                {
                    string searchcon = comboSearch.SelectedItem.ToString();
                    string columnName = "";
                    switch (searchcon)
                    {
                        case "Username":
                            columnName = "Username";
                            break;
                        case "Employee ID":
                            columnName = "Employee ID";
                            break;
                        case "Firstname":
                            columnName = "First Name";
                            break;
                        case "Lastname":
                            columnName = "Last Name";
                            break;
                        case "Access":
                            columnName = "Access";
                            break;
                        case "Remarks":
                            columnName = "Remarks";
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
                        AccountDB.DataSource = dataTable;
                        AccountDB.ClearSelection();
                        AccountDB.CurrentCell = null;
                    }
                }
            }
        }

        private void LoadTableSubAdmin()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {

                string query = "SELECT * FROM helmetharbour.`accounts` WHERE `Access` != 'RootAdmin' AND `Access` != 'Admin' ";


                if (!string.IsNullOrWhiteSpace(txtSearch.Text) && comboSearch.SelectedItem != null)
                {
                    string searchcon = comboSearch.SelectedItem.ToString();
                    string columnName = "";
                    switch (searchcon)
                    {
                        case "Username":
                            columnName = "Username";
                            break;
                        case "Employee ID":
                            columnName = "Employee ID";
                            break;
                        case "Firstname":
                            columnName = "First Name";
                            break;
                        case "Lastname":
                            columnName = "Last Name";
                            break;
                        case "Access":
                            columnName = "Access";
                            break;
                        case "Remarks":
                            columnName = "Remarks";
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
                        AccountDB.DataSource = dataTable;
                        AccountDB.ClearSelection();
                        AccountDB.CurrentCell = null;
                    }
                }
            }
        }
        string IsSubAdmin = string.Empty;
        private bool CheckSubAdmin()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "SELECT `Remarks` FROM helmetharbour.`accounts` WHERE `Username` = @Username";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@Username", InUsername);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsSubAdmin = reader["Remarks"].ToString();
                            if (IsSubAdmin.Equals("SubAdmin"))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
        }
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
                    command.Parameters.AddWithValue("@Username", InUsername);
                    command.Parameters.AddWithValue("@Action", Action);
                    command.Parameters.AddWithValue("@Remark", Remark);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AccountDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AccountDB.ClearSelection();
                AccountDB.Rows[e.RowIndex].Selected = true;
            }
        }

        private void MainMinimizebtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void invalidsymbol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
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
