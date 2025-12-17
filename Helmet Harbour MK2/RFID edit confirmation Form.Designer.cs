namespace Helmet_Harbour_MK2
{
    partial class EdittingForm
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
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label1 = new Label();
            OldRFIDlbl = new Label();
            label4 = new Label();
            NewRFIDlbl = new Label();
            pictureBox2 = new PictureBox();
            confirmbtn = new Button();
            button1 = new Button();
            button2 = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.edit_24dp_000000_FILL0_wght400_GRAD0_opsz24;
            pictureBox1.Location = new Point(4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 27);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(45, 9);
            label3.Name = "label3";
            label3.Size = new Size(94, 19);
            label3.TabIndex = 5;
            label3.Text = "Edit Rack Key";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(100, 78);
            label1.Name = "label1";
            label1.Size = new Size(76, 21);
            label1.TabIndex = 6;
            label1.Text = "Old RFID";
            // 
            // OldRFIDlbl
            // 
            OldRFIDlbl.AutoSize = true;
            OldRFIDlbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OldRFIDlbl.Location = new Point(100, 124);
            OldRFIDlbl.Name = "OldRFIDlbl";
            OldRFIDlbl.Size = new Size(26, 15);
            OldRFIDlbl.TabIndex = 6;
            OldRFIDlbl.Text = "Old";
            OldRFIDlbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(285, 78);
            label4.Name = "label4";
            label4.Size = new Size(84, 21);
            label4.TabIndex = 6;
            label4.Text = "New RFID";
            // 
            // NewRFIDlbl
            // 
            NewRFIDlbl.AutoSize = true;
            NewRFIDlbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NewRFIDlbl.Location = new Point(285, 124);
            NewRFIDlbl.Name = "NewRFIDlbl";
            NewRFIDlbl.Size = new Size(31, 15);
            NewRFIDlbl.TabIndex = 6;
            NewRFIDlbl.Text = "New";
            NewRFIDlbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.arrow_forward_24dp_000000_FILL0_wght400_GRAD0_opsz24;
            pictureBox2.Location = new Point(215, 108);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(33, 31);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // confirmbtn
            // 
            confirmbtn.BackColor = Color.LightGoldenrodYellow;
            confirmbtn.FlatStyle = FlatStyle.Popup;
            confirmbtn.Location = new Point(381, 224);
            confirmbtn.Name = "confirmbtn";
            confirmbtn.Size = new Size(75, 23);
            confirmbtn.TabIndex = 9;
            confirmbtn.Text = "Confirm";
            confirmbtn.UseVisualStyleBackColor = false;
            confirmbtn.Click += confirmbtn_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGoldenrodYellow;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(12, 224);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Canceltbn_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.LightGoldenrodYellow;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Location = new Point(93, 224);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 10;
            button2.Text = "Re-Scan";
            button2.UseVisualStyleBackColor = false;
            button2.Click += Rescanbtn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 255, 128);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(468, 35);
            panel1.TabIndex = 11;
            // 
            // EdittingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(468, 259);
            Controls.Add(button2);
            Controls.Add(confirmbtn);
            Controls.Add(button1);
            Controls.Add(pictureBox2);
            Controls.Add(NewRFIDlbl);
            Controls.Add(label4);
            Controls.Add(OldRFIDlbl);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EdittingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "EdittingForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label3;
        private Label label1;
        private Label OldRFIDlbl;
        private Label label4;
        private Label NewRFIDlbl;
        private PictureBox pictureBox2;
        private Button confirmbtn;
        private Button button1;
        private Button button2;
        private Panel panel1;
    }
}