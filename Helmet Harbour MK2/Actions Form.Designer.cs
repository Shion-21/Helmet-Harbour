namespace Helmet_Harbour_MK2
{
    partial class ActionsForm
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
            ActionsDB = new DataGridView();
            ActionID = new DataGridViewTextBoxColumn();
            Category = new DataGridViewTextBoxColumn();
            Remarks = new DataGridViewTextBoxColumn();
            Username = new DataGridViewTextBoxColumn();
            EmployeeNumber = new DataGridViewTextBoxColumn();
            DateAndTime = new DataGridViewTextBoxColumn();
            CreateFClose_Btn = new Label();
            comboSearch = new ComboBox();
            txtSearch = new TextBox();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            MainMinimizebtn = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            EndDateSelector = new DateTimePicker();
            StarDateSelector = new DateTimePicker();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)ActionsDB).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ActionsDB
            // 
            ActionsDB.AllowUserToAddRows = false;
            ActionsDB.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.PaleGoldenrod;
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkKhaki;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            ActionsDB.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            ActionsDB.BackgroundColor = Color.LemonChiffon;
            ActionsDB.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ActionsDB.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Khaki;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.DarkKhaki;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            ActionsDB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            ActionsDB.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ActionsDB.Columns.AddRange(new DataGridViewColumn[] { ActionID, Category, Remarks, Username, EmployeeNumber, DateAndTime });
            ActionsDB.EnableHeadersVisualStyles = false;
            ActionsDB.Location = new Point(12, 112);
            ActionsDB.Name = "ActionsDB";
            ActionsDB.ReadOnly = true;
            ActionsDB.RowHeadersVisible = false;
            ActionsDB.Size = new Size(776, 448);
            ActionsDB.TabIndex = 0;
            // 
            // ActionID
            // 
            ActionID.DataPropertyName = "Actions ID";
            ActionID.HeaderText = "ActionID";
            ActionID.Name = "ActionID";
            ActionID.ReadOnly = true;
            ActionID.Visible = false;
            // 
            // Category
            // 
            Category.DataPropertyName = "Action";
            Category.HeaderText = "Category";
            Category.Name = "Category";
            Category.ReadOnly = true;
            // 
            // Remarks
            // 
            Remarks.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Remarks.DataPropertyName = "Remarks";
            Remarks.HeaderText = "Remarks";
            Remarks.Name = "Remarks";
            Remarks.ReadOnly = true;
            // 
            // Username
            // 
            Username.DataPropertyName = "User";
            Username.HeaderText = "Username";
            Username.Name = "Username";
            Username.ReadOnly = true;
            // 
            // EmployeeNumber
            // 
            EmployeeNumber.DataPropertyName = "Employee Number";
            EmployeeNumber.HeaderText = "Employee Number";
            EmployeeNumber.Name = "EmployeeNumber";
            EmployeeNumber.ReadOnly = true;
            // 
            // DateAndTime
            // 
            DateAndTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DateAndTime.DataPropertyName = "Date & Time";
            DateAndTime.HeaderText = "Date & Time";
            DateAndTime.Name = "DateAndTime";
            DateAndTime.ReadOnly = true;
            DateAndTime.Width = 89;
            // 
            // CreateFClose_Btn
            // 
            CreateFClose_Btn.AutoSize = true;
            CreateFClose_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateFClose_Btn.Location = new Point(769, 9);
            CreateFClose_Btn.Name = "CreateFClose_Btn";
            CreateFClose_Btn.Size = new Size(19, 20);
            CreateFClose_Btn.TabIndex = 13;
            CreateFClose_Btn.Text = "X";
            // 
            // comboSearch
            // 
            comboSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSearch.FormattingEnabled = true;
            comboSearch.Items.AddRange(new object[] { "Username", "Employee Number", "Action", "Remarks" });
            comboSearch.Location = new Point(369, 83);
            comboSearch.Name = "comboSearch";
            comboSearch.Size = new Size(163, 23);
            comboSearch.TabIndex = 14;
            comboSearch.TextChanged += ActionsForm_Load;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(538, 83);
            txtSearch.MaxLength = 24;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(250, 23);
            txtSearch.TabIndex = 16;
            txtSearch.TextChanged += ActionsForm_Load;
            txtSearch.KeyPress += invalidsymbol_KeyPress;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 255, 128);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(MainMinimizebtn);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 35);
            panel1.TabIndex = 21;
            panel1.MouseDown += titlebarPanel_MouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(741, 1);
            label1.Name = "label1";
            label1.Size = new Size(22, 30);
            label1.TabIndex = 19;
            label1.Text = "-";
            label1.Click += MainMinimizebtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(769, 9);
            label2.Name = "label2";
            label2.Size = new Size(19, 20);
            label2.TabIndex = 18;
            label2.Text = "X";
            label2.Click += CreateFClose_Btn_Click;
            // 
            // MainMinimizebtn
            // 
            MainMinimizebtn.AutoSize = true;
            MainMinimizebtn.BackColor = Color.Transparent;
            MainMinimizebtn.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MainMinimizebtn.Location = new Point(838, -1);
            MainMinimizebtn.Name = "MainMinimizebtn";
            MainMinimizebtn.Size = new Size(22, 30);
            MainMinimizebtn.TabIndex = 17;
            MainMinimizebtn.Text = "-";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(866, 7);
            label4.Name = "label4";
            label4.Size = new Size(19, 20);
            label4.TabIndex = 16;
            label4.Text = "X";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.manage_accounts_black1;
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
            label3.Size = new Size(80, 19);
            label3.TabIndex = 3;
            label3.Text = "Actions log";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 89);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 28;
            label5.Text = "End Date";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 60);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 29;
            label6.Text = "Start Date";
            // 
            // EndDateSelector
            // 
            EndDateSelector.Location = new Point(76, 83);
            EndDateSelector.Name = "EndDateSelector";
            EndDateSelector.Size = new Size(200, 23);
            EndDateSelector.TabIndex = 26;
            EndDateSelector.ValueChanged += ActionsForm_Load;
            // 
            // StarDateSelector
            // 
            StarDateSelector.Location = new Point(76, 54);
            StarDateSelector.Name = "StarDateSelector";
            StarDateSelector.Size = new Size(200, 23);
            StarDateSelector.TabIndex = 27;
            StarDateSelector.ValueChanged += ActionsForm_Load;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGoldenrodYellow;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.print_black;
            button1.Location = new Point(750, 41);
            button1.Name = "button1";
            button1.Size = new Size(38, 39);
            button1.TabIndex = 30;
            button1.UseVisualStyleBackColor = false;
            button1.Click += printbtn_click;
            // 
            // ActionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(800, 572);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(EndDateSelector);
            Controls.Add(StarDateSelector);
            Controls.Add(panel1);
            Controls.Add(txtSearch);
            Controls.Add(comboSearch);
            Controls.Add(CreateFClose_Btn);
            Controls.Add(ActionsDB);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ActionsForm";
            Text = "ActionsForm";
            Load += ActionsForm_Load;
            ((System.ComponentModel.ISupportInitialize)ActionsDB).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView ActionsDB;
        private Label CreateFClose_Btn;
        private ComboBox comboSearch;
        private TextBox txtSearch;
        private Panel panel1;
        private Label MainMinimizebtn;
        private Label label4;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label1;
        private Label label2;
        private Label label5;
        private Label label6;
        private DateTimePicker EndDateSelector;
        private DateTimePicker StarDateSelector;
        private Button button1;
        private DataGridViewTextBoxColumn ActionID;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn Remarks;
        private DataGridViewTextBoxColumn Username;
        private DataGridViewTextBoxColumn EmployeeNumber;
        private DataGridViewTextBoxColumn DateAndTime;
    }
}