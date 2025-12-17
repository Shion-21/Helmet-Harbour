namespace Helmet_Harbour_MK2
{
    partial class RFIDsForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            RFIDsDB = new DataGridView();
            idRFIDs = new DataGridViewTextBoxColumn();
            RFIDNumber = new DataGridViewTextBoxColumn();
            Status = new DataGridViewComboBoxColumn();
            FailedAttempts = new DataGridViewTextBoxColumn();
            ActivationTime = new DataGridViewTextBoxColumn();
            PlateNumber = new DataGridViewTextBoxColumn();
            HolderName = new DataGridViewTextBoxColumn();
            UserType = new DataGridViewTextBoxColumn();
            button1 = new Button();
            Deletebtn = new Button();
            panel1 = new Panel();
            CreateFClose_Btn = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            comboSearch = new ComboBox();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)RFIDsDB).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // RFIDsDB
            // 
            RFIDsDB.AllowUserToAddRows = false;
            RFIDsDB.AllowUserToDeleteRows = false;
            RFIDsDB.BackgroundColor = Color.LemonChiffon;
            RFIDsDB.BorderStyle = BorderStyle.None;
            RFIDsDB.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            RFIDsDB.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Khaki;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkKhaki;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            RFIDsDB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            RFIDsDB.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RFIDsDB.Columns.AddRange(new DataGridViewColumn[] { idRFIDs, RFIDNumber, Status, FailedAttempts, ActivationTime, PlateNumber, HolderName, UserType });
            RFIDsDB.EnableHeadersVisualStyles = false;
            RFIDsDB.Location = new Point(12, 85);
            RFIDsDB.Name = "RFIDsDB";
            RFIDsDB.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            RFIDsDB.RowHeadersVisible = false;
            RFIDsDB.Size = new Size(591, 559);
            RFIDsDB.TabIndex = 0;
            RFIDsDB.CellClick += RFIDsDB_CellClick;
            RFIDsDB.CellValueChanged += RFIDsDB_CellValueChanged;
            RFIDsDB.CurrentCellDirtyStateChanged += RFIDsDB_CurrentCellDirtyStateChanged;
            RFIDsDB.DataBindingComplete += RFIDsDB_DataBindingComplete;
            // 
            // idRFIDs
            // 
            idRFIDs.DataPropertyName = "idRFIDs";
            idRFIDs.HeaderText = "Card ID";
            idRFIDs.Name = "idRFIDs";
            idRFIDs.ReadOnly = true;
            idRFIDs.Width = 50;
            // 
            // RFIDNumber
            // 
            RFIDNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RFIDNumber.DataPropertyName = "RFID Number";
            RFIDNumber.HeaderText = "RFID Number";
            RFIDNumber.Name = "RFIDNumber";
            RFIDNumber.ReadOnly = true;
            // 
            // Status
            // 
            Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Status";
            Status.Items.AddRange(new object[] { "Locked", "Active", "Inactive" });
            Status.Name = "Status";
            // 
            // FailedAttempts
            // 
            FailedAttempts.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FailedAttempts.DataPropertyName = "Failed Attempts";
            FailedAttempts.HeaderText = "Failed Attempts";
            FailedAttempts.Name = "FailedAttempts";
            FailedAttempts.ReadOnly = true;
            FailedAttempts.Visible = false;
            // 
            // ActivationTime
            // 
            ActivationTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ActivationTime.DataPropertyName = "Activation Time";
            ActivationTime.HeaderText = "Activation Time";
            ActivationTime.Name = "ActivationTime";
            ActivationTime.ReadOnly = true;
            ActivationTime.Width = 105;
            // 
            // PlateNumber
            // 
            PlateNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PlateNumber.DataPropertyName = "Plate Number";
            PlateNumber.HeaderText = "Plate Number";
            PlateNumber.Name = "PlateNumber";
            PlateNumber.ReadOnly = true;
            // 
            // HolderName
            // 
            HolderName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            HolderName.DataPropertyName = "TempHolder";
            HolderName.HeaderText = "Holder Name";
            HolderName.Name = "HolderName";
            HolderName.ReadOnly = true;
            // 
            // UserType
            // 
            UserType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            UserType.DataPropertyName = "HolderType";
            UserType.HeaderText = "User Type";
            UserType.Name = "UserType";
            UserType.ReadOnly = true;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGoldenrodYellow;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.add_black;
            button1.Location = new Point(609, 85);
            button1.Name = "button1";
            button1.Size = new Size(61, 53);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = false;
            button1.Click += AddRFID_Click;
            // 
            // Deletebtn
            // 
            Deletebtn.BackColor = Color.LightGoldenrodYellow;
            Deletebtn.FlatStyle = FlatStyle.Flat;
            Deletebtn.Image = Properties.Resources.delete_black;
            Deletebtn.Location = new Point(609, 144);
            Deletebtn.Name = "Deletebtn";
            Deletebtn.Size = new Size(61, 53);
            Deletebtn.TabIndex = 1;
            Deletebtn.UseVisualStyleBackColor = false;
            Deletebtn.Click += Deletebtn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 255, 128);
            panel1.Controls.Add(CreateFClose_Btn);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(682, 35);
            panel1.TabIndex = 7;
            // 
            // CreateFClose_Btn
            // 
            CreateFClose_Btn.AutoSize = true;
            CreateFClose_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateFClose_Btn.Location = new Point(651, 5);
            CreateFClose_Btn.Name = "CreateFClose_Btn";
            CreateFClose_Btn.Size = new Size(19, 20);
            CreateFClose_Btn.TabIndex = 14;
            CreateFClose_Btn.Text = "X";
            CreateFClose_Btn.Click += CreateFClose_Btn_Click;
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
            label3.Size = new Size(45, 19);
            label3.TabIndex = 3;
            label3.Text = "RFIDs";
            // 
            // comboSearch
            // 
            comboSearch.BackColor = Color.FromArgb(255, 255, 128);
            comboSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSearch.FormattingEnabled = true;
            comboSearch.Items.AddRange(new object[] { "Card ID", "RFID Number", "Status", "Activation Time", "Plate Number", "Holder Name" });
            comboSearch.Location = new Point(12, 56);
            comboSearch.Name = "comboSearch";
            comboSearch.Size = new Size(206, 23);
            comboSearch.TabIndex = 8;
            comboSearch.TextChanged += RFIDsForm_Load;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(224, 56);
            txtSearch.MaxLength = 24;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(235, 23);
            txtSearch.TabIndex = 9;
            txtSearch.TextChanged += RFIDsForm_Load;
            txtSearch.KeyPress += invalidsymbol_KeyPress;
            // 
            // RFIDsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(682, 656);
            Controls.Add(txtSearch);
            Controls.Add(comboSearch);
            Controls.Add(panel1);
            Controls.Add(Deletebtn);
            Controls.Add(button1);
            Controls.Add(RFIDsDB);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RFIDsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "RFIDsForm";
            Load += RFIDsForm_Load;
            ((System.ComponentModel.ISupportInitialize)RFIDsDB).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView RFIDsDB;
        private Button button1;
        private Button Deletebtn;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label3;
        private Label CreateFClose_Btn;
        private ComboBox comboSearch;
        private TextBox txtSearch;
        private DataGridViewTextBoxColumn idRFIDs;
        private DataGridViewTextBoxColumn RFIDNumber;
        private DataGridViewComboBoxColumn Status;
        private DataGridViewTextBoxColumn FailedAttempts;
        private DataGridViewTextBoxColumn ActivationTime;
        private DataGridViewTextBoxColumn PlateNumber;
        private DataGridViewTextBoxColumn HolderName;
        private DataGridViewTextBoxColumn UserType;
    }
}