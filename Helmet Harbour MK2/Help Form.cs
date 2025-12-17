using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Helmet_Harbour_MK2
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            startbtn.BackColor = SystemColors.ControlLight;
            StartPanel.Visible = false;

            paymentsettbtn.BackColor = SystemColors.ControlLight;
            PaymentsettingsPanel.Visible = false;

            Paymentprocessbtn.BackColor = SystemColors.ControlLight;
            Paypanel.Visible = false;

            Activatecardsbtn.BackColor = SystemColors.ControlLight;
            Activationpanel.Visible = false;

            mastercardbtn.BackColor = SystemColors.ControlLight;
            mastercardpanel.Visible = false;

            editrfidbtn.BackColor = SystemColors.ControlLight;
            Editrfidpanel.Visible = false;

            Accountmanagerbtn.BackColor = SystemColors.ControlLight;
            Accountmanagerpanel.Visible = false;

            recordsbtn.BackColor = SystemColors.ControlLight;
            Recordspanel.Visible = false;

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
        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            startbtn.BackColor = SystemColors.ControlLight;
            StartPanel.Visible = false;
            
            paymentsettbtn.BackColor = SystemColors.ControlLight;
            PaymentsettingsPanel.Visible = false;

            Paymentprocessbtn.BackColor = SystemColors.ControlLight;
            Paypanel.Visible = false;

            Activatecardsbtn.BackColor = SystemColors.ControlLight;
            Activationpanel.Visible = false;

            mastercardbtn.BackColor = SystemColors.ControlLight;
            mastercardpanel.Visible = false;

            editrfidbtn.BackColor = SystemColors.ControlLight;
            Editrfidpanel.Visible = false;

            Accountmanagerbtn.BackColor = SystemColors.ControlLight;
            Accountmanagerpanel.Visible = false;

            recordsbtn.BackColor = SystemColors.ControlLight;
            Recordspanel.Visible = false;

            Button btn = sender as Button;


            switch (btn.Name)
            {
                case "startbtn":
                    startbtn.BackColor = SystemColors.InactiveBorder;
                    StartPanel.Visible = true;
                    break;

                case "paymentsettbtn":
                    paymentsettbtn.BackColor = SystemColors.InactiveBorder;
                    PaymentsettingsPanel.Visible = true;
                    break;

                case "Paymentprocessbtn":
                    Paymentprocessbtn.BackColor = SystemColors.InactiveBorder;
                    Paypanel.Visible = true;
                    break;
                case "Activatecardsbtn":
                    Activatecardsbtn.BackColor = SystemColors.InactiveBorder;
                    Activationpanel.Visible = true;
                    break;
                case "mastercardbtn":
                    mastercardbtn.BackColor = SystemColors.InactiveBorder;
                    mastercardpanel.Visible = true;
                    break;
                case "editrfidbtn":
                    editrfidbtn.BackColor = SystemColors.InactiveBorder;
                    Editrfidpanel.Visible = true;
                    break;
                case "Accountmanagerbtn":
                    Accountmanagerbtn.BackColor = SystemColors.InactiveBorder;
                    Accountmanagerpanel.Visible = true;
                    break;
                case "recordsbtn":
                    recordsbtn.BackColor = SystemColors.InactiveBorder;
                    Recordspanel.Visible = true;
                    break;
                default:
                    MessageBox.Show("Button not recognized");
                    break;
            }
        }
    }
}
