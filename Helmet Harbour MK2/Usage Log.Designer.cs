namespace Helmet_Harbour_MK2
{
    partial class UsageForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            idusagelog = new DataGridViewTextBoxColumn();
            Slot = new DataGridViewTextBoxColumn();
            RFIDNum = new DataGridViewTextBoxColumn();
            CardID = new DataGridViewTextBoxColumn();
            DateAndTime = new DataGridViewTextBoxColumn();
            SearchCon = new ComboBox();
            searchtxtbox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            EndDateSelector = new DateTimePicker();
            StarDateSelector = new DateTimePicker();
            titlebarpanel = new Panel();
            label4 = new Label();
            label5 = new Label();
            UsageLogForm = new Label();
            MainMinimizebtn = new Label();
            CreateFClose_Btn = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            titlebarpanel.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = Color.LemonChiffon;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Khaki;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.DarkKhaki;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idusagelog, Slot, RFIDNum, CardID, DateAndTime });
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(12, 101);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(776, 408);
            dataGridView1.TabIndex = 0;
            // 
            // idusagelog
            // 
            idusagelog.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            idusagelog.DataPropertyName = "idusage log";
            idusagelog.HeaderText = "Usage ID";
            idusagelog.Name = "idusagelog";
            idusagelog.ReadOnly = true;
            idusagelog.Visible = false;
            // 
            // Slot
            // 
            Slot.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Slot.DataPropertyName = "Slot";
            Slot.HeaderText = "Slot";
            Slot.Name = "Slot";
            Slot.ReadOnly = true;
            Slot.Width = 51;
            // 
            // RFIDNum
            // 
            RFIDNum.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RFIDNum.DataPropertyName = "RFID No.";
            RFIDNum.HeaderText = "RFID Number";
            RFIDNum.Name = "RFIDNum";
            RFIDNum.ReadOnly = true;
            // 
            // CardID
            // 
            CardID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CardID.DataPropertyName = "Card ID";
            CardID.HeaderText = "Card ID";
            CardID.Name = "CardID";
            CardID.ReadOnly = true;
            // 
            // DateAndTime
            // 
            DateAndTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DateAndTime.DataPropertyName = "Date & Time";
            DateAndTime.HeaderText = "Date & Time";
            DateAndTime.Name = "DateAndTime";
            DateAndTime.ReadOnly = true;
            // 
            // SearchCon
            // 
            SearchCon.DropDownStyle = ComboBoxStyle.DropDownList;
            SearchCon.FormattingEnabled = true;
            SearchCon.Items.AddRange(new object[] { "None", "Usage ID", "Slot", "RFID Number", "Card ID", "Date & Time" });
            SearchCon.Location = new Point(352, 70);
            SearchCon.Name = "SearchCon";
            SearchCon.Size = new Size(202, 23);
            SearchCon.TabIndex = 33;
            SearchCon.TextChanged += UsageForm_Load;
            // 
            // searchtxtbox
            // 
            searchtxtbox.Location = new Point(560, 70);
            searchtxtbox.MaxLength = 30;
            searchtxtbox.Name = "searchtxtbox";
            searchtxtbox.Size = new Size(227, 23);
            searchtxtbox.TabIndex = 32;
            searchtxtbox.TextChanged += UsageForm_Load;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 78);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 30;
            label2.Text = "End Date";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 49);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 31;
            label1.Text = "Start Date";
            // 
            // EndDateSelector
            // 
            EndDateSelector.Location = new Point(76, 72);
            EndDateSelector.Name = "EndDateSelector";
            EndDateSelector.Size = new Size(200, 23);
            EndDateSelector.TabIndex = 28;
            EndDateSelector.ValueChanged += UsageForm_Load;
            // 
            // StarDateSelector
            // 
            StarDateSelector.Location = new Point(76, 43);
            StarDateSelector.Name = "StarDateSelector";
            StarDateSelector.Size = new Size(200, 23);
            StarDateSelector.TabIndex = 29;
            StarDateSelector.ValueChanged += UsageForm_Load;
            // 
            // titlebarpanel
            // 
            titlebarpanel.BackColor = Color.FromArgb(255, 255, 128);
            titlebarpanel.Controls.Add(label4);
            titlebarpanel.Controls.Add(label5);
            titlebarpanel.Controls.Add(UsageLogForm);
            titlebarpanel.Controls.Add(MainMinimizebtn);
            titlebarpanel.Controls.Add(CreateFClose_Btn);
            titlebarpanel.Dock = DockStyle.Top;
            titlebarpanel.Location = new Point(0, 0);
            titlebarpanel.Name = "titlebarpanel";
            titlebarpanel.Size = new Size(800, 29);
            titlebarpanel.TabIndex = 34;
            titlebarpanel.MouseDown += titlebarPanel_MouseDown;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(750, -2);
            label4.Name = "label4";
            label4.Size = new Size(22, 30);
            label4.TabIndex = 16;
            label4.Text = "-";
            label4.Click += UsageMinimizebtn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(778, 6);
            label5.Name = "label5";
            label5.Size = new Size(19, 20);
            label5.TabIndex = 15;
            label5.Text = "X";
            label5.Click += UsageClose_Btn_Click;
            // 
            // UsageLogForm
            // 
            UsageLogForm.AutoSize = true;
            UsageLogForm.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UsageLogForm.Location = new Point(12, 6);
            UsageLogForm.Name = "UsageLogForm";
            UsageLogForm.Size = new Size(72, 17);
            UsageLogForm.TabIndex = 14;
            UsageLogForm.Text = "Usage Log";
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
            // 
            // UsageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(800, 521);
            Controls.Add(titlebarpanel);
            Controls.Add(SearchCon);
            Controls.Add(searchtxtbox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(EndDateSelector);
            Controls.Add(StarDateSelector);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UsageForm";
            Text = "Form1";
            Load += UsageForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            titlebarpanel.ResumeLayout(false);
            titlebarpanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox SearchCon;
        private TextBox searchtxtbox;
        private Label label2;
        private Label label1;
        private DateTimePicker EndDateSelector;
        private DateTimePicker StarDateSelector;
        private Panel titlebarpanel;
        private Label UsageLogForm;
        private Label MainMinimizebtn;
        private Label CreateFClose_Btn;
        private Label label4;
        private Label label5;
        private DataGridViewTextBoxColumn idusagelog;
        private DataGridViewTextBoxColumn Slot;
        private DataGridViewTextBoxColumn RFIDNum;
        private DataGridViewTextBoxColumn CardID;
        private DataGridViewTextBoxColumn DateAndTime;
    }
}