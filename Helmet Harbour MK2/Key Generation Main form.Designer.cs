namespace Helmet_Harbour_MK2
{
    partial class Form5
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
            Save_btn = new Label();
            Passkeytxtbox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // Save_btn
            // 
            Save_btn.AutoSize = true;
            Save_btn.Cursor = Cursors.Hand;
            Save_btn.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Save_btn.Location = new Point(393, 182);
            Save_btn.Name = "Save_btn";
            Save_btn.Size = new Size(36, 17);
            Save_btn.TabIndex = 0;
            Save_btn.Text = "Save";
            Save_btn.Click += Save_btn_Click;
            // 
            // Passkeytxtbox
            // 
            Passkeytxtbox.BackColor = SystemColors.InactiveBorder;
            Passkeytxtbox.Location = new Point(74, 60);
            Passkeytxtbox.Multiline = true;
            Passkeytxtbox.Name = "Passkeytxtbox";
            Passkeytxtbox.ReadOnly = true;
            Passkeytxtbox.Size = new Size(305, 106);
            Passkeytxtbox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(119, 17);
            label1.TabIndex = 2;
            label1.Text = "Generate Pass key";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(74, 42);
            label2.Name = "label2";
            label2.Size = new Size(116, 15);
            label2.TabIndex = 3;
            label2.Text = "Forgot password key";
            toolTip1.SetToolTip(label2, "Key generation for use in forgot password incase of forgotten or lost password");
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(452, 220);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Passkeytxtbox);
            Controls.Add(Save_btn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form5";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Form5";
            Load += Form5_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Save_btn;
        private TextBox Passkeytxtbox;
        private Label label1;
        private Label label2;
        private ToolTip toolTip1;
    }
}