namespace Helmet_Harbour_MK2
{
    partial class Add_Rack
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
            label1 = new Label();
            Slottxtbox = new TextBox();
            Slotlbl = new Label();
            label3 = new Label();
            button1 = new Button();
            panel1 = new Panel();
            CreateFClose_Btn = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 85);
            label1.Name = "label1";
            label1.Size = new Size(299, 30);
            label1.TabIndex = 0;
            label1.Text = "Slot is bound to the slot number displayed on the rack.\r\nAdding or changing the slot to preference will not work\r\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Slottxtbox
            // 
            Slottxtbox.Location = new Point(85, 145);
            Slottxtbox.MaxLength = 3;
            Slottxtbox.Name = "Slottxtbox";
            Slottxtbox.Size = new Size(210, 23);
            Slottxtbox.TabIndex = 1;
            Slottxtbox.KeyPress += invalidsymbol_KeyPress;
            // 
            // Slotlbl
            // 
            Slotlbl.AutoSize = true;
            Slotlbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Slotlbl.Location = new Point(41, 148);
            Slotlbl.Name = "Slotlbl";
            Slotlbl.Size = new Size(29, 15);
            Slotlbl.TabIndex = 0;
            Slotlbl.Text = "Slot";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Brown;
            label3.Location = new Point(137, 58);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 2;
            label3.Text = "Warning";
            // 
            // button1
            // 
            button1.BackColor = Color.LightGoldenrodYellow;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(137, 199);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 25;
            button1.Text = "Continue";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 255, 128);
            panel1.Controls.Add(CreateFClose_Btn);
            panel1.Controls.Add(label4);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(346, 35);
            panel1.TabIndex = 26;
            // 
            // CreateFClose_Btn
            // 
            CreateFClose_Btn.AutoSize = true;
            CreateFClose_Btn.BackColor = Color.Transparent;
            CreateFClose_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateFClose_Btn.Location = new Point(324, 7);
            CreateFClose_Btn.Name = "CreateFClose_Btn";
            CreateFClose_Btn.Size = new Size(19, 20);
            CreateFClose_Btn.TabIndex = 12;
            CreateFClose_Btn.Text = "X";
            CreateFClose_Btn.Click += CreateFClose_Btn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(3, 7);
            label4.Name = "label4";
            label4.Size = new Size(68, 19);
            label4.TabIndex = 3;
            label4.Text = "Add Rack";
            label4.Click += label4_Click;
            // 
            // Add_Rack
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(346, 234);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(Slottxtbox);
            Controls.Add(Slotlbl);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Add_Rack";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add_Rack";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox Slottxtbox;
        private Label Slotlbl;
        private Label label3;
        private Button button1;
        private Panel panel1;
        private Label CreateFClose_Btn;
        private Label label4;
    }
}