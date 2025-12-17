namespace Helmet_Harbour_MK2
{
    partial class EditAccountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            RePass_bullet = new Label();
            Pass_bullet = new Label();
            LName_txtbox = new TextBox();
            RePassCreate_textbox = new TextBox();
            FName_txtbox = new TextBox();
            PassCreate_textbox = new TextBox();
            EmpID_txtbox = new TextBox();
            NameCreate_textbox = new TextBox();
            Returnbtn = new Button();
            Confirmbtn = new Button();
            toolTip1 = new ToolTip(components);
            AccessBox = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 255, 128);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(591, 35);
            panel1.TabIndex = 30;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.edit_black;
            pictureBox1.Location = new Point(4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 27);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(45, 9);
            label3.Name = "label3";
            label3.Size = new Size(89, 19);
            label3.TabIndex = 3;
            label3.Text = "Edit Account";
            // 
            // RePass_bullet
            // 
            RePass_bullet.AutoSize = true;
            RePass_bullet.Location = new Point(264, 168);
            RePass_bullet.Name = "RePass_bullet";
            RePass_bullet.Size = new Size(12, 15);
            RePass_bullet.TabIndex = 29;
            RePass_bullet.Text = "•";
            toolTip1.SetToolTip(RePass_bullet, "Password must match");
            // 
            // Pass_bullet
            // 
            Pass_bullet.AutoSize = true;
            Pass_bullet.Location = new Point(264, 139);
            Pass_bullet.Name = "Pass_bullet";
            Pass_bullet.Size = new Size(12, 15);
            Pass_bullet.TabIndex = 28;
            Pass_bullet.Text = "•";
            toolTip1.SetToolTip(Pass_bullet, "Password must have:\r\n\r\n• Atleast 8 characters in length\r\n• Atleast 1 Number\r\n• Atleast 1 Uppercase \r\n• Atleast 1 Lowercase\r\n• Atleast 1 Symbol\r\n\r\n");
            // 
            // LName_txtbox
            // 
            LName_txtbox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LName_txtbox.ForeColor = SystemColors.WindowFrame;
            LName_txtbox.Location = new Point(333, 136);
            LName_txtbox.MaxLength = 24;
            LName_txtbox.Name = "LName_txtbox";
            LName_txtbox.Size = new Size(246, 23);
            LName_txtbox.TabIndex = 26;
            LName_txtbox.Text = "Last Name:";
            LName_txtbox.Enter += LName_txtbox_clickevent;
            LName_txtbox.KeyPress += invalidsymbol_KeyPress;
            LName_txtbox.Leave += checktextbox;
            // 
            // RePassCreate_textbox
            // 
            RePassCreate_textbox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RePassCreate_textbox.ForeColor = SystemColors.WindowFrame;
            RePassCreate_textbox.Location = new Point(12, 165);
            RePassCreate_textbox.MaxLength = 64;
            RePassCreate_textbox.Name = "RePassCreate_textbox";
            RePassCreate_textbox.Size = new Size(246, 23);
            RePassCreate_textbox.TabIndex = 27;
            RePassCreate_textbox.Text = "Re-enter Password:";
            RePassCreate_textbox.Enter += RePassCreate_textbox_clickevent;
            RePassCreate_textbox.KeyPress += invalidsymbol_KeyPress;
            RePassCreate_textbox.Leave += checktextbox;
            // 
            // FName_txtbox
            // 
            FName_txtbox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FName_txtbox.ForeColor = SystemColors.WindowFrame;
            FName_txtbox.Location = new Point(333, 107);
            FName_txtbox.MaxLength = 24;
            FName_txtbox.Name = "FName_txtbox";
            FName_txtbox.Size = new Size(246, 23);
            FName_txtbox.TabIndex = 24;
            FName_txtbox.Text = "First Name:";
            FName_txtbox.Enter += FName_txtbox_clickevent;
            FName_txtbox.KeyPress += invalidsymbol_KeyPress;
            FName_txtbox.Leave += checktextbox;
            // 
            // PassCreate_textbox
            // 
            PassCreate_textbox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PassCreate_textbox.ForeColor = SystemColors.WindowFrame;
            PassCreate_textbox.Location = new Point(12, 136);
            PassCreate_textbox.MaxLength = 64;
            PassCreate_textbox.Name = "PassCreate_textbox";
            PassCreate_textbox.Size = new Size(246, 23);
            PassCreate_textbox.TabIndex = 25;
            PassCreate_textbox.Text = "Password:";
            PassCreate_textbox.Enter += PassCreate_textbox_clickevent;
            PassCreate_textbox.KeyPress += invalidsymbol_KeyPress;
            PassCreate_textbox.Leave += checktextbox;
            // 
            // EmpID_txtbox
            // 
            EmpID_txtbox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EmpID_txtbox.ForeColor = SystemColors.WindowFrame;
            EmpID_txtbox.Location = new Point(333, 78);
            EmpID_txtbox.MaxLength = 24;
            EmpID_txtbox.Name = "EmpID_txtbox";
            EmpID_txtbox.Size = new Size(246, 23);
            EmpID_txtbox.TabIndex = 22;
            EmpID_txtbox.Text = "Employee ID:";
            EmpID_txtbox.Enter += EmpID_txtbox_clickevent;
            EmpID_txtbox.KeyPress += invalidsymbol_KeyPress;
            EmpID_txtbox.Leave += checktextbox;
            // 
            // NameCreate_textbox
            // 
            NameCreate_textbox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameCreate_textbox.ForeColor = SystemColors.WindowFrame;
            NameCreate_textbox.Location = new Point(12, 78);
            NameCreate_textbox.MaxLength = 24;
            NameCreate_textbox.Name = "NameCreate_textbox";
            NameCreate_textbox.Size = new Size(246, 23);
            NameCreate_textbox.TabIndex = 23;
            NameCreate_textbox.Text = "Username:";
            NameCreate_textbox.Enter += NameCreate_textbox_clickevent;
            NameCreate_textbox.KeyPress += invalidsymbol_KeyPress;
            NameCreate_textbox.Leave += checktextbox;
            // 
            // Returnbtn
            // 
            Returnbtn.BackColor = Color.LightGoldenrodYellow;
            Returnbtn.FlatStyle = FlatStyle.Flat;
            Returnbtn.Location = new Point(12, 220);
            Returnbtn.Name = "Returnbtn";
            Returnbtn.Size = new Size(75, 23);
            Returnbtn.TabIndex = 31;
            Returnbtn.Text = "Return";
            Returnbtn.UseVisualStyleBackColor = false;
            Returnbtn.Click += returnbtn_Click;
            // 
            // Confirmbtn
            // 
            Confirmbtn.BackColor = Color.LightGoldenrodYellow;
            Confirmbtn.FlatStyle = FlatStyle.Flat;
            Confirmbtn.Location = new Point(504, 220);
            Confirmbtn.Name = "Confirmbtn";
            Confirmbtn.Size = new Size(75, 23);
            Confirmbtn.TabIndex = 32;
            Confirmbtn.Text = "Confirm";
            Confirmbtn.UseVisualStyleBackColor = false;
            Confirmbtn.Click += Add_Click;
            // 
            // AccessBox
            // 
            AccessBox.ForeColor = SystemColors.WindowFrame;
            AccessBox.FormattingEnabled = true;
            AccessBox.Items.AddRange(new object[] { "Admin", "User" });
            AccessBox.Location = new Point(333, 165);
            AccessBox.Name = "AccessBox";
            AccessBox.Size = new Size(246, 23);
            AccessBox.TabIndex = 33;
            AccessBox.Text = "Access Level";
            AccessBox.Leave += checktextbox;
            // 
            // EditAccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(591, 255);
            Controls.Add(panel1);
            Controls.Add(RePass_bullet);
            Controls.Add(Pass_bullet);
            Controls.Add(LName_txtbox);
            Controls.Add(RePassCreate_textbox);
            Controls.Add(FName_txtbox);
            Controls.Add(PassCreate_textbox);
            Controls.Add(EmpID_txtbox);
            Controls.Add(NameCreate_textbox);
            Controls.Add(Returnbtn);
            Controls.Add(Confirmbtn);
            Controls.Add(AccessBox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditAccountForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit_AccountForm";
            Load += EditAccountForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label3;
        private Label RePass_bullet;
        private ToolTip toolTip1;
        private Label Pass_bullet;
        private TextBox LName_txtbox;
        private TextBox RePassCreate_textbox;
        private TextBox FName_txtbox;
        private TextBox PassCreate_textbox;
        private TextBox EmpID_txtbox;
        private TextBox NameCreate_textbox;
        private Button Returnbtn;
        private Button Confirmbtn;
        private ComboBox AccessBox;
    }
}