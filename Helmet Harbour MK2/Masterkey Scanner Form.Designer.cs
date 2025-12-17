namespace Helmet_Harbour_MK2
{
    partial class MasterkeyForm
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
            label1 = new Label();
            ScanCheck = new System.Windows.Forms.Timer(components);
            Returnbtn = new Button();
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
            panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.edit_24dp_000000_FILL0_wght400_GRAD0_opsz24;
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
            label3.Size = new Size(73, 19);
            label3.TabIndex = 3;
            label3.Text = "Masterkey";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(161, 119);
            label1.Name = "label1";
            label1.Size = new Size(147, 21);
            label1.TabIndex = 5;
            label1.Text = "Please scan a card";
            // 
            // ScanCheck
            // 
            ScanCheck.Enabled = true;
            ScanCheck.Tick += ScanCheck_Tick;
            // 
            // Returnbtn
            // 
            Returnbtn.BackColor = Color.LightGoldenrodYellow;
            Returnbtn.FlatStyle = FlatStyle.Flat;
            Returnbtn.Location = new Point(12, 224);
            Returnbtn.Name = "Returnbtn";
            Returnbtn.Size = new Size(75, 23);
            Returnbtn.TabIndex = 7;
            Returnbtn.Text = "Return";
            Returnbtn.UseVisualStyleBackColor = false;
            Returnbtn.Click += Returnbtn_Click;
            // 
            // MasterkeyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(468, 259);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(Returnbtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MasterkeyForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MasterkeyForm";
            FormClosing += MasterkeyForm_FormClosing;
            Load += MasterkeyForm_Load;
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
        private Label label1;
        private System.Windows.Forms.Timer ScanCheck;
        private Button Returnbtn;
    }
}