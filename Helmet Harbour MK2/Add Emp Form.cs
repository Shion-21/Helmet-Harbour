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
using MySqlX.XDevAPI.Common;
using Google.Protobuf.WellKnownTypes;
using System.Runtime.InteropServices;

namespace Helmet_Harbour_MK2
{
    public partial class Emp_addForm : Form
    {
        string LoggedUser;
        string ActionName = "Employee";
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;
        public Emp_addForm(string InUsername)
        {
            LoggedUser = InUsername;
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            InitializeComponent();
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
        private void button1_Click(object sender, EventArgs e)
        {

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
            Pass_bullet.ForeColor = System.Drawing.Color.Black;
        }
        private void RePassCreate_textbox_clickevent(object sender, EventArgs e)
        {
            if (RePassCreate_textbox.Text.Equals("Re-enter Password:")) RePassCreate_textbox.Text = "";
            RePassCreate_textbox.UseSystemPasswordChar = true;
            RePassCreate_textbox.ForeColor = System.Drawing.Color.Black;
            RePass_bullet.ForeColor = System.Drawing.Color.Black;
            RePass_bullet.ForeColor = System.Drawing.Color.Black;
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
                    Pass_bullet.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (!IsPasswordValid(PassCreate_textbox.Text))
                {
                    Pass_bullet.ForeColor = System.Drawing.Color.Red;
                    Pass_bullet.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (!PassCreate_textbox.Text.Equals(RePassCreate_textbox.Text))
                {
                    RePass_bullet.ForeColor = System.Drawing.Color.Red;
                    RePass_bullet.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (ExistUsername())
                {
                    MessageBox.Show("Username already in use");
                    return;
                }
                if (CheckRootAdmin())
                {
                    using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                    {
                        string query = "INSERT INTO helmetharbour.`accounts` (`Username`, `Password`, `Access`, `Employee ID`, `First Name`, `Last Name`) VALUES (@Username, @Password, @Access, @EmpID, @Fname, @Lname)";
                        mySqlConnection.Open();
                        using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                        {
                            command.Parameters.AddWithValue("@Username", NameCreate_textbox.Text.ToLower().Trim());
                            command.Parameters.AddWithValue("@Password", HashPassword(PassCreate_textbox.Text));
                            command.Parameters.AddWithValue("@EmpID", EmpID_txtbox.Text.Trim());
                            command.Parameters.AddWithValue("@Fname", FName_txtbox.Text.Trim());
                            command.Parameters.AddWithValue("@Lname", LName_txtbox.Text.Trim());
                            command.Parameters.AddWithValue("@Access", AccessBox.Text.Trim());

                            command.ExecuteNonQuery();
                        }

                    }
                }
                else if (CheckSubAdmin())
                {
                    using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                    {
                        string query = "INSERT INTO helmetharbour.`accounts` (`Username`, `Password`, `Access`, `Employee ID`, `First Name`, `Last Name`, `Remarks`) VALUES (@Username, @Password, @Access, @EmpID, @Fname, @Lname, @Remarks)";
                        mySqlConnection.Open();
                        using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                        {
                            command.Parameters.AddWithValue("@Username", NameCreate_textbox.Text.ToLower().Trim());
                            command.Parameters.AddWithValue("@Password", HashPassword(PassCreate_textbox.Text));
                            command.Parameters.AddWithValue("@EmpID", EmpID_txtbox.Text.Trim());
                            command.Parameters.AddWithValue("@Fname", FName_txtbox.Text.Trim());
                            command.Parameters.AddWithValue("@Lname", LName_txtbox.Text.Trim());
                            string Accesslevel;
                            string RemarkAccess = string.Empty;
                            if (AccessBox.Text.Equals("Admin"))
                            {
                                MessageBox.Show("Cannot Create Admin Account");
                                return;
                            }
                            else
                            {
                                Accesslevel = "User";

                            }
                            command.Parameters.AddWithValue("@Access", Accesslevel);
                            command.Parameters.AddWithValue("@Remarks", RemarkAccess);

                            command.ExecuteNonQuery();
                        }

                    }
                }
                else if (CheckAdmin())
                {
                    using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                    {
                        string query = "INSERT INTO helmetharbour.`accounts` (`Username`, `Password`, `Access`, `Employee ID`, `First Name`, `Last Name`, `Remarks`) VALUES (@Username, @Password, @Access, @EmpID, @Fname, @Lname, @Remarks)";
                        mySqlConnection.Open();
                        using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                        {
                            command.Parameters.AddWithValue("@Username", NameCreate_textbox.Text.ToLower().Trim());
                            command.Parameters.AddWithValue("@Password", HashPassword(PassCreate_textbox.Text));
                            command.Parameters.AddWithValue("@EmpID", EmpID_txtbox.Text.Trim());
                            command.Parameters.AddWithValue("@Fname", FName_txtbox.Text.Trim());
                            command.Parameters.AddWithValue("@Lname", LName_txtbox.Text.Trim());
                            string RemarkAccess = string.Empty;

                            command.Parameters.AddWithValue("@Access", "Admin");
                            command.Parameters.AddWithValue("@Remarks", "SubAdmin");

                            command.ExecuteNonQuery();
                        }

                    }
                }

                this.DialogResult = DialogResult.OK;
                if (!CheckRootAdmin())
                {
                    GetUserInfo(LoggedUser);
                    InsertAction(ActionName, EmpNum, "Added Employee");
                }
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
            if (!CheckRootAdmin())
            {
                GetUserInfo(LoggedUser);
                InsertAction(ActionName, EmpNum, "Add employee canceled");
            }
            this.Close();
        }

        private void Emp_addForm_Load(object sender, EventArgs e)
        {
            AccessBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private bool ExistUsername()
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
        string IsSubAdmin, IsRootAdmin, IsAdmin;
        private bool CheckSubAdmin()
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {
                    string query = "SELECT `Remarks` FROM helmetharbour.`accounts` WHERE `Username` = @Username";
                    mySqlConnection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        command.Parameters.AddWithValue("@Username", LoggedUser);
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
                                return false;
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("User Does not Exist");
                return false;
            }
        }
        private bool CheckRootAdmin()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "SELECT `Access` FROM helmetharbour.`accounts` WHERE `Username` = @Username";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@Username", LoggedUser);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsAdmin = reader["Access"].ToString();
                            if (IsAdmin.Equals("RootAdmin"))
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
                            return false;
                        }
                    }
                }
            }
        }
        string EmpNum;
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
                    command.Parameters.AddWithValue("@Username", LoggedUser);
                    command.Parameters.AddWithValue("@Action", Action);
                    command.Parameters.AddWithValue("@Remark", Remark);
                    command.ExecuteNonQuery();
                }
            }
        }
        private bool CheckAdmin()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "SELECT `Access` FROM helmetharbour.`accounts` WHERE `Username` = @Username";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@Username", LoggedUser);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsRootAdmin = reader["Access"].ToString();
                            if (IsRootAdmin.Equals("Admin"))
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
                            return false;
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
