using System.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Helmet_Harbour_MK2
{
    public partial class CreateForm : Form
    {
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase;
        public CreateForm()
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            InitializeComponent();
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
            PasswordInc.ForeColor = System.Drawing.Color.Black;
        }
        private void RePassCreate_textbox_clickevent(object sender, EventArgs e)
        {
            if (RePassCreate_textbox.Text.Equals("Re-enter Password:")) RePassCreate_textbox.Text = "";
            RePassCreate_textbox.UseSystemPasswordChar = true;
            RePassCreate_textbox.ForeColor = System.Drawing.Color.Black;
            RePass_bullet.ForeColor = System.Drawing.Color.Black;
            RePassInc.ForeColor = System.Drawing.Color.Black;
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

        private void CreateBtn_clickevent(object sender, EventArgs e)
        {
            try
            {
                if (PassCreate_textbox.Text.Equals(""))
                {
                    Pass_bullet.ForeColor = System.Drawing.Color.Red;
                    PasswordInc.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (!IsPasswordValid(PassCreate_textbox.Text))
                {
                    Pass_bullet.ForeColor = System.Drawing.Color.Red;
                    PasswordInc.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (!PassCreate_textbox.Text.Equals(RePassCreate_textbox.Text))
                {
                    RePass_bullet.ForeColor = System.Drawing.Color.Red;
                    RePassInc.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
                {
                    string query = "INSERT INTO helmetharbour.`accounts` (`Username`, `Password`, `Access`, `Employee ID`, `First Name`, `Last Name`) VALUES (@Username, @Password, 'RootAdmin', @EmpID, @Fname, @Lname)";
                    mySqlConnection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        command.Parameters.AddWithValue("@Username", NameCreate_textbox.Text.ToLower());
                        command.Parameters.AddWithValue("@Password", HashPassword(PassCreate_textbox.Text));
                        command.Parameters.AddWithValue("@EmpID", EmpID_txtbox.Text);
                        command.Parameters.AddWithValue("@Fname", FName_txtbox.Text);
                        command.Parameters.AddWithValue("@Lname", LName_txtbox.Text);

                        command.ExecuteNonQuery();
                    }

                }
                Form5 form5 = new Form5();
                form5.ShowDialog();
                Username = NameCreate_textbox.Text.ToLower();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Account Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public string Username { get; set; }
        private void Form1_Load(object sender, EventArgs e)
        {

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

        private void RePass_bullet_Click(object sender, EventArgs e)
        {
        }

        private void CreateClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateClose_MouseHover(object sender, EventArgs e)
        {
            CreateFClose_Btn.ForeColor = Color.Red;
        }

        private void CreateClose_MouseLeave(object sender, EventArgs e)
        {
            CreateFClose_Btn.ForeColor = Color.Black;
        }

        private void CreateFMinimize_Btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void CreateFMinimize_MouseHover(object sender, EventArgs e)
        {
            CreateMinimizebtn.ForeColor = Color.Blue;
        }

        private void CreateFMinimize_MouseLeave(object sender, EventArgs e)
        {
            CreateMinimizebtn.ForeColor = Color.Black;
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
