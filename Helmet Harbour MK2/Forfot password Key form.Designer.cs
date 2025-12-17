namespace Helmet_Harbour_MK2
{
    partial class Form3
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
            Key_txtbox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            confirmbtn = new Button();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // Key_txtbox
            // 
            Key_txtbox.Location = new Point(74, 122);
            Key_txtbox.MaxLength = 32;
            Key_txtbox.Name = "Key_txtbox";
            Key_txtbox.Size = new Size(320, 23);
            Key_txtbox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(74, 104);
            label1.Name = "label1";
            label1.Size = new Size(69, 17);
            label1.TabIndex = 1;
            label1.Text = "Enter Key:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(123, 20);
            label2.TabIndex = 2;
            label2.Text = "Forgot password";
            // 
            // button1
            // 
            button1.BackColor = Color.LightGoldenrodYellow;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(12, 224);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Return";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Return_Click;
            // 
            // confirmbtn
            // 
            confirmbtn.BackColor = Color.LightGoldenrodYellow;
            confirmbtn.FlatStyle = FlatStyle.Popup;
            confirmbtn.Location = new Point(381, 224);
            confirmbtn.Name = "confirmbtn";
            confirmbtn.Size = new Size(75, 23);
            confirmbtn.TabIndex = 4;
            confirmbtn.Text = "Confirm";
            confirmbtn.UseVisualStyleBackColor = false;
            confirmbtn.Click += confirmbtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(101, 59);
            label3.Name = "label3";
            label3.Size = new Size(108, 15);
            label3.TabIndex = 5;
            label3.Text = "For admin use only";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(79, 53);
            label4.Name = "label4";
            label4.Size = new Size(18, 26);
            label4.TabIndex = 6;
            label4.Text = "!";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(468, 259);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(confirmbtn);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Key_txtbox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form3";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Key_txtbox;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button confirmbtn;
        private Label label3;
        private Label label4;
    }
}