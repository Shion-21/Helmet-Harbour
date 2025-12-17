namespace Helmet_Harbour_MK2
{
    partial class PayConForm
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
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            Cancelbtn = new Button();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            Feelbl = new Label();
            Durationlbl = new Label();
            Slotlbl = new Label();
            Confirmbtn = new Button();
            label5 = new Label();
            Amount_Received = new TextBox();
            printercomboBox = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            Platelbl = new Label();
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
            panel1.Size = new Size(468, 35);
            panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.payments_24dp_000000_FILL0_wght400_GRAD0_opsz24;
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
            label3.Size = new Size(63, 19);
            label3.TabIndex = 3;
            label3.Text = "Payment";
            // 
            // Cancelbtn
            // 
            Cancelbtn.BackColor = Color.LightGoldenrodYellow;
            Cancelbtn.FlatStyle = FlatStyle.Popup;
            Cancelbtn.Location = new Point(12, 224);
            Cancelbtn.Name = "Cancelbtn";
            Cancelbtn.Size = new Size(75, 23);
            Cancelbtn.TabIndex = 8;
            Cancelbtn.Text = "Cancel";
            Cancelbtn.UseVisualStyleBackColor = false;
            Cancelbtn.Click += Cancelbtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.Location = new Point(27, 71);
            label1.Name = "label1";
            label1.Size = new Size(31, 17);
            label1.TabIndex = 9;
            label1.Text = "Slot";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.Location = new Point(27, 103);
            label2.Name = "label2";
            label2.Size = new Size(29, 17);
            label2.TabIndex = 9;
            label2.Text = "Fee";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.Location = new Point(27, 135);
            label4.Name = "label4";
            label4.Size = new Size(94, 17);
            label4.TabIndex = 9;
            label4.Text = "Total Duration";
            // 
            // Feelbl
            // 
            Feelbl.AutoSize = true;
            Feelbl.Location = new Point(154, 105);
            Feelbl.Name = "Feelbl";
            Feelbl.Size = new Size(38, 15);
            Feelbl.TabIndex = 9;
            Feelbl.Text = "label1";
            // 
            // Durationlbl
            // 
            Durationlbl.AutoSize = true;
            Durationlbl.Location = new Point(154, 137);
            Durationlbl.Name = "Durationlbl";
            Durationlbl.Size = new Size(38, 15);
            Durationlbl.TabIndex = 9;
            Durationlbl.Text = "label1";
            // 
            // Slotlbl
            // 
            Slotlbl.AutoSize = true;
            Slotlbl.Location = new Point(154, 73);
            Slotlbl.Name = "Slotlbl";
            Slotlbl.Size = new Size(38, 15);
            Slotlbl.TabIndex = 9;
            Slotlbl.Text = "label1";
            Slotlbl.Click += Slotlbl_Click;
            // 
            // Confirmbtn
            // 
            Confirmbtn.BackColor = Color.LightGoldenrodYellow;
            Confirmbtn.FlatStyle = FlatStyle.Popup;
            Confirmbtn.Location = new Point(381, 224);
            Confirmbtn.Name = "Confirmbtn";
            Confirmbtn.Size = new Size(75, 23);
            Confirmbtn.TabIndex = 10;
            Confirmbtn.Text = "Confirm";
            Confirmbtn.UseVisualStyleBackColor = false;
            Confirmbtn.Click += Confirmbtn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label5.Location = new Point(287, 71);
            label5.Name = "label5";
            label5.Size = new Size(118, 17);
            label5.TabIndex = 9;
            label5.Text = "Amount Received:";
            // 
            // Amount_Received
            // 
            Amount_Received.Location = new Point(312, 91);
            Amount_Received.MaxLength = 6;
            Amount_Received.Name = "Amount_Received";
            Amount_Received.Size = new Size(127, 23);
            Amount_Received.TabIndex = 11;
            Amount_Received.TextChanged += Amount_Received_TextChanged;
            Amount_Received.KeyPress += invalidsymbol_KeyPress;
            // 
            // printercomboBox
            // 
            printercomboBox.FormattingEnabled = true;
            printercomboBox.Location = new Point(287, 163);
            printercomboBox.Name = "printercomboBox";
            printercomboBox.Size = new Size(152, 23);
            printercomboBox.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label6.Location = new Point(287, 143);
            label6.Name = "label6";
            label6.Size = new Size(53, 17);
            label6.TabIndex = 9;
            label6.Text = "Printer:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(292, 94);
            label7.Name = "label7";
            label7.Size = new Size(14, 15);
            label7.TabIndex = 9;
            label7.Text = "₱";
            label7.Click += Slotlbl_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label8.Location = new Point(27, 167);
            label8.Name = "label8";
            label8.Size = new Size(85, 17);
            label8.TabIndex = 13;
            label8.Text = "License Plate";
            // 
            // Platelbl
            // 
            Platelbl.AutoSize = true;
            Platelbl.Location = new Point(154, 169);
            Platelbl.Name = "Platelbl";
            Platelbl.Size = new Size(38, 15);
            Platelbl.TabIndex = 14;
            Platelbl.Text = "label1";
            // 
            // PayConForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(468, 259);
            Controls.Add(label8);
            Controls.Add(Platelbl);
            Controls.Add(printercomboBox);
            Controls.Add(Amount_Received);
            Controls.Add(Confirmbtn);
            Controls.Add(label4);
            Controls.Add(Durationlbl);
            Controls.Add(Feelbl);
            Controls.Add(label2);
            Controls.Add(label7);
            Controls.Add(Slotlbl);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(Cancelbtn);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PayConForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Payment Confirmation";
            Load += PayConForm_Load;
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
        private Button Cancelbtn;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label Feelbl;
        private Label Durationlbl;
        private Label Slotlbl;
        private Button Confirmbtn;
        private TextBox Amount_Received;
        private ComboBox printercomboBox;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label Platelbl;
    }
}