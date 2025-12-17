namespace Helmet_Harbour_MK2
{
    partial class Form4
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
            label2 = new Label();
            Confirmbtn = new Button();
            cancelbtn = new Button();
            RePass_txtbox = new TextBox();
            Pass_txtbox = new TextBox();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            RePass_bullet = new Label();
            Pass_bullet = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(123, 20);
            label2.TabIndex = 3;
            label2.Text = "Forgot password";
            // 
            // Confirmbtn
            // 
            Confirmbtn.BackColor = Color.LightGoldenrodYellow;
            Confirmbtn.FlatStyle = FlatStyle.Popup;
            Confirmbtn.Location = new Point(381, 224);
            Confirmbtn.Name = "Confirmbtn";
            Confirmbtn.Size = new Size(75, 23);
            Confirmbtn.TabIndex = 5;
            Confirmbtn.Text = "Confirm";
            Confirmbtn.UseVisualStyleBackColor = false;
            Confirmbtn.Click += confirm_Click;
            // 
            // cancelbtn
            // 
            cancelbtn.BackColor = Color.LightGoldenrodYellow;
            cancelbtn.FlatStyle = FlatStyle.Popup;
            cancelbtn.Location = new Point(12, 224);
            cancelbtn.Name = "cancelbtn";
            cancelbtn.Size = new Size(75, 23);
            cancelbtn.TabIndex = 6;
            cancelbtn.Text = "Cancel";
            cancelbtn.UseVisualStyleBackColor = false;
            cancelbtn.Click += Cancel_Click;
            // 
            // RePass_txtbox
            // 
            RePass_txtbox.Location = new Point(103, 166);
            RePass_txtbox.MaxLength = 64;
            RePass_txtbox.Name = "RePass_txtbox";
            RePass_txtbox.Size = new Size(253, 23);
            RePass_txtbox.TabIndex = 7;
            // 
            // Pass_txtbox
            // 
            Pass_txtbox.Location = new Point(103, 108);
            Pass_txtbox.MaxLength = 64;
            Pass_txtbox.Name = "Pass_txtbox";
            Pass_txtbox.Size = new Size(253, 23);
            Pass_txtbox.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(158, 51);
            label1.Name = "label1";
            label1.Size = new Size(153, 20);
            label1.TabIndex = 10;
            label1.Text = "Create new password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(103, 148);
            label3.Name = "label3";
            label3.Size = new Size(108, 15);
            label3.TabIndex = 12;
            label3.Text = "Re-enter password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(103, 90);
            label4.Name = "label4";
            label4.Size = new Size(90, 15);
            label4.TabIndex = 13;
            label4.Text = "Enter password:";
            // 
            // RePass_bullet
            // 
            RePass_bullet.AutoSize = true;
            RePass_bullet.Location = new Point(362, 169);
            RePass_bullet.Name = "RePass_bullet";
            RePass_bullet.Size = new Size(12, 15);
            RePass_bullet.TabIndex = 15;
            RePass_bullet.Text = "•";
            // 
            // Pass_bullet
            // 
            Pass_bullet.AutoSize = true;
            Pass_bullet.Location = new Point(362, 111);
            Pass_bullet.Name = "Pass_bullet";
            Pass_bullet.Size = new Size(12, 15);
            Pass_bullet.TabIndex = 14;
            Pass_bullet.Text = "•";
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(468, 259);
            Controls.Add(RePass_bullet);
            Controls.Add(Pass_bullet);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(Pass_txtbox);
            Controls.Add(RePass_txtbox);
            Controls.Add(cancelbtn);
            Controls.Add(Confirmbtn);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form4";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Form4";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button Confirmbtn;
        private Button cancelbtn;
        private TextBox RePass_txtbox;
        private TextBox Pass_txtbox;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label RePass_bullet;
        private Label Pass_bullet;
    }
}