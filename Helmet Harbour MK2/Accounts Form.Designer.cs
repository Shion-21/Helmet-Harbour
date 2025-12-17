namespace Helmet_Harbour_MK2
{
    partial class AccountsForm
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
            AccountDB = new DataGridView();
            idAccounts = new DataGridViewTextBoxColumn();
            Username = new DataGridViewTextBoxColumn();
            Employee_ID = new DataGridViewTextBoxColumn();
            FirstName = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            Password = new DataGridViewTextBoxColumn();
            Access = new DataGridViewTextBoxColumn();
            Creator = new DataGridViewTextBoxColumn();
            Remarks = new DataGridViewTextBoxColumn();
            Addbtn = new Button();
            Deletebtn = new Button();
            toolTip1 = new ToolTip(components);
            Editbtn = new Button();
            CreateMinimizebtn = new Label();
            CreateFClose_Btn = new Label();
            panel1 = new Panel();
            MainMinimizebtn = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            txtSearch = new TextBox();
            comboSearch = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)AccountDB).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // AccountDB
            // 
            AccountDB.AllowUserToAddRows = false;
            AccountDB.AllowUserToDeleteRows = false;
            AccountDB.BackgroundColor = Color.LemonChiffon;
            AccountDB.BorderStyle = BorderStyle.None;
            AccountDB.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            AccountDB.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Khaki;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkKhaki;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            AccountDB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            AccountDB.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AccountDB.Columns.AddRange(new DataGridViewColumn[] { idAccounts, Username, Employee_ID, FirstName, LastName, Password, Access, Creator, Remarks });
            AccountDB.EnableHeadersVisualStyles = false;
            AccountDB.Location = new Point(12, 87);
            AccountDB.Name = "AccountDB";
            AccountDB.ReadOnly = true;
            AccountDB.Size = new Size(800, 458);
            AccountDB.TabIndex = 0;
            AccountDB.CellClick += AccountDB_CellClick;
            // 
            // idAccounts
            // 
            idAccounts.DataPropertyName = "idAccounts";
            idAccounts.HeaderText = "idAccounts";
            idAccounts.Name = "idAccounts";
            idAccounts.ReadOnly = true;
            idAccounts.Visible = false;
            // 
            // Username
            // 
            Username.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Username.DataPropertyName = "Username";
            Username.HeaderText = "Username";
            Username.Name = "Username";
            Username.ReadOnly = true;
            // 
            // Employee_ID
            // 
            Employee_ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Employee_ID.DataPropertyName = "Employee ID";
            Employee_ID.HeaderText = "Employee ID";
            Employee_ID.Name = "Employee_ID";
            Employee_ID.ReadOnly = true;
            // 
            // FirstName
            // 
            FirstName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FirstName.DataPropertyName = "First Name";
            FirstName.HeaderText = "First Name";
            FirstName.Name = "FirstName";
            FirstName.ReadOnly = true;
            // 
            // LastName
            // 
            LastName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            LastName.DataPropertyName = "Last Name";
            LastName.HeaderText = "Last Name";
            LastName.Name = "LastName";
            LastName.ReadOnly = true;
            // 
            // Password
            // 
            Password.DataPropertyName = "Password";
            Password.HeaderText = "Password";
            Password.Name = "Password";
            Password.ReadOnly = true;
            Password.Visible = false;
            // 
            // Access
            // 
            Access.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Access.DataPropertyName = "Access";
            Access.HeaderText = "Access";
            Access.Name = "Access";
            Access.ReadOnly = true;
            // 
            // Creator
            // 
            Creator.DataPropertyName = "Creator";
            Creator.HeaderText = "Creator";
            Creator.Name = "Creator";
            Creator.ReadOnly = true;
            Creator.Visible = false;
            // 
            // Remarks
            // 
            Remarks.DataPropertyName = "Remarks";
            Remarks.HeaderText = "Remarks";
            Remarks.Name = "Remarks";
            Remarks.ReadOnly = true;
            // 
            // Addbtn
            // 
            Addbtn.BackColor = Color.LightGoldenrodYellow;
            Addbtn.FlatStyle = FlatStyle.Flat;
            Addbtn.Image = Properties.Resources.add_black;
            Addbtn.Location = new Point(818, 87);
            Addbtn.Name = "Addbtn";
            Addbtn.Size = new Size(58, 50);
            Addbtn.TabIndex = 1;
            toolTip1.SetToolTip(Addbtn, "Add New Account");
            Addbtn.UseVisualStyleBackColor = false;
            Addbtn.Click += Addbtn_Click;
            // 
            // Deletebtn
            // 
            Deletebtn.BackColor = Color.LightGoldenrodYellow;
            Deletebtn.FlatStyle = FlatStyle.Flat;
            Deletebtn.Image = Properties.Resources.delete_black;
            Deletebtn.Location = new Point(818, 199);
            Deletebtn.Name = "Deletebtn";
            Deletebtn.Size = new Size(58, 50);
            Deletebtn.TabIndex = 1;
            toolTip1.SetToolTip(Deletebtn, "Delete Account");
            Deletebtn.UseVisualStyleBackColor = false;
            Deletebtn.Click += Deletebtn_Click;
            // 
            // Editbtn
            // 
            Editbtn.BackColor = Color.LightGoldenrodYellow;
            Editbtn.FlatStyle = FlatStyle.Flat;
            Editbtn.Image = Properties.Resources.edit_black;
            Editbtn.Location = new Point(818, 143);
            Editbtn.Name = "Editbtn";
            Editbtn.Size = new Size(58, 50);
            Editbtn.TabIndex = 1;
            toolTip1.SetToolTip(Editbtn, "Edit Existing Account");
            Editbtn.UseVisualStyleBackColor = false;
            Editbtn.Click += Editbtn_Click;
            // 
            // CreateMinimizebtn
            // 
            CreateMinimizebtn.AutoSize = true;
            CreateMinimizebtn.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateMinimizebtn.Location = new Point(829, 1);
            CreateMinimizebtn.Name = "CreateMinimizebtn";
            CreateMinimizebtn.Size = new Size(22, 30);
            CreateMinimizebtn.TabIndex = 16;
            CreateMinimizebtn.Text = "-";
            // 
            // CreateFClose_Btn
            // 
            CreateFClose_Btn.AutoSize = true;
            CreateFClose_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateFClose_Btn.Location = new Point(857, 9);
            CreateFClose_Btn.Name = "CreateFClose_Btn";
            CreateFClose_Btn.Size = new Size(19, 20);
            CreateFClose_Btn.TabIndex = 15;
            CreateFClose_Btn.Text = "X";
            CreateFClose_Btn.Click += CreateFClose_Btn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 255, 128);
            panel1.Controls.Add(MainMinimizebtn);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(888, 35);
            panel1.TabIndex = 20;
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
            MainMinimizebtn.Click += MainMinimizebtn_Click;
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
            label4.Click += label4_Click;
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
            label3.Size = new Size(67, 19);
            label3.TabIndex = 3;
            label3.Text = "Accounts";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(188, 58);
            txtSearch.MaxLength = 24;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(190, 23);
            txtSearch.TabIndex = 21;
            txtSearch.TextChanged += AccountsForm_Load;
            txtSearch.KeyPress += invalidsymbol_KeyPress;
            // 
            // comboSearch
            // 
            comboSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSearch.FormattingEnabled = true;
            comboSearch.Items.AddRange(new object[] { "Username", "Employee ID", "Firstname", "Lastname", "Access", "Remarks" });
            comboSearch.Location = new Point(12, 58);
            comboSearch.Name = "comboSearch";
            comboSearch.Size = new Size(170, 23);
            comboSearch.TabIndex = 22;
            comboSearch.TextUpdate += AccountsForm_Load;
            // 
            // AccountsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(888, 557);
            Controls.Add(comboSearch);
            Controls.Add(txtSearch);
            Controls.Add(panel1);
            Controls.Add(CreateMinimizebtn);
            Controls.Add(CreateFClose_Btn);
            Controls.Add(Deletebtn);
            Controls.Add(Editbtn);
            Controls.Add(Addbtn);
            Controls.Add(AccountDB);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AccountsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Accounts";
            Load += AccountsForm_Load;
            ((System.ComponentModel.ISupportInitialize)AccountDB).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView AccountDB;
        private Button Addbtn;
        private Button Deletebtn;
        private ToolTip toolTip1;
        private Button Editbtn;
        private Label CreateMinimizebtn;
        private Label CreateFClose_Btn;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label3;
        private Label MainMinimizebtn;
        private Label label4;
        private TextBox txtSearch;
        private ComboBox comboSearch;
        private DataGridViewTextBoxColumn idAccounts;
        private DataGridViewTextBoxColumn Username;
        private DataGridViewTextBoxColumn Employee_ID;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn Password;
        private DataGridViewTextBoxColumn Access;
        private DataGridViewTextBoxColumn Creator;
        private DataGridViewTextBoxColumn Remarks;
    }
}