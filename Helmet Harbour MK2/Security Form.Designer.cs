namespace Helmet_Harbour_MK2
{
    partial class Security_Form
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
            Alarm_Timer = new System.Windows.Forms.Timer(components);
            SecurityCheck_Timer = new System.Windows.Forms.Timer(components);
            Refresher = new System.Windows.Forms.Timer(components);
            SecurityDB = new DataGridView();
            Security_status = new DataGridViewTextBoxColumn();
            Slot = new DataGridViewTextBoxColumn();
            Security = new DataGridViewTextBoxColumn();
            Alarm = new DataGridViewCheckBoxColumn();
            Safe = new DataGridViewButtonColumn();
            RFID = new DataGridViewTextBoxColumn();
            TimeStart = new DataGridViewTextBoxColumn();
            TimeEnd = new DataGridViewTextBoxColumn();
            Duration = new DataGridViewTextBoxColumn();
            Fee = new DataGridViewTextBoxColumn();
            RFIDSet = new DataGridViewTextBoxColumn();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)SecurityDB).BeginInit();
            SuspendLayout();
            // 
            // Alarm_Timer
            // 
            Alarm_Timer.Enabled = true;
            Alarm_Timer.Interval = 1000;
            Alarm_Timer.Tick += Alarm_Timer_Tick;
            // 
            // SecurityCheck_Timer
            // 
            SecurityCheck_Timer.Enabled = true;
            SecurityCheck_Timer.Tick += SecurityCheckTimer_Tick;
            // 
            // Refresher
            // 
            Refresher.Enabled = true;
            Refresher.Tick += RefreshTimer_Tick;
            // 
            // SecurityDB
            // 
            SecurityDB.AllowUserToAddRows = false;
            SecurityDB.AllowUserToDeleteRows = false;
            SecurityDB.BackgroundColor = SystemColors.InactiveBorder;
            SecurityDB.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SecurityDB.Columns.AddRange(new DataGridViewColumn[] { Security_status, Slot, Security, Alarm, Safe, RFID, TimeStart, TimeEnd, Duration, Fee, RFIDSet });
            SecurityDB.Location = new Point(12, 12);
            SecurityDB.Name = "SecurityDB";
            SecurityDB.RowHeadersVisible = false;
            SecurityDB.Size = new Size(512, 442);
            SecurityDB.TabIndex = 0;
            SecurityDB.CellContentClick += SafeButton;
            SecurityDB.CellValueChanged += SecurityDB_CellValueChanged;
            SecurityDB.CurrentCellDirtyStateChanged += SecurityDB_CurrentCellDirtyStateChanged;
            // 
            // Security_status
            // 
            Security_status.DataPropertyName = "Rack ID";
            Security_status.HeaderText = "Slot ID";
            Security_status.Name = "Security_status";
            Security_status.Visible = false;
            // 
            // Slot
            // 
            Slot.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Slot.DataPropertyName = "Rack Slot";
            Slot.HeaderText = "Slot";
            Slot.Name = "Slot";
            // 
            // Security
            // 
            Security.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Security.DataPropertyName = "Security";
            Security.HeaderText = "Status";
            Security.Name = "Security";
            // 
            // Alarm
            // 
            Alarm.DataPropertyName = "Alarm";
            Alarm.FlatStyle = FlatStyle.Flat;
            Alarm.HeaderText = "Alarm";
            Alarm.Name = "Alarm";
            Alarm.Width = 48;
            // 
            // Safe
            // 
            Safe.HeaderText = "Safe";
            Safe.Name = "Safe";
            Safe.Width = 40;
            // 
            // RFID
            // 
            RFID.DataPropertyName = "RFID #";
            RFID.HeaderText = "RFID #";
            RFID.Name = "RFID";
            RFID.ReadOnly = true;
            RFID.Visible = false;
            // 
            // TimeStart
            // 
            TimeStart.DataPropertyName = "Time Start";
            TimeStart.HeaderText = "Time Start";
            TimeStart.Name = "TimeStart";
            TimeStart.ReadOnly = true;
            TimeStart.Visible = false;
            // 
            // TimeEnd
            // 
            TimeEnd.DataPropertyName = "Time End";
            TimeEnd.HeaderText = "Time End";
            TimeEnd.Name = "TimeEnd";
            TimeEnd.ReadOnly = true;
            TimeEnd.Visible = false;
            // 
            // Duration
            // 
            Duration.DataPropertyName = "Duration";
            Duration.HeaderText = "Duration";
            Duration.Name = "Duration";
            Duration.Visible = false;
            // 
            // Fee
            // 
            Fee.DataPropertyName = "Fee";
            Fee.HeaderText = "Fee";
            Fee.Name = "Fee";
            Fee.Visible = false;
            // 
            // RFIDSet
            // 
            RFIDSet.DataPropertyName = "RFIDSet";
            RFIDSet.HeaderText = "RFID Set";
            RFIDSet.Name = "RFIDSet";
            RFIDSet.Visible = false;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(430, 466);
            button1.Name = "button1";
            button1.Size = new Size(94, 41);
            button1.TabIndex = 1;
            button1.Text = "Mute All";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Muteall_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(330, 466);
            button2.Name = "button2";
            button2.Size = new Size(94, 41);
            button2.TabIndex = 2;
            button2.Text = "Safe All";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Safeall_Click;
            // 
            // Security_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(536, 519);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(SecurityDB);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Security_Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form11";
            FormClosing += Security_Form_FormClosing;
            Load += Form11_Load;
            ((System.ComponentModel.ISupportInitialize)SecurityDB).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridViewTextBoxColumn Security_Slot;
        private System.Windows.Forms.Timer Alarm_Timer;
        private System.Windows.Forms.Timer SecurityCheck_Timer;
        private System.Windows.Forms.Timer Refresher;
        private DataGridView SecurityDB;
        private DataGridViewTextBoxColumn Security_status;
        private DataGridViewTextBoxColumn Slot;
        private DataGridViewTextBoxColumn Security;
        private DataGridViewCheckBoxColumn Alarm;
        private DataGridViewButtonColumn Safe;
        private DataGridViewTextBoxColumn RFID;
        private DataGridViewTextBoxColumn TimeStart;
        private DataGridViewTextBoxColumn TimeEnd;
        private DataGridViewTextBoxColumn Duration;
        private DataGridViewTextBoxColumn Fee;
        private DataGridViewTextBoxColumn RFIDSet;
        private Button button1;
        private Button button2;
    }
}