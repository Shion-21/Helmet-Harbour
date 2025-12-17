namespace Helmet_Harbour_MK2
{
    partial class PaymentSettingsForm
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
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            label1 = new Label();
            Payment_mode_set = new ComboBox();
            Fee_Textbox = new TextBox();
            Initial_Payment_Textbox = new TextBox();
            Initial_Payment_Enabler = new CheckBox();
            Cancel_Settings = new Button();
            Save_Settings = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ParkingVal = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(217, 80);
            label3.Name = "label3";
            label3.Size = new Size(17, 19);
            label3.TabIndex = 13;
            label3.Text = "₱";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(71, 156);
            label2.Name = "label2";
            label2.Size = new Size(17, 19);
            label2.TabIndex = 14;
            label2.Text = "₱";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(238, 61);
            label4.Name = "label4";
            label4.Size = new Size(25, 15);
            label4.TabIndex = 7;
            label4.Text = "Fee";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 61);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 8;
            label1.Text = "Rate";
            // 
            // Payment_mode_set
            // 
            Payment_mode_set.FlatStyle = FlatStyle.System;
            Payment_mode_set.FormattingEnabled = true;
            Payment_mode_set.Items.AddRange(new object[] { "Per Hour", "Per 30 Mins", "Per 15 Mins", "Per 10 Mins", "Per 5 Mins", "Per 1 Min" });
            Payment_mode_set.Location = new Point(71, 79);
            Payment_mode_set.Name = "Payment_mode_set";
            Payment_mode_set.Size = new Size(121, 23);
            Payment_mode_set.TabIndex = 9;
            // 
            // Fee_Textbox
            // 
            Fee_Textbox.BackColor = SystemColors.Window;
            Fee_Textbox.BorderStyle = BorderStyle.FixedSingle;
            Fee_Textbox.Location = new Point(238, 79);
            Fee_Textbox.MaxLength = 9;
            Fee_Textbox.Name = "Fee_Textbox";
            Fee_Textbox.Size = new Size(100, 23);
            Fee_Textbox.TabIndex = 11;
            Fee_Textbox.KeyPress += invalidsymbol_KeyPress;
            // 
            // Initial_Payment_Textbox
            // 
            Initial_Payment_Textbox.BorderStyle = BorderStyle.FixedSingle;
            Initial_Payment_Textbox.Location = new Point(92, 155);
            Initial_Payment_Textbox.MaxLength = 9;
            Initial_Payment_Textbox.Name = "Initial_Payment_Textbox";
            Initial_Payment_Textbox.Size = new Size(100, 23);
            Initial_Payment_Textbox.TabIndex = 12;
            Initial_Payment_Textbox.KeyPress += invalidsymbol_KeyPress;
            // 
            // Initial_Payment_Enabler
            // 
            Initial_Payment_Enabler.AutoSize = true;
            Initial_Payment_Enabler.Location = new Point(71, 134);
            Initial_Payment_Enabler.Name = "Initial_Payment_Enabler";
            Initial_Payment_Enabler.Size = new Size(76, 19);
            Initial_Payment_Enabler.TabIndex = 10;
            Initial_Payment_Enabler.Text = "Base Rate";
            Initial_Payment_Enabler.UseVisualStyleBackColor = true;
            // 
            // Cancel_Settings
            // 
            Cancel_Settings.BackColor = Color.LightGoldenrodYellow;
            Cancel_Settings.FlatStyle = FlatStyle.Flat;
            Cancel_Settings.Location = new Point(12, 210);
            Cancel_Settings.Name = "Cancel_Settings";
            Cancel_Settings.Size = new Size(75, 23);
            Cancel_Settings.TabIndex = 16;
            Cancel_Settings.Text = "Cancel";
            Cancel_Settings.UseVisualStyleBackColor = false;
            Cancel_Settings.Click += Cancel_Settings_Click;
            // 
            // Save_Settings
            // 
            Save_Settings.BackColor = Color.LightGoldenrodYellow;
            Save_Settings.FlatStyle = FlatStyle.Flat;
            Save_Settings.Location = new Point(322, 210);
            Save_Settings.Name = "Save_Settings";
            Save_Settings.Size = new Size(75, 23);
            Save_Settings.TabIndex = 15;
            Save_Settings.Text = "Save";
            Save_Settings.UseVisualStyleBackColor = false;
            Save_Settings.Click += Save_Settings_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 255, 128);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(409, 35);
            panel1.TabIndex = 20;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.payments_black;
            pictureBox1.Location = new Point(4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 27);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(45, 9);
            label5.Name = "label5";
            label5.Size = new Size(118, 19);
            label5.TabIndex = 3;
            label5.Text = "Payment Settings";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(217, 156);
            label6.Name = "label6";
            label6.Size = new Size(17, 19);
            label6.TabIndex = 23;
            label6.Text = "₱";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(238, 137);
            label7.Name = "label7";
            label7.Size = new Size(68, 15);
            label7.TabIndex = 21;
            label7.Text = "Parking Fee";
            // 
            // ParkingVal
            // 
            ParkingVal.BackColor = SystemColors.Window;
            ParkingVal.BorderStyle = BorderStyle.FixedSingle;
            ParkingVal.Location = new Point(238, 155);
            ParkingVal.MaxLength = 9;
            ParkingVal.Name = "ParkingVal";
            ParkingVal.Size = new Size(100, 23);
            ParkingVal.TabIndex = 22;
            ParkingVal.KeyPress += invalidsymbol_KeyPress;
            // 
            // PaymentSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(409, 245);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(ParkingVal);
            Controls.Add(panel1);
            Controls.Add(Cancel_Settings);
            Controls.Add(Save_Settings);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(Payment_mode_set);
            Controls.Add(Fee_Textbox);
            Controls.Add(Initial_Payment_Textbox);
            Controls.Add(Initial_Payment_Enabler);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PaymentSettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PaymentSettings";
            Load += PaymentSettingsForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label2;
        private Label label4;
        private Label label1;
        private ComboBox Payment_mode_set;
        private TextBox Fee_Textbox;
        private TextBox Initial_Payment_Textbox;
        private CheckBox Initial_Payment_Enabler;
        private Button Cancel_Settings;
        private Button Save_Settings;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox ParkingVal;
    }
}