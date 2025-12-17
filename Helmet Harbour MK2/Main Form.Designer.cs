namespace Helmet_Harbour_MK2
{
    partial class MainForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            RackDB = new DataGridView();
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
            label1 = new Label();
            pictureBox1 = new PictureBox();
            Settings_Panel = new Panel();
            button2 = new Button();
            RFIDsbtn = new Button();
            Mastercard_btn = new Button();
            PaymentSettingsbtn = new Button();
            CreateFClose_Btn = new Label();
            MainMinimizebtn = new Label();
            Settings_transitionTick = new System.Windows.Forms.Timer(components);
            Paybtn = new Button();
            Refresher = new System.Windows.Forms.Timer(components);
            SearchBox = new TextBox();
            pictureBox2 = new PictureBox();
            Hovertimer = new System.Windows.Forms.Timer(components);
            Settingsbtn = new Button();
            Accountsbtn = new Button();
            Recordstbn = new Button();
            toolTip1 = new ToolTip(components);
            Usagelogbtn = new Button();
            Transactionsbtn = new Button();
            Logoutbtn = new Button();
            helpwindowbtn = new Button();
            records_panel = new Panel();
            ActionsLogbtn = new Button();
            label2 = new Label();
            SecurityCheckTimer = new System.Windows.Forms.Timer(components);
            SecurityEnabler = new System.Windows.Forms.Timer(components);
            Welcomelbl = new Label();
            Activationbtn = new Button();
            titlebarpanel = new Panel();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)RackDB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            Settings_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            records_panel.SuspendLayout();
            titlebarpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // RackDB
            // 
            RackDB.AllowUserToAddRows = false;
            RackDB.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.PaleGoldenrod;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.WindowText;
            RackDB.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            RackDB.BackgroundColor = Color.LemonChiffon;
            RackDB.BorderStyle = BorderStyle.None;
            RackDB.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            RackDB.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Khaki;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            RackDB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            RackDB.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RackDB.Columns.AddRange(new DataGridViewColumn[] { Rack_ID, Rack_slot, RFID, Edit_Btn, Time_Start, Time_End, Duration, Fee, RFIDset, Security, Alarm });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.InactiveBorder;
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            RackDB.DefaultCellStyle = dataGridViewCellStyle4;
            RackDB.EnableHeadersVisualStyles = false;
            RackDB.GridColor = SystemColors.MenuText;
            RackDB.Location = new Point(12, 76);
            RackDB.Name = "RackDB";
            RackDB.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.InactiveBorder;
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.InactiveBorder;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            RackDB.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            RackDB.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = SystemColors.InactiveBorder;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.InactiveBorder;
            RackDB.RowsDefaultCellStyle = dataGridViewCellStyle6;
            RackDB.Size = new Size(1299, 567);
            RackDB.TabIndex = 0;
            RackDB.CellContentClick += RackDB_CellContentClick;
            RackDB.CellMouseEnter += RackDB_CellMouseEnter;
            RackDB.CellMouseLeave += RackDB_CellMouseLeave;
            RackDB.ColumnHeaderMouseClick += RackDB_ColumnHeaderMouseClick;
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
            Rack_slot.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
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
            // 
            // Fee
            // 
            Fee.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Fee.DataPropertyName = "Fee";
            Fee.HeaderText = "Fee";
            Fee.Name = "Fee";
            Fee.ReadOnly = true;
            Fee.Resizable = DataGridViewTriState.False;
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
            Alarm.Resizable = DataGridViewTriState.True;
            Alarm.SortMode = DataGridViewColumnSortMode.Automatic;
            Alarm.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(81, 32);
            label1.Name = "label1";
            label1.Size = new Size(138, 21);
            label1.TabIndex = 1;
            label1.Text = "Helmet Harbour";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = Properties.Resources._530815967_748571391111211_2104280294899996801_n_removebg_preview;
            pictureBox1.Location = new Point(12, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(63, 61);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // Settings_Panel
            // 
            Settings_Panel.BackColor = Color.Khaki;
            Settings_Panel.Controls.Add(button2);
            Settings_Panel.Controls.Add(RFIDsbtn);
            Settings_Panel.Controls.Add(Mastercard_btn);
            Settings_Panel.Controls.Add(PaymentSettingsbtn);
            Settings_Panel.Location = new Point(12, 417);
            Settings_Panel.Name = "Settings_Panel";
            Settings_Panel.Size = new Size(171, 246);
            Settings_Panel.TabIndex = 3;
            Settings_Panel.MouseLeave += Settings_Panel_MouseLeave;
            // 
            // button2
            // 
            button2.BackColor = Color.Khaki;
            button2.FlatAppearance.BorderColor = Color.Khaki;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(3, 185);
            button2.MaximumSize = new Size(165, 55);
            button2.MinimumSize = new Size(165, 55);
            button2.Name = "button2";
            button2.Size = new Size(165, 55);
            button2.TabIndex = 3;
            button2.Text = "Manage Racks";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // RFIDsbtn
            // 
            RFIDsbtn.BackColor = Color.Khaki;
            RFIDsbtn.FlatAppearance.BorderColor = Color.Khaki;
            RFIDsbtn.FlatStyle = FlatStyle.Flat;
            RFIDsbtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RFIDsbtn.Location = new Point(3, 125);
            RFIDsbtn.MaximumSize = new Size(165, 55);
            RFIDsbtn.MinimumSize = new Size(165, 55);
            RFIDsbtn.Name = "RFIDsbtn";
            RFIDsbtn.Size = new Size(165, 55);
            RFIDsbtn.TabIndex = 3;
            RFIDsbtn.Text = "Manage RFIDs";
            RFIDsbtn.UseVisualStyleBackColor = false;
            RFIDsbtn.Click += RFIDsbtn_Click;
            // 
            // Mastercard_btn
            // 
            Mastercard_btn.BackColor = Color.Khaki;
            Mastercard_btn.FlatAppearance.BorderColor = Color.Khaki;
            Mastercard_btn.FlatStyle = FlatStyle.Flat;
            Mastercard_btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Mastercard_btn.Location = new Point(3, 65);
            Mastercard_btn.Name = "Mastercard_btn";
            Mastercard_btn.Size = new Size(165, 55);
            Mastercard_btn.TabIndex = 2;
            Mastercard_btn.Text = "Change Masterkey";
            Mastercard_btn.UseVisualStyleBackColor = false;
            Mastercard_btn.Click += Mastercard_btn_Click;
            // 
            // PaymentSettingsbtn
            // 
            PaymentSettingsbtn.BackColor = Color.Khaki;
            PaymentSettingsbtn.FlatAppearance.BorderColor = Color.Khaki;
            PaymentSettingsbtn.FlatStyle = FlatStyle.Flat;
            PaymentSettingsbtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PaymentSettingsbtn.Location = new Point(3, 3);
            PaymentSettingsbtn.Name = "PaymentSettingsbtn";
            PaymentSettingsbtn.Size = new Size(165, 54);
            PaymentSettingsbtn.TabIndex = 1;
            PaymentSettingsbtn.Text = "Payment Settings";
            PaymentSettingsbtn.UseVisualStyleBackColor = false;
            PaymentSettingsbtn.Click += PaymentSettingsbtn_Click;
            // 
            // CreateFClose_Btn
            // 
            CreateFClose_Btn.AutoSize = true;
            CreateFClose_Btn.BackColor = Color.Transparent;
            CreateFClose_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateFClose_Btn.Location = new Point(1293, 5);
            CreateFClose_Btn.Name = "CreateFClose_Btn";
            CreateFClose_Btn.Size = new Size(19, 20);
            CreateFClose_Btn.TabIndex = 12;
            CreateFClose_Btn.Text = "X";
            CreateFClose_Btn.Click += MainFClose_Btn_Click;
            CreateFClose_Btn.MouseLeave += MainFClose_MouseLeave;
            CreateFClose_Btn.MouseHover += MainFClose_MouseHover;
            // 
            // MainMinimizebtn
            // 
            MainMinimizebtn.AutoSize = true;
            MainMinimizebtn.BackColor = Color.Transparent;
            MainMinimizebtn.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MainMinimizebtn.Location = new Point(1265, -3);
            MainMinimizebtn.Name = "MainMinimizebtn";
            MainMinimizebtn.Size = new Size(22, 30);
            MainMinimizebtn.TabIndex = 13;
            MainMinimizebtn.Text = "-";
            MainMinimizebtn.Click += MainFMinimize_Btn_Click;
            MainMinimizebtn.MouseLeave += MainFMinimize_MouseLeave;
            MainMinimizebtn.MouseHover += MainFMinimize_MouseHover;
            // 
            // Settings_transitionTick
            // 
            Settings_transitionTick.Interval = 20;
            Settings_transitionTick.Tick += Settings_transitionTick_Tick;
            // 
            // Paybtn
            // 
            Paybtn.BackColor = Color.FromArgb(255, 255, 192);
            Paybtn.BackgroundImageLayout = ImageLayout.None;
            Paybtn.FlatAppearance.BorderColor = Color.Black;
            Paybtn.FlatStyle = FlatStyle.Flat;
            Paybtn.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Paybtn.Location = new Point(1079, 657);
            Paybtn.Name = "Paybtn";
            Paybtn.Size = new Size(233, 59);
            Paybtn.TabIndex = 14;
            Paybtn.Text = "Pay";
            Paybtn.UseVisualStyleBackColor = false;
            Paybtn.Click += Paybtn_Click;
            // 
            // Refresher
            // 
            Refresher.Enabled = true;
            Refresher.Tick += RefreshTimer_Tick;
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(906, 43);
            SearchBox.MaxLength = 24;
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(363, 23);
            SearchBox.TabIndex = 15;
            SearchBox.TextChanged += SearchBox_TextChanged;
            SearchBox.KeyPress += invalidsymbol_KeyPress;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.search_24dp_000000_FILL0_wght400_GRAD0_opsz24;
            pictureBox2.Location = new Point(1275, 42);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(37, 24);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // Hovertimer
            // 
            Hovertimer.Interval = 5000;
            Hovertimer.Tick += Hovertimer_Tick;
            // 
            // Settingsbtn
            // 
            Settingsbtn.FlatAppearance.BorderSize = 0;
            Settingsbtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 192);
            Settingsbtn.FlatStyle = FlatStyle.Flat;
            Settingsbtn.Image = Properties.Resources.settings_black1;
            Settingsbtn.Location = new Point(12, 657);
            Settingsbtn.Name = "Settingsbtn";
            Settingsbtn.Size = new Size(63, 59);
            Settingsbtn.TabIndex = 18;
            toolTip1.SetToolTip(Settingsbtn, "Settings");
            Settingsbtn.UseVisualStyleBackColor = true;
            Settingsbtn.Click += Settingsbtn_Click;
            Settingsbtn.MouseLeave += Settings_Panel_MouseLeave;
            // 
            // Accountsbtn
            // 
            Accountsbtn.FlatAppearance.BorderSize = 0;
            Accountsbtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 192);
            Accountsbtn.FlatStyle = FlatStyle.Flat;
            Accountsbtn.Image = Properties.Resources.manage_accounts_black1;
            Accountsbtn.Location = new Point(81, 657);
            Accountsbtn.Name = "Accountsbtn";
            Accountsbtn.Size = new Size(63, 59);
            Accountsbtn.TabIndex = 18;
            Accountsbtn.UseVisualStyleBackColor = true;
            Accountsbtn.Click += Accountsbtn_Click;
            // 
            // Recordstbn
            // 
            Recordstbn.FlatAppearance.BorderSize = 0;
            Recordstbn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 192);
            Recordstbn.FlatStyle = FlatStyle.Flat;
            Recordstbn.Image = Properties.Resources.article_34dp_000000_FILL0_wght400_GRAD0_opsz40;
            Recordstbn.Location = new Point(150, 657);
            Recordstbn.Name = "Recordstbn";
            Recordstbn.Size = new Size(63, 59);
            Recordstbn.TabIndex = 18;
            Recordstbn.UseVisualStyleBackColor = true;
            Recordstbn.Click += Recordstbn_Click;
            Recordstbn.MouseLeave += Records_Panel_MouseLeave;
            // 
            // Usagelogbtn
            // 
            Usagelogbtn.BackColor = Color.Khaki;
            Usagelogbtn.FlatAppearance.BorderColor = Color.Khaki;
            Usagelogbtn.FlatStyle = FlatStyle.Flat;
            Usagelogbtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Usagelogbtn.Location = new Point(3, 63);
            Usagelogbtn.Name = "Usagelogbtn";
            Usagelogbtn.Size = new Size(165, 55);
            Usagelogbtn.TabIndex = 4;
            Usagelogbtn.Text = "Usage Log";
            toolTip1.SetToolTip(Usagelogbtn, "Live usage log of RFIDs");
            Usagelogbtn.UseVisualStyleBackColor = false;
            Usagelogbtn.Click += Usagelogbtn_Click;
            // 
            // Transactionsbtn
            // 
            Transactionsbtn.BackColor = Color.Khaki;
            Transactionsbtn.FlatAppearance.BorderColor = Color.Khaki;
            Transactionsbtn.FlatStyle = FlatStyle.Flat;
            Transactionsbtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Transactionsbtn.Location = new Point(3, 3);
            Transactionsbtn.Name = "Transactionsbtn";
            Transactionsbtn.Size = new Size(165, 54);
            Transactionsbtn.TabIndex = 3;
            Transactionsbtn.Text = "Transactions Log";
            toolTip1.SetToolTip(Transactionsbtn, "Previous completed transactions");
            Transactionsbtn.UseVisualStyleBackColor = false;
            Transactionsbtn.Click += Transactionsbtn_Click;
            // 
            // Logoutbtn
            // 
            Logoutbtn.FlatAppearance.BorderSize = 0;
            Logoutbtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 192);
            Logoutbtn.FlatStyle = FlatStyle.Flat;
            Logoutbtn.Image = Properties.Resources.logout_black;
            Logoutbtn.Location = new Point(219, 657);
            Logoutbtn.Name = "Logoutbtn";
            Logoutbtn.Size = new Size(63, 59);
            Logoutbtn.TabIndex = 18;
            toolTip1.SetToolTip(Logoutbtn, "Logout");
            Logoutbtn.UseVisualStyleBackColor = true;
            Logoutbtn.Click += Logoutbtn_Click;
            // 
            // helpwindowbtn
            // 
            helpwindowbtn.FlatAppearance.BorderSize = 0;
            helpwindowbtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 192);
            helpwindowbtn.FlatStyle = FlatStyle.Flat;
            helpwindowbtn.Image = Properties.Resources.help_34dp_000000_FILL0_wght400_GRAD0_opsz40;
            helpwindowbtn.Location = new Point(288, 657);
            helpwindowbtn.Name = "helpwindowbtn";
            helpwindowbtn.Size = new Size(63, 59);
            helpwindowbtn.TabIndex = 23;
            toolTip1.SetToolTip(helpwindowbtn, "Logout");
            helpwindowbtn.UseVisualStyleBackColor = true;
            helpwindowbtn.Click += helpwindowbtn_Click;
            // 
            // records_panel
            // 
            records_panel.BackColor = Color.Khaki;
            records_panel.Controls.Add(ActionsLogbtn);
            records_panel.Controls.Add(Usagelogbtn);
            records_panel.Controls.Add(Transactionsbtn);
            records_panel.Location = new Point(150, 479);
            records_panel.Name = "records_panel";
            records_panel.Size = new Size(171, 184);
            records_panel.TabIndex = 19;
            records_panel.MouseLeave += Records_Panel_MouseLeave;
            // 
            // ActionsLogbtn
            // 
            ActionsLogbtn.BackColor = Color.Khaki;
            ActionsLogbtn.FlatAppearance.BorderColor = Color.Khaki;
            ActionsLogbtn.FlatStyle = FlatStyle.Flat;
            ActionsLogbtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ActionsLogbtn.Location = new Point(3, 123);
            ActionsLogbtn.Name = "ActionsLogbtn";
            ActionsLogbtn.Size = new Size(165, 55);
            ActionsLogbtn.TabIndex = 4;
            ActionsLogbtn.Text = "Actions Log";
            ActionsLogbtn.UseVisualStyleBackColor = false;
            ActionsLogbtn.Click += ActionsLogbtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(81, 53);
            label2.Name = "label2";
            label2.Size = new Size(110, 13);
            label2.TabIndex = 20;
            label2.Text = "Quadro Technologies";
            // 
            // SecurityCheckTimer
            // 
            SecurityCheckTimer.Enabled = true;
            SecurityCheckTimer.Tick += SecurityCheckTimer_Tick;
            // 
            // SecurityEnabler
            // 
            SecurityEnabler.Enabled = true;
            SecurityEnabler.Tick += SecurityCheckTimer_Enabler;
            // 
            // Welcomelbl
            // 
            Welcomelbl.BackColor = Color.Transparent;
            Welcomelbl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Welcomelbl.Location = new Point(498, 43);
            Welcomelbl.Name = "Welcomelbl";
            Welcomelbl.Size = new Size(328, 21);
            Welcomelbl.TabIndex = 21;
            Welcomelbl.Text = "Welcome,";
            Welcomelbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Activationbtn
            // 
            Activationbtn.BackColor = Color.FromArgb(255, 255, 192);
            Activationbtn.BackgroundImageLayout = ImageLayout.None;
            Activationbtn.FlatAppearance.BorderColor = Color.Black;
            Activationbtn.FlatStyle = FlatStyle.Flat;
            Activationbtn.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Activationbtn.Location = new Point(840, 657);
            Activationbtn.Name = "Activationbtn";
            Activationbtn.Size = new Size(233, 59);
            Activationbtn.TabIndex = 14;
            Activationbtn.Text = "Activate Card";
            Activationbtn.UseVisualStyleBackColor = false;
            Activationbtn.Click += Activationbtn_Click;
            // 
            // titlebarpanel
            // 
            titlebarpanel.BackColor = Color.FromArgb(255, 255, 128);
            titlebarpanel.Controls.Add(MainMinimizebtn);
            titlebarpanel.Controls.Add(CreateFClose_Btn);
            titlebarpanel.Controls.Add(pictureBox1);
            titlebarpanel.Dock = DockStyle.Top;
            titlebarpanel.Location = new Point(0, 0);
            titlebarpanel.Name = "titlebarpanel";
            titlebarpanel.Size = new Size(1324, 29);
            titlebarpanel.TabIndex = 22;
            titlebarpanel.MouseDown += titlebarPanel_MouseDown;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BackgroundImageLayout = ImageLayout.None;
            pictureBox3.Image = Properties.Resources._530815967_748571391111211_2104280294899996801_n_removebg_preview;
            pictureBox3.Location = new Point(12, 9);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(63, 61);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 14;
            pictureBox3.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(1324, 735);
            Controls.Add(titlebarpanel);
            Controls.Add(Welcomelbl);
            Controls.Add(label2);
            Controls.Add(records_panel);
            Controls.Add(Settings_Panel);
            Controls.Add(Logoutbtn);
            Controls.Add(Recordstbn);
            Controls.Add(Accountsbtn);
            Controls.Add(Settingsbtn);
            Controls.Add(Activationbtn);
            Controls.Add(Paybtn);
            Controls.Add(pictureBox2);
            Controls.Add(SearchBox);
            Controls.Add(label1);
            Controls.Add(RackDB);
            Controls.Add(pictureBox3);
            Controls.Add(helpwindowbtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form6";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)RackDB).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            Settings_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            records_panel.ResumeLayout(false);
            titlebarpanel.ResumeLayout(false);
            titlebarpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView RackDB;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel Settings_Panel;
        private Label CreateFClose_Btn;
        private Label MainMinimizebtn;
        private Button PaymentSettingsbtn;
        private Button Mastercard_btn;
        private System.Windows.Forms.Timer Settings_transitionTick;
        private Button Paybtn;
        private Button Accountsbtn;
        private Button Recordstbn;
        private System.Windows.Forms.Timer Refresher;
        private TextBox SearchBox;
        private PictureBox pictureBox2;
        private System.Windows.Forms.Timer Hovertimer;
        private Button button4;
        private ToolTip toolTip1;
        private Button Settingsbtn;
        private Panel records_panel;
        private Button Usagelogbtn;
        private Button Transactionsbtn;
        private Button RFIDsbtn;
        private Label label2;
        private System.Windows.Forms.Timer SecurityCheckTimer;
        private System.Windows.Forms.Timer SecurityEnabler;
        private Label Welcomelbl;
        private Button helpwindowbtn;
        private Button Activationbtn;
        private Button Logoutbtn;
        private Button ActionsLogbtn;
        private Panel panel1;
        private PictureBox pictureBox3;
        private Panel titlebarpanel;
        private Button button2;
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
    }
}