namespace Helmet_Harbour_MK2
{
    partial class RackManageForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            titlebarpanel = new Panel();
            label2 = new Label();
            MainMinimizebtn = new Label();
            CreateFClose_Btn = new Label();
            button1 = new Button();
            Deletebtn = new Button();
            RackManageDB = new DataGridView();
            Rack_ID = new DataGridViewTextBoxColumn();
            Rack_slot = new DataGridViewTextBoxColumn();
            RFID = new DataGridViewTextBoxColumn();
            Edit_Btn = new DataGridViewButtonColumn();
            Time_Start = new DataGridViewTextBoxColumn();
            Time_End = new DataGridViewTextBoxColumn();
            Duration = new DataGridViewTextBoxColumn();
            Fee = new DataGridViewTextBoxColumn();
            RFIDset = new DataGridViewButtonColumn();
            Security = new DataGridViewButtonColumn();
            Alarm = new DataGridViewCheckBoxColumn();
            titlebarpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RackManageDB).BeginInit();
            SuspendLayout();
            // 
            // titlebarpanel
            // 
            titlebarpanel.BackColor = Color.FromArgb(255, 255, 128);
            titlebarpanel.Controls.Add(label2);
            titlebarpanel.Controls.Add(MainMinimizebtn);
            titlebarpanel.Controls.Add(CreateFClose_Btn);
            titlebarpanel.Dock = DockStyle.Top;
            titlebarpanel.Location = new Point(0, 0);
            titlebarpanel.Name = "titlebarpanel";
            titlebarpanel.Size = new Size(265, 29);
            titlebarpanel.TabIndex = 23;
            titlebarpanel.MouseDown += titlebarPanel_MouseDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 5);
            label2.Name = "label2";
            label2.Size = new Size(93, 19);
            label2.TabIndex = 14;
            label2.Text = "Manage Rack";
            // 
            // MainMinimizebtn
            // 
            MainMinimizebtn.AutoSize = true;
            MainMinimizebtn.BackColor = Color.Transparent;
            MainMinimizebtn.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MainMinimizebtn.Location = new Point(206, -3);
            MainMinimizebtn.Name = "MainMinimizebtn";
            MainMinimizebtn.Size = new Size(22, 30);
            MainMinimizebtn.TabIndex = 13;
            MainMinimizebtn.Text = "-";
            MainMinimizebtn.Click += MainMinimizebtn_Click;
            // 
            // CreateFClose_Btn
            // 
            CreateFClose_Btn.AutoSize = true;
            CreateFClose_Btn.BackColor = Color.Transparent;
            CreateFClose_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateFClose_Btn.Location = new Point(234, 5);
            CreateFClose_Btn.Name = "CreateFClose_Btn";
            CreateFClose_Btn.Size = new Size(19, 20);
            CreateFClose_Btn.TabIndex = 12;
            CreateFClose_Btn.Text = "X";
            CreateFClose_Btn.Click += CreateFClose_Btn_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 255, 192);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.add_black;
            button1.Location = new Point(12, 35);
            button1.Name = "button1";
            button1.Size = new Size(50, 45);
            button1.TabIndex = 24;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Deletebtn
            // 
            Deletebtn.BackColor = Color.FromArgb(255, 255, 192);
            Deletebtn.FlatStyle = FlatStyle.Flat;
            Deletebtn.Image = Properties.Resources.delete_black;
            Deletebtn.Location = new Point(68, 35);
            Deletebtn.Name = "Deletebtn";
            Deletebtn.Size = new Size(50, 45);
            Deletebtn.TabIndex = 24;
            Deletebtn.UseVisualStyleBackColor = false;
            Deletebtn.Click += Deletebtn_Click;
            // 
            // RackManageDB
            // 
            RackManageDB.AllowUserToAddRows = false;
            RackManageDB.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.PaleGoldenrod;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.WindowText;
            RackManageDB.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            RackManageDB.BackgroundColor = Color.LemonChiffon;
            RackManageDB.BorderStyle = BorderStyle.None;
            RackManageDB.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            RackManageDB.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Khaki;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            RackManageDB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            RackManageDB.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RackManageDB.Columns.AddRange(new DataGridViewColumn[] { Rack_ID, Rack_slot, RFID, Edit_Btn, Time_Start, Time_End, Duration, Fee, RFIDset, Security, Alarm });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.InactiveBorder;
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            RackManageDB.DefaultCellStyle = dataGridViewCellStyle4;
            RackManageDB.EnableHeadersVisualStyles = false;
            RackManageDB.GridColor = SystemColors.MenuText;
            RackManageDB.Location = new Point(12, 86);
            RackManageDB.Name = "RackManageDB";
            RackManageDB.ReadOnly = true;
            RackManageDB.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.InactiveBorder;
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.InactiveBorder;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            RackManageDB.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            RackManageDB.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = SystemColors.InactiveBorder;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.InactiveBorder;
            RackManageDB.RowsDefaultCellStyle = dataGridViewCellStyle6;
            RackManageDB.Size = new Size(241, 352);
            RackManageDB.TabIndex = 25;
            RackManageDB.CellClick += RackManageDB_CellClick;
            // 
            // Rack_ID
            // 
            Rack_ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Rack_ID.DataPropertyName = "Rack ID";
            Rack_ID.HeaderText = "Rack ID";
            Rack_ID.Name = "Rack_ID";
            Rack_ID.ReadOnly = true;
            Rack_ID.Resizable = DataGridViewTriState.False;
            Rack_ID.Visible = false;
            // 
            // Rack_slot
            // 
            Rack_slot.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Rack_slot.DataPropertyName = "Rack Slot";
            Rack_slot.HeaderText = "Slot";
            Rack_slot.Name = "Rack_slot";
            Rack_slot.ReadOnly = true;
            Rack_slot.Resizable = DataGridViewTriState.False;
            // 
            // RFID
            // 
            RFID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            RFID.DataPropertyName = "RFID #";
            RFID.HeaderText = "RFID #";
            RFID.Name = "RFID";
            RFID.ReadOnly = true;
            RFID.Resizable = DataGridViewTriState.False;
            RFID.Visible = false;
            RFID.Width = 120;
            // 
            // Edit_Btn
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.Yellow;
            dataGridViewCellStyle3.ForeColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionBackColor = Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.GradientActiveCaption;
            Edit_Btn.DefaultCellStyle = dataGridViewCellStyle3;
            Edit_Btn.FlatStyle = FlatStyle.Popup;
            Edit_Btn.HeaderText = "Edit";
            Edit_Btn.Name = "Edit_Btn";
            Edit_Btn.ReadOnly = true;
            Edit_Btn.Resizable = DataGridViewTriState.False;
            Edit_Btn.Visible = false;
            Edit_Btn.Width = 40;
            // 
            // Time_Start
            // 
            Time_Start.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Time_Start.DataPropertyName = "Time Start";
            Time_Start.HeaderText = "Time Start";
            Time_Start.Name = "Time_Start";
            Time_Start.ReadOnly = true;
            Time_Start.Resizable = DataGridViewTriState.False;
            Time_Start.Visible = false;
            // 
            // Time_End
            // 
            Time_End.DataPropertyName = "Time End";
            Time_End.HeaderText = "Time End";
            Time_End.Name = "Time_End";
            Time_End.ReadOnly = true;
            Time_End.Resizable = DataGridViewTriState.False;
            Time_End.Visible = false;
            // 
            // Duration
            // 
            Duration.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Duration.DataPropertyName = "Duration";
            Duration.HeaderText = "Duration";
            Duration.Name = "Duration";
            Duration.ReadOnly = true;
            Duration.Resizable = DataGridViewTriState.False;
            Duration.Visible = false;
            // 
            // Fee
            // 
            Fee.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Fee.DataPropertyName = "Fee";
            Fee.HeaderText = "Fee";
            Fee.Name = "Fee";
            Fee.ReadOnly = true;
            Fee.Resizable = DataGridViewTriState.False;
            Fee.Visible = false;
            // 
            // RFIDset
            // 
            RFIDset.DataPropertyName = "RFIDset";
            RFIDset.HeaderText = "RFIDset";
            RFIDset.Name = "RFIDset";
            RFIDset.ReadOnly = true;
            RFIDset.Resizable = DataGridViewTriState.False;
            RFIDset.Visible = false;
            // 
            // Security
            // 
            Security.DataPropertyName = "Security";
            Security.HeaderText = "Status";
            Security.Name = "Security";
            Security.ReadOnly = true;
            Security.Resizable = DataGridViewTriState.False;
            Security.Visible = false;
            // 
            // Alarm
            // 
            Alarm.DataPropertyName = "Alarm";
            Alarm.HeaderText = "Alarm";
            Alarm.Name = "Alarm";
            Alarm.ReadOnly = true;
            Alarm.Resizable = DataGridViewTriState.True;
            Alarm.SortMode = DataGridViewColumnSortMode.Automatic;
            Alarm.Visible = false;
            // 
            // RackManageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(265, 450);
            Controls.Add(RackManageDB);
            Controls.Add(Deletebtn);
            Controls.Add(button1);
            Controls.Add(titlebarpanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RackManageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += RackManageForm_Load;
            titlebarpanel.ResumeLayout(false);
            titlebarpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)RackManageDB).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel titlebarpanel;
        private Label MainMinimizebtn;
        private Label CreateFClose_Btn;
        private Button button1;
        private Button Deletebtn;
        private DataGridView RackManageDB;
        private DataGridViewTextBoxColumn Rack_ID;
        private DataGridViewTextBoxColumn Rack_slot;
        private DataGridViewTextBoxColumn RFID;
        private DataGridViewButtonColumn Edit_Btn;
        private DataGridViewTextBoxColumn Time_Start;
        private DataGridViewTextBoxColumn Time_End;
        private DataGridViewTextBoxColumn Duration;
        private DataGridViewTextBoxColumn Fee;
        private DataGridViewButtonColumn RFIDset;
        private DataGridViewButtonColumn Security;
        private DataGridViewCheckBoxColumn Alarm;
        private Label label2;
    }
}