namespace Helmet_Harbour_MK2
{
    partial class RecordsForm
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
            dataGridView1 = new DataGridView();
            Record_Number = new DataGridViewTextBoxColumn();
            Slot = new DataGridViewTextBoxColumn();
            RFIDNum = new DataGridViewTextBoxColumn();
            TimeStart = new DataGridViewTextBoxColumn();
            TimeEnd = new DataGridViewTextBoxColumn();
            Duration = new DataGridViewTextBoxColumn();
            Fee = new DataGridViewTextBoxColumn();
            DateTimeRecorded = new DataGridViewTextBoxColumn();
            Operator = new DataGridViewTextBoxColumn();
            TransactionNum = new DataGridViewTextBoxColumn();
            ReceivedAmount = new DataGridViewTextBoxColumn();
            AmountChange = new DataGridViewTextBoxColumn();
            UserType = new DataGridViewTextBoxColumn();
            titlebarpanel = new Panel();
            label3 = new Label();
            MainMinimizebtn = new Label();
            CreateFClose_Btn = new Label();
            StarDateSelector = new DateTimePicker();
            EndDateSelector = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            searchtxtbox = new TextBox();
            SearchCon = new ComboBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            titlebarpanel.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.PaleGoldenrod;
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.BackgroundColor = Color.LemonChiffon;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Khaki;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = Color.DarkKhaki;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Record_Number, Slot, RFIDNum, TimeStart, TimeEnd, Duration, Fee, DateTimeRecorded, Operator, TransactionNum, ReceivedAmount, AmountChange, UserType });
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(12, 102);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(1300, 541);
            dataGridView1.TabIndex = 0;
            // 
            // Record_Number
            // 
            Record_Number.DataPropertyName = "Record_Number";
            Record_Number.HeaderText = "Record Number";
            Record_Number.Name = "Record_Number";
            Record_Number.ReadOnly = true;
            Record_Number.Width = 60;
            // 
            // Slot
            // 
            Slot.DataPropertyName = "Slot";
            Slot.HeaderText = "Slot";
            Slot.Name = "Slot";
            Slot.ReadOnly = true;
            Slot.Width = 35;
            // 
            // RFIDNum
            // 
            RFIDNum.DataPropertyName = "RFID #";
            RFIDNum.HeaderText = "RFID Number";
            RFIDNum.Name = "RFIDNum";
            RFIDNum.ReadOnly = true;
            // 
            // TimeStart
            // 
            TimeStart.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TimeStart.DataPropertyName = "Time Start";
            TimeStart.HeaderText = "Time Start";
            TimeStart.Name = "TimeStart";
            TimeStart.ReadOnly = true;
            // 
            // TimeEnd
            // 
            TimeEnd.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TimeEnd.DataPropertyName = "Time End";
            TimeEnd.HeaderText = "Time End";
            TimeEnd.Name = "TimeEnd";
            TimeEnd.ReadOnly = true;
            // 
            // Duration
            // 
            Duration.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Duration.DataPropertyName = "Duration";
            Duration.HeaderText = "Duration";
            Duration.Name = "Duration";
            Duration.ReadOnly = true;
            // 
            // Fee
            // 
            Fee.DataPropertyName = "Fee";
            Fee.HeaderText = "Fee";
            Fee.Name = "Fee";
            Fee.ReadOnly = true;
            Fee.Width = 70;
            // 
            // DateTimeRecorded
            // 
            DateTimeRecorded.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DateTimeRecorded.DataPropertyName = "Date Time Recorded";
            DateTimeRecorded.HeaderText = "Date Time Recorded";
            DateTimeRecorded.Name = "DateTimeRecorded";
            DateTimeRecorded.ReadOnly = true;
            // 
            // Operator
            // 
            Operator.DataPropertyName = "Operator";
            Operator.HeaderText = "Operator";
            Operator.Name = "Operator";
            Operator.ReadOnly = true;
            // 
            // TransactionNum
            // 
            TransactionNum.DataPropertyName = "Transaction Num";
            TransactionNum.HeaderText = "Transaction Number";
            TransactionNum.Name = "TransactionNum";
            TransactionNum.ReadOnly = true;
            TransactionNum.Width = 150;
            // 
            // ReceivedAmount
            // 
            ReceivedAmount.DataPropertyName = "Received Amount";
            ReceivedAmount.HeaderText = "Received Amount";
            ReceivedAmount.Name = "ReceivedAmount";
            ReceivedAmount.ReadOnly = true;
            ReceivedAmount.Width = 70;
            // 
            // AmountChange
            // 
            AmountChange.DataPropertyName = "Amount Change";
            AmountChange.HeaderText = "Amount Change";
            AmountChange.Name = "AmountChange";
            AmountChange.ReadOnly = true;
            AmountChange.Width = 70;
            // 
            // UserType
            // 
            UserType.DataPropertyName = "HolderType";
            UserType.HeaderText = "User Type";
            UserType.Name = "UserType";
            UserType.ReadOnly = true;
            // 
            // titlebarpanel
            // 
            titlebarpanel.BackColor = Color.FromArgb(255, 255, 128);
            titlebarpanel.Controls.Add(label3);
            titlebarpanel.Controls.Add(MainMinimizebtn);
            titlebarpanel.Controls.Add(CreateFClose_Btn);
            titlebarpanel.Dock = DockStyle.Top;
            titlebarpanel.Location = new Point(0, 0);
            titlebarpanel.Name = "titlebarpanel";
            titlebarpanel.Size = new Size(1324, 29);
            titlebarpanel.TabIndex = 23;
            titlebarpanel.MouseDown += titlebarPanel_MouseDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 6);
            label3.Name = "label3";
            label3.Size = new Size(131, 17);
            label3.TabIndex = 14;
            label3.Text = "Transaction Records";
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
            MainMinimizebtn.Click += MainMinimizebtn_Click;
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
            CreateFClose_Btn.Click += CreateFClose_Btn_Click;
            // 
            // StarDateSelector
            // 
            StarDateSelector.Location = new Point(86, 44);
            StarDateSelector.Name = "StarDateSelector";
            StarDateSelector.Size = new Size(200, 23);
            StarDateSelector.TabIndex = 24;
            StarDateSelector.ValueChanged += RecordsForm_Load;
            // 
            // EndDateSelector
            // 
            EndDateSelector.Location = new Point(86, 73);
            EndDateSelector.Name = "EndDateSelector";
            EndDateSelector.Size = new Size(200, 23);
            EndDateSelector.TabIndex = 24;
            EndDateSelector.ValueChanged += RecordsForm_Load;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 50);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 25;
            label1.Text = "Start Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 79);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 25;
            label2.Text = "End Date";
            // 
            // searchtxtbox
            // 
            searchtxtbox.Location = new Point(613, 50);
            searchtxtbox.MaxLength = 24;
            searchtxtbox.Name = "searchtxtbox";
            searchtxtbox.Size = new Size(227, 23);
            searchtxtbox.TabIndex = 26;
            searchtxtbox.TextChanged += RecordsForm_Load;
            searchtxtbox.KeyPress += invalidsymbol_KeyPress;
            // 
            // SearchCon
            // 
            SearchCon.DropDownStyle = ComboBoxStyle.DropDownList;
            SearchCon.FormattingEnabled = true;
            SearchCon.Items.AddRange(new object[] { "None", "Operator", "Transaction Number", "RFID Number", "Slot", "Record Number" });
            SearchCon.Location = new Point(405, 50);
            SearchCon.Name = "SearchCon";
            SearchCon.Size = new Size(202, 23);
            SearchCon.TabIndex = 27;
            SearchCon.TextChanged += RecordsForm_Load;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGoldenrodYellow;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.print_black;
            button1.Location = new Point(1265, 50);
            button1.Name = "button1";
            button1.Size = new Size(47, 46);
            button1.TabIndex = 28;
            button1.UseVisualStyleBackColor = false;
            button1.Click += printbtn_click;
            // 
            // RecordsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1324, 655);
            Controls.Add(button1);
            Controls.Add(SearchCon);
            Controls.Add(searchtxtbox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(EndDateSelector);
            Controls.Add(StarDateSelector);
            Controls.Add(titlebarpanel);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RecordsForm";
            Text = "RecordsForm";
            Load += RecordsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            titlebarpanel.ResumeLayout(false);
            titlebarpanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel titlebarpanel;
        private Label MainMinimizebtn;
        private Label CreateFClose_Btn;
        private DateTimePicker StarDateSelector;
        private DateTimePicker EndDateSelector;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox searchtxtbox;
        private ComboBox SearchCon;
        private Button button1;
        private DataGridViewTextBoxColumn Record_Number;
        private DataGridViewTextBoxColumn Slot;
        private DataGridViewTextBoxColumn RFIDNum;
        private DataGridViewTextBoxColumn TimeStart;
        private DataGridViewTextBoxColumn TimeEnd;
        private DataGridViewTextBoxColumn Duration;
        private DataGridViewTextBoxColumn Fee;
        private DataGridViewTextBoxColumn DateTimeRecorded;
        private DataGridViewTextBoxColumn Operator;
        private DataGridViewTextBoxColumn TransactionNum;
        private DataGridViewTextBoxColumn ReceivedAmount;
        private DataGridViewTextBoxColumn AmountChange;
        private DataGridViewTextBoxColumn UserType;
    }
}