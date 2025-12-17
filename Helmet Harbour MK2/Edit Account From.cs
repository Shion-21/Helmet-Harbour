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
using System.Security.Cryptography;
using MySqlX.XDevAPI.Relational;

namespace Helmet_Harbour_MK2
{
    public partial class EditAccountForm : Form
    {
        int RowIDAccount;
        string InitialName, NewName;
        string LoggedUsername;
        bool RootAdminAction;
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase, accesslevel;

        public EditAccountForm(string Username, string Fname, string Lname, string Access, string EmpID, int RowID, string LoggedUsernameConstruct, bool RootAdminActionConstruct)
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            InitializeComponent();
            NameCreate_textbox.Text = Username;
            FName_txtbox.Text = Fname;
            LName_txtbox.Text = Lname;
            AccessBox.Text = Access;
            EmpID_txtbox.Text = EmpID;
            RowIDAccount = RowID;
            InitialName = Username;
            LoggedUsername = LoggedUsernameConstruct;
            RootAdminAction = RootAdminActionConstruct;
            AccessBox.Enabled = true;
            GetUserAccessLevel(RowIDAccount);
            if (accesslevel.Equals("RootAdmin"))
            {
                AccessBox.Enabled = false;
                AccessBox.Text = "RootAdmin";
            }

        }




        private void NameCreate_textbox_clickevent(object sender, EventArgs e)
        {
            if (NameCreate_textbox.Text.Equals("Username:")) NameCreate_textbox.Text = "";
            NameCreate_textbox.ForeColor = System.Drawing.Color.Black;
        }
        private void PassCreate_textbox_clickevent(object sender, EventArgs e)
        {
            if (PassCreate_textbox.Text.Equals("Password:")) PassCreate_textbox.Text = "";
            PassCreate_textbox.UseSystemPasswordChar = true;
            PassCreate_textbox.ForeColor = System.Drawing.Color.Black;
            Pass_bullet.ForeColor = System.Drawing.Color.Black;
            toolTip1.ForeColor = System.Drawing.Color.Black;
        }
        private void RePassCreate_textbox_clickevent(object sender, EventArgs e)
        {
            if (RePassCreate_textbox.Text.Equals("Re-enter Password:")) RePassCreate_textbox.Text = "";
            RePassCreate_textbox.UseSystemPasswordChar = true;
            RePassCreate_textbox.ForeColor = System.Drawing.Color.Black;
            RePass_bullet.ForeColor = System.Drawing.Color.Black;
            toolTip1.ForeColor = System.Drawing.Color.Black;
        }
        private void FName_txtbox_clickevent(object sender, EventArgs e)
        {
            if (FName_txtbox.Text.Equals("First Name:")) FName_txtbox.Text = "";
            FName_txtbox.ForeColor = System.Drawing.Color.Black;
        }
        private void LName_txtbox_clickevent(object sender, EventArgs e)
        {
            if (LName_txtbox.Text.Equals("Last Name:")) LName_txtbox.Text = "";
            LName_txtbox.ForeColor = System.Drawing.Color.Black;
        }
        private void EmpID_txtbox_clickevent(object sender, EventArgs e)
        {
            if (EmpID_txtbox.Text.Equals("Employee ID:")) EmpID_txtbox.Text = "";
            EmpID_txtbox.ForeColor = System.Drawing.Color.Black;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (PassCreate_textbox.Text.Equals(""))
                {
                    Pass_bullet.ForeColor = System.Drawing.Color.Red;
                    toolTip1.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (!IsPasswordValid(PassCreate_textbox.Text))
                {
                    Pass_bullet.ForeColor = System.Drawing.Color.Red;
                    toolTip1.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (!PassCreate_textbox.Text.Equals(RePassCreate_textbox.Text))
                {
                    RePass_bullet.ForeColor = System.Drawing.Color.Red;
                    toolTip1.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (ExistUsername()) { MessageBox.Show("Username already in use"); return; }
                if (!RootAdminAction)
                {
                    GetUserInfo(LoggedUsername);
                    InsertAction(ActionName, EmpNum, "Edited Employee");
                }

                if (accesslevel.Equals("RootAdmin"))
                {
                    using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                    {
                        string query = "Update helmetharbour.`accounts` SET Username = @Username, Password =  @Password, `Employee ID` = @EmpID, `First Name` = @Fname, `Last Name` = @Lname, Access = @Access WHERE `idAccounts` = @RowID";
                        mySqlConnection.Open();
                        using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                        {
                            command.Parameters.AddWithValue("@Username", NameCreate_textbox.Text.ToLower());
                            command.Parameters.AddWithValue("@Password", HashPassword(PassCreate_textbox.Text));
                            command.Parameters.AddWithValue("@EmpID", EmpID_txtbox.Text);
                            command.Parameters.AddWithValue("@Fname", FName_txtbox.Text);
                            command.Parameters.AddWithValue("@Lname", LName_txtbox.Text);
                            command.Parameters.AddWithValue("@Access", "RootAdmin");
                            command.Parameters.AddWithValue("@RowID", RowIDAccount);
                            command.ExecuteNonQuery();
                        }

                    }
                }
                else
                {
                    using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                    {
                        string query = "Update helmetharbour.`accounts` SET Username = @Username, Password =  @Password, `Employee ID` = @EmpID, `First Name` = @Fname, `Last Name` = @Lname, Access = @Access WHERE `idAccounts` = @RowID";
                        mySqlConnection.Open();
                        using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                        {
                            command.Parameters.AddWithValue("@Username", NameCreate_textbox.Text.ToLower());
                            command.Parameters.AddWithValue("@Password", HashPassword(PassCreate_textbox.Text));
                            command.Parameters.AddWithValue("@EmpID", EmpID_txtbox.Text);
                            command.Parameters.AddWithValue("@Fname", FName_txtbox.Text);
                            command.Parameters.AddWithValue("@Lname", LName_txtbox.Text);
                            command.Parameters.AddWithValue("@Access", AccessBox.Text);
                            command.Parameters.AddWithValue("@RowID", RowIDAccount);
                            command.ExecuteNonQuery();
                        }

                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Account Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsPasswordValid(string password)
        {
            if (password.Length < 8)
            {
                MessageBox.Show("Too short");
                return false;
            }
            bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else if (!char.IsLetterOrDigit(c)) hasSpecial = true;

            }
            if (!hasUpper) MessageBox.Show("Missing uppercase");
            if (!hasLower) MessageBox.Show("Missing lowercase");
            if (!hasDigit) MessageBox.Show("Missing digit");
            if (!hasSpecial) MessageBox.Show("Missing special character");
            return hasUpper && hasLower && hasDigit && hasSpecial;
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
        private void CreateFMinimize_Btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void checktextbox(object sender, EventArgs e)
        {
            if (PassCreate_textbox.Text.Equals(""))
            {
                PassCreate_textbox.Text = "Password:";
                PassCreate_textbox.ForeColor = SystemColors.WindowFrame;
                PassCreate_textbox.UseSystemPasswordChar = false;
            }
            if (RePassCreate_textbox.Text.Equals(""))
            {
                RePassCreate_textbox.Text = "Re-enter Password:";
                RePassCreate_textbox.ForeColor = SystemColors.WindowFrame;
                RePassCreate_textbox.UseSystemPasswordChar = false;
            }
            if (NameCreate_textbox.Text.Equals(""))
            {
                NameCreate_textbox.Text = "Username:";
                NameCreate_textbox.ForeColor = SystemColors.WindowFrame;
            }
            if (FName_txtbox.Text.Equals(""))
            {
                FName_txtbox.Text = "First Name:";
                FName_txtbox.ForeColor = SystemColors.WindowFrame;
            }
            if (LName_txtbox.Text.Equals(""))
            {
                LName_txtbox.Text = "Last Name:";
                LName_txtbox.ForeColor = SystemColors.WindowFrame;
            }
            if (EmpID_txtbox.Text.Equals(""))
            {
                EmpID_txtbox.Text = "Employee ID:";
                EmpID_txtbox.ForeColor = SystemColors.WindowFrame;
            }
        }
        private void returnbtn_Click(object sender, EventArgs e)
        {
            if (!RootAdminAction)
            {
                GetUserInfo(LoggedUsername);
                InsertAction(ActionName, EmpNum, "Edit Canceled");
            }
            this.Close();
        }

        private void EditAccountForm_Load(object sender, EventArgs e)
        {
            AccessBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        bool result;
        private bool ExistUsername()
        {
            if (NameCreate_textbox.Text.ToLower().Equals(InitialName.ToLower()))
            {
                return result = false;
            }
            else
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {
                    string query = "SELECT EXISTS (SELECT 1 FROM `accounts` WHERE `Username` = @Username)";
                    mySqlConnection.Open();
                    using (MySqlCommand cmdexist = new MySqlCommand(query, mySqlConnection))
                    {
                        cmdexist.Parameters.AddWithValue("@Username", NameCreate_textbox.Text.Trim());
                        object result = cmdexist.ExecuteScalar();
                        return result != null && Convert.ToBoolean(result);
                    }
                }
            }


        }
        string EmpNum;
        string ActionName = "Accounts";

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
        private void GetUserAccessLevel(int AccountRow)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "SELECT * FROM helmetharbour.`accounts` WHERE `idAccounts` = @ID";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@ID", AccountRow);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            accesslevel = reader.GetString("Access");
                        }
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
    }
}
