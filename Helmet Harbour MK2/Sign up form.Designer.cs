namespace Helmet_Harbour_MK2
{
    partial class CreateForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateForm));
            NameCreate_textbox = new TextBox();
            pictureBox1 = new PictureBox();
            PassCreate_textbox = new TextBox();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            RePassCreate_textbox = new TextBox();
            Pass_bullet = new Label();
            RePass_bullet = new Label();
            PasswordInc = new ToolTip(components);
            RePassInc = new ToolTip(components);
            CreateFClose_Btn = new Label();
            CreateMinimizebtn = new Label();
            EmpID_txtbox = new TextBox();
            FName_txtbox = new TextBox();
            LName_txtbox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // NameCreate_textbox
            // 
            NameCreate_textbox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameCreate_textbox.ForeColor = SystemColors.WindowFrame;
            NameCreate_textbox.Location = new Point(90, 309);
            NameCreate_textbox.MaxLength = 24;
            NameCreate_textbox.Name = "NameCreate_textbox";
            NameCreate_textbox.Size = new Size(246, 23);
            NameCreate_textbox.TabIndex = 0;
            NameCreate_textbox.Text = "Username:";
            NameCreate_textbox.Enter += NameCreate_textbox_clickevent;
            NameCreate_textbox.KeyPress += invalidsymbol_KeyPress;
            NameCreate_textbox.Leave += checktextbox;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._530815967_748571391111211_2104280294899996801_n_removebg_preview;
            pictureBox1.Location = new Point(280, 65);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(176, 176);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // PassCreate_textbox
            // 
            PassCreate_textbox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PassCreate_textbox.ForeColor = SystemColors.WindowFrame;
            PassCreate_textbox.Location = new Point(90, 362);
            PassCreate_textbox.MaxLength = 64;
            PassCreate_textbox.Name = "PassCreate_textbox";
            PassCreate_textbox.Size = new Size(246, 23);
            PassCreate_textbox.TabIndex = 3;
            PassCreate_textbox.Text = "Password:";
            PassCreate_textbox.Enter += PassCreate_textbox_clickevent;
            PassCreate_textbox.Leave += checktextbox;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(72, 27);
            label2.Name = "label2";
            label2.Size = new Size(162, 21);
            label2.TabIndex = 4;
            label2.Text = "Quadro Technologies";
            // 
            // pictureBox2
            // 
            pictureBox2.ErrorImage = (Image)resources.GetObject("pictureBox2.ErrorImage");
            pictureBox2.Image = Properties.Resources._487561766_1718045169121555_2315165528048067770_n_removebg_preview;
            pictureBox2.InitialImage = (Image)resources.GetObject("pictureBox2.InitialImage");
            pictureBox2.Location = new Point(12, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(54, 50);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(645, 459);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 6;
            label3.Text = "Create";
            label3.Click += CreateBtn_clickevent;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(295, 280);
            label4.Name = "label4";
            label4.Size = new Size(146, 17);
            label4.TabIndex = 7;
            label4.Text = "Create Admin Account";
            // 
            // RePassCreate_textbox
            // 
            RePassCreate_textbox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RePassCreate_textbox.ForeColor = SystemColors.WindowFrame;
            RePassCreate_textbox.Location = new Point(90, 391);
            RePassCreate_textbox.MaxLength = 64;
            RePassCreate_textbox.Name = "RePassCreate_textbox";
            RePassCreate_textbox.Size = new Size(246, 23);
            RePassCreate_textbox.TabIndex = 8;
            RePassCreate_textbox.Text = "Re-enter Password:";
            RePassCreate_textbox.Enter += RePassCreate_textbox_clickevent;
            RePassCreate_textbox.Leave += checktextbox;
            // 
            // Pass_bullet
            // 
            Pass_bullet.AutoSize = true;
            Pass_bullet.Location = new Point(342, 365);
            Pass_bullet.Name = "Pass_bullet";
            Pass_bullet.Size = new Size(12, 15);
            Pass_bullet.TabIndex = 9;
            Pass_bullet.Text = "•";
            PasswordInc.SetToolTip(Pass_bullet, "Password must have:\r\n\r\n• Atleast 8 characters in length\r\n• Atleast 1 Number\r\n• Atleast 1 Uppercase & Lowercase\r\n• Atleast 1 Symbol");
            // 
            // RePass_bullet
            // 
            RePass_bullet.AutoSize = true;
            RePass_bullet.Location = new Point(342, 394);
            RePass_bullet.Name = "RePass_bullet";
            RePass_bullet.Size = new Size(12, 15);
            RePass_bullet.TabIndex = 10;
            RePass_bullet.Text = "•";
            RePassInc.SetToolTip(RePass_bullet, "Password must match");
            RePass_bullet.Click += RePass_bullet_Click;
            // 
            // CreateFClose_Btn
            // 
            CreateFClose_Btn.AutoSize = true;
            CreateFClose_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateFClose_Btn.Location = new Point(705, 9);
            CreateFClose_Btn.Name = "CreateFClose_Btn";
            CreateFClose_Btn.Size = new Size(19, 20);
            CreateFClose_Btn.TabIndex = 11;
            CreateFClose_Btn.Text = "X";
            CreateFClose_Btn.Click += CreateClose_Click;
            CreateFClose_Btn.MouseLeave += CreateClose_MouseLeave;
            CreateFClose_Btn.MouseHover += CreateClose_MouseHover;
            // 
            // CreateMinimizebtn
            // 
            CreateMinimizebtn.AutoSize = true;
            CreateMinimizebtn.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateMinimizebtn.Location = new Point(677, 1);
            CreateMinimizebtn.Name = "CreateMinimizebtn";
            CreateMinimizebtn.Size = new Size(22, 30);
            CreateMinimizebtn.TabIndex = 14;
            CreateMinimizebtn.Text = "-";
            CreateMinimizebtn.Click += CreateFMinimize_Btn_Click;
            CreateMinimizebtn.MouseLeave += CreateFMinimize_MouseLeave;
            CreateMinimizebtn.MouseHover += CreateFMinimize_MouseHover;
            // 
            // EmpID_txtbox
            // 
            EmpID_txtbox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EmpID_txtbox.ForeColor = SystemColors.WindowFrame;
            EmpID_txtbox.Location = new Point(393, 309);
            EmpID_txtbox.MaxLength = 24;
            EmpID_txtbox.Name = "EmpID_txtbox";
            EmpID_txtbox.Size = new Size(246, 23);
            EmpID_txtbox.TabIndex = 0;
            EmpID_txtbox.Text = "Employee ID:";
            EmpID_txtbox.Enter += EmpID_txtbox_clickevent;
            EmpID_txtbox.KeyPress += invalidsymbol_KeyPress;
            EmpID_txtbox.Leave += checktextbox;
            // 
            // FName_txtbox
            // 
            FName_txtbox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FName_txtbox.ForeColor = SystemColors.WindowFrame;
            FName_txtbox.Location = new Point(393, 362);
            FName_txtbox.MaxLength = 24;
            FName_txtbox.Name = "FName_txtbox";
            FName_txtbox.Size = new Size(246, 23);
            FName_txtbox.TabIndex = 3;
            FName_txtbox.Text = "First Name:";
            FName_txtbox.Enter += FName_txtbox_clickevent;
            FName_txtbox.KeyPress += invalidsymbol_KeyPress;
            FName_txtbox.Leave += checktextbox;
            // 
            // LName_txtbox
            // 
            LName_txtbox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LName_txtbox.ForeColor = SystemColors.WindowFrame;
            LName_txtbox.Location = new Point(393, 391);
            LName_txtbox.MaxLength = 24;
            LName_txtbox.Name = "LName_txtbox";
            LName_txtbox.Size = new Size(246, 23);
            LName_txtbox.TabIndex = 8;
            LName_txtbox.Text = "Last Name:";
            LName_txtbox.Enter += LName_txtbox_clickevent;
            LName_txtbox.KeyPress += invalidsymbol_KeyPress;
            LName_txtbox.Leave += checktextbox;
            // 
            // CreateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(736, 515);
            Controls.Add(CreateMinimizebtn);
            Controls.Add(CreateFClose_Btn);
            Controls.Add(RePass_bullet);
            Controls.Add(Pass_bullet);
            Controls.Add(LName_txtbox);
            Controls.Add(RePassCreate_textbox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBox2);
            Controls.Add(FName_txtbox);
            Controls.Add(label2);
            Controls.Add(PassCreate_textbox);
            Controls.Add(pictureBox1);
            Controls.Add(EmpID_txtbox);
            Controls.Add(NameCreate_textbox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CreateForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateForm";
            Load += Form1_Load;
            Click += checktextbox;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameCreate_textbox;
        private PictureBox pictureBox1;
        private TextBox PassCreate_textbox;
        private Label label2;
        private PictureBox pictureBox2;
        private Label label3;
        private Label label4;
        private TextBox RePassCreate_textbox;
        private Label Pass_bullet;
        private Label RePass_bullet;
        private ToolTip PasswordInc;
        private ToolTip RePassInc;
        private Label CreateFClose_Btn;
        private Label CreateMinimizebtn;
        private TextBox EmpID_txtbox;
        private TextBox FName_txtbox;
        private TextBox LName_txtbox;
    }
}
