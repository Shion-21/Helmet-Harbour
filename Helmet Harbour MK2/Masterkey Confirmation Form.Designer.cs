namespace Helmet_Harbour_MK2
{
    partial class MasterConfirmForm
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
            button2 = new Button();
            confirmbtn = new Button();
            button1 = new Button();
            pictureBox2 = new PictureBox();
            NewRFIDlbl = new Label();
            label4 = new Label();
            OldRFIDlbl = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.LightGoldenrodYellow;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Location = new Point(97, 227);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 20;
            button2.Text = "Re-Scan";
            button2.UseVisualStyleBackColor = false;
            button2.Click += Rescanbtn_Click;
            // 
            // confirmbtn
            // 
            confirmbtn.BackColor = Color.LightGoldenrodYellow;
            confirmbtn.FlatStyle = FlatStyle.Popup;
            confirmbtn.Location = new Point(385, 227);
            confirmbtn.Name = "confirmbtn";
            confirmbtn.Size = new Size(75, 23);
            confirmbtn.TabIndex = 19;
            confirmbtn.Text = "Confirm";
            confirmbtn.UseVisualStyleBackColor = false;
            confirmbtn.Click += confirmbtn_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGoldenrodYellow;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(16, 227);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 18;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Canceltbn_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.arrow_forward_24dp_000000_FILL0_wght400_GRAD0_opsz24;
            pictureBox2.Location = new Point(219, 111);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(33, 31);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 17;
            pictureBox2.TabStop = false;
            // 
            // NewRFIDlbl
            // 
            NewRFIDlbl.AutoSize = true;
            NewRFIDlbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NewRFIDlbl.Location = new Point(289, 127);
            NewRFIDlbl.Name = "NewRFIDlbl";
            NewRFIDlbl.Size = new Size(31, 15);
            NewRFIDlbl.TabIndex = 13;
            NewRFIDlbl.Text = "New";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(289, 81);
            label4.Name = "label4";
            label4.Size = new Size(84, 21);
            label4.TabIndex = 14;
            label4.Text = "New RFID";
            // 
            // OldRFIDlbl
            // 
            OldRFIDlbl.AutoSize = true;
            OldRFIDlbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OldRFIDlbl.Location = new Point(104, 127);
            OldRFIDlbl.Name = "OldRFIDlbl";
            OldRFIDlbl.Size = new Size(26, 15);
            OldRFIDlbl.TabIndex = 15;
            OldRFIDlbl.Text = "Old";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(104, 81);
            label1.Name = "label1";
            label1.Size = new Size(76, 21);
            label1.TabIndex = 16;
            label1.Text = "Old RFID";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.edit_24dp_000000_FILL0_wght400_GRAD0_opsz24;
            pictureBox1.Location = new Point(8, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 27);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(49, 12);
            label3.Name = "label3";
            label3.Size = new Size(58, 19);
            label3.TabIndex = 12;
            label3.Text = "Editting";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 255, 128);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(468, 35);
            panel1.TabIndex = 21;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.edit_24dp_000000_FILL0_wght400_GRAD0_opsz24;
            pictureBox3.Location = new Point(4, 5);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(35, 27);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(45, 9);
            label2.Name = "label2";
            label2.Size = new Size(122, 19);
            label2.TabIndex = 3;
            label2.Text = "Masterkey change";
            // 
            // MasterConfirmForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(468, 259);
            Controls.Add(panel1);
            Controls.Add(button2);
            Controls.Add(confirmbtn);
            Controls.Add(button1);
            Controls.Add(pictureBox2);
            Controls.Add(NewRFIDlbl);
            Controls.Add(label4);
            Controls.Add(OldRFIDlbl);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "MasterConfirmForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MasterConfirmForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button confirmbtn;
        private Button button1;
        private PictureBox pictureBox2;
        private Label NewRFIDlbl;
        private Label label4;
        private Label OldRFIDlbl;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label3;
        private Panel panel1;
        private PictureBox pictureBox3;
        private Label label2;
    }
}