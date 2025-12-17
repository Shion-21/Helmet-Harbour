namespace Helmet_Harbour_MK2
{
    partial class LoginForm
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
            pictureBox2 = new PictureBox();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            PassTextbox = new TextBox();
            NameTextbox = new TextBox();
            forgotbtn = new Label();
            Loginbtn = new Button();
            LoginMinimizebtn = new Label();
            LoginFClose_Btn = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources._487561766_1718045169121555_2315165528048067770_n_removebg_preview;
            pictureBox2.Location = new Point(12, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(54, 50);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(72, 27);
            label2.Name = "label2";
            label2.Size = new Size(162, 21);
            label2.TabIndex = 8;
            label2.Text = "Quadro Technologies";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._530815967_748571391111211_2104280294899996801_n;
            pictureBox1.Location = new Point(280, 90);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(176, 176);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // PassTextbox
            // 
            PassTextbox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PassTextbox.ForeColor = SystemColors.WindowFrame;
            PassTextbox.Location = new Point(245, 381);
            PassTextbox.MaxLength = 64;
            PassTextbox.Name = "PassTextbox";
            PassTextbox.Size = new Size(246, 23);
            PassTextbox.TabIndex = 11;
            PassTextbox.Text = "Password:";
            PassTextbox.Enter += PassTextbox_clickevent;
            PassTextbox.Leave += checktextbox;
            // 
            // NameTextbox
            // 
            NameTextbox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameTextbox.ForeColor = SystemColors.WindowFrame;
            NameTextbox.Location = new Point(245, 325);
            NameTextbox.MaxLength = 24;
            NameTextbox.Name = "NameTextbox";
            NameTextbox.Size = new Size(246, 23);
            NameTextbox.TabIndex = 10;
            NameTextbox.Text = "Username:";
            NameTextbox.Enter += NameTextbox_clickevent;
            NameTextbox.KeyPress += this.invalidsymbol_KeyPress;
            NameTextbox.Leave += checktextbox;
            // 
            // forgotbtn
            // 
            forgotbtn.AutoSize = true;
            forgotbtn.Cursor = Cursors.Hand;
            forgotbtn.Font = new Font("Segoe UI Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            forgotbtn.Location = new Point(245, 410);
            forgotbtn.Name = "forgotbtn";
            forgotbtn.Size = new Size(118, 13);
            forgotbtn.TabIndex = 12;
            forgotbtn.Text = "Forgot admin password?";
            forgotbtn.Click += Forgotbtn_Click;
            forgotbtn.MouseLeave += forgotbtn_MouseLeave;
            forgotbtn.MouseHover += forgotbtn_MouseHover;
            // 
            // Loginbtn
            // 
            Loginbtn.BackColor = Color.LightGoldenrodYellow;
            Loginbtn.FlatAppearance.BorderColor = Color.White;
            Loginbtn.FlatStyle = FlatStyle.Flat;
            Loginbtn.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Loginbtn.Location = new Point(418, 410);
            Loginbtn.Name = "Loginbtn";
            Loginbtn.Size = new Size(73, 24);
            Loginbtn.TabIndex = 13;
            Loginbtn.Text = "Login";
            Loginbtn.UseVisualStyleBackColor = false;
            Loginbtn.Click += Login_Click;
            // 
            // LoginMinimizebtn
            // 
            LoginMinimizebtn.AutoSize = true;
            LoginMinimizebtn.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginMinimizebtn.Location = new Point(677, 1);
            LoginMinimizebtn.Name = "LoginMinimizebtn";
            LoginMinimizebtn.Size = new Size(22, 30);
            LoginMinimizebtn.TabIndex = 16;
            LoginMinimizebtn.Text = "-";
            LoginMinimizebtn.Click += LoginFMinimize_Btn_Click;
            LoginMinimizebtn.MouseLeave += LoginFMinimize_MouseLeave;
            LoginMinimizebtn.MouseHover += LoginFMinimize_MouseHover;
            // 
            // LoginFClose_Btn
            // 
            LoginFClose_Btn.AutoSize = true;
            LoginFClose_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginFClose_Btn.Location = new Point(705, 9);
            LoginFClose_Btn.Name = "LoginFClose_Btn";
            LoginFClose_Btn.Size = new Size(19, 20);
            LoginFClose_Btn.TabIndex = 15;
            LoginFClose_Btn.Text = "X";
            LoginFClose_Btn.Click += LoginFClose_Btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(342, 290);
            label1.Name = "label1";
            label1.Size = new Size(53, 21);
            label1.TabIndex = 17;
            label1.Text = "Login";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(736, 515);
            Controls.Add(label1);
            Controls.Add(LoginMinimizebtn);
            Controls.Add(LoginFClose_Btn);
            Controls.Add(Loginbtn);
            Controls.Add(forgotbtn);
            Controls.Add(PassTextbox);
            Controls.Add(NameTextbox);
            Controls.Add(pictureBox2);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private Label label2;
        private PictureBox pictureBox1;
        private TextBox PassTextbox;
        private TextBox NameTextbox;
        private Label forgotbtn;
        private Button Loginbtn;
        private Label LoginMinimizebtn;
        private Label LoginFClose_Btn;
        private Label label1;
    }
}