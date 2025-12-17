namespace Helmet_Harbour_MK2
{
    partial class ActivationForm
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
            label1 = new Label();
            Returnbtn = new Button();
            ConfirmBtn = new Button();
            Platetxtbox = new TextBox();
            label2 = new Label();
            label4 = new Label();
            CardIDlbl = new Label();
            RFIDlbl = new Label();
            label7 = new Label();
            nametextbox = new TextBox();
            RiderType = new ComboBox();
            label5 = new Label();
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
            panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.smart_card_reader_34dp_000000_FILL0_wght400_GRAD0_opsz40;
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
            label3.Size = new Size(93, 19);
            label3.TabIndex = 3;
            label3.Text = "Activate Card";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 98);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 9;
            label1.Text = "Plate Number";
            // 
            // Returnbtn
            // 
            Returnbtn.BackColor = Color.LightGoldenrodYellow;
            Returnbtn.FlatStyle = FlatStyle.Flat;
            Returnbtn.Location = new Point(12, 224);
            Returnbtn.Name = "Returnbtn";
            Returnbtn.Size = new Size(75, 23);
            Returnbtn.TabIndex = 10;
            Returnbtn.Text = "Return";
            Returnbtn.UseVisualStyleBackColor = false;
            Returnbtn.Click += Returnbtn_Click;
            // 
            // ConfirmBtn
            // 
            ConfirmBtn.BackColor = Color.LightGoldenrodYellow;
            ConfirmBtn.FlatStyle = FlatStyle.Flat;
            ConfirmBtn.Location = new Point(381, 224);
            ConfirmBtn.Name = "ConfirmBtn";
            ConfirmBtn.Size = new Size(75, 23);
            ConfirmBtn.TabIndex = 10;
            ConfirmBtn.Text = "Confirm";
            ConfirmBtn.UseVisualStyleBackColor = false;
            ConfirmBtn.Click += ConfirmBtn_Click;
            // 
            // Platetxtbox
            // 
            Platetxtbox.Location = new Point(45, 116);
            Platetxtbox.MaxLength = 8;
            Platetxtbox.Name = "Platetxtbox";
            Platetxtbox.Size = new Size(137, 23);
            Platetxtbox.TabIndex = 11;
            Platetxtbox.KeyPress += invalidsymbol_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 60);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 12;
            label2.Text = "Card Number:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(270, 60);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 9;
            label4.Text = "RFID Number:";
            // 
            // CardIDlbl
            // 
            CardIDlbl.AutoSize = true;
            CardIDlbl.Location = new Point(133, 60);
            CardIDlbl.Name = "CardIDlbl";
            CardIDlbl.Size = new Size(38, 15);
            CardIDlbl.TabIndex = 12;
            CardIDlbl.Text = "label2";
            // 
            // RFIDlbl
            // 
            RFIDlbl.AutoSize = true;
            RFIDlbl.Location = new Point(357, 60);
            RFIDlbl.Name = "RFIDlbl";
            RFIDlbl.Size = new Size(38, 15);
            RFIDlbl.TabIndex = 9;
            RFIDlbl.Text = "label1";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(270, 98);
            label7.Name = "label7";
            label7.Size = new Size(96, 15);
            label7.TabIndex = 9;
            label7.Text = "Name (Optional)";
            // 
            // nametextbox
            // 
            nametextbox.Location = new Point(270, 116);
            nametextbox.MaxLength = 24;
            nametextbox.Name = "nametextbox";
            nametextbox.Size = new Size(131, 23);
            nametextbox.TabIndex = 11;
            nametextbox.KeyPress += invalidsymbol_KeyPress;
            // 
            // RiderType
            // 
            RiderType.DropDownStyle = ComboBoxStyle.DropDownList;
            RiderType.FormattingEnabled = true;
            RiderType.Items.AddRange(new object[] { "Driver", "Passenger" });
            RiderType.Location = new Point(166, 181);
            RiderType.Name = "RiderType";
            RiderType.Size = new Size(121, 23);
            RiderType.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(166, 163);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 14;
            label5.Text = "User Type";
            // 
            // ActivationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(468, 259);
            Controls.Add(label5);
            Controls.Add(RiderType);
            Controls.Add(CardIDlbl);
            Controls.Add(label2);
            Controls.Add(nametextbox);
            Controls.Add(Platetxtbox);
            Controls.Add(ConfirmBtn);
            Controls.Add(RFIDlbl);
            Controls.Add(label4);
            Controls.Add(label7);
            Controls.Add(Returnbtn);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ActivationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ActivationForm";
            Load += ActivationForm_Load;
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
        private Button Returnbtn;
        private Button ConfirmBtn;
        private TextBox Platetxtbox;
        private Label label2;
        private Label label4;
        private Label CardIDlbl;
        private Label RFIDlbl;
        private Label label7;
        private TextBox nametextbox;
        private ComboBox RiderType;
        private Label label5;
    }
}