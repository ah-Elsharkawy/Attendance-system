namespace attendanceSystem
{
    partial class mainForm
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
            panel1 = new Panel();
            LogoutBtn = new Button();
            addUserBtn = new Button();
            reportsBtn = new Button();
            attendanceBtn = new Button();
            usersBtn = new Button();
            panel4 = new Panel();
            sidePanel = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            label2 = new Label();
            panel5 = new Panel();
            currentUserNameLabel = new Label();
            label3 = new Label();
            pagesPanel = new Panel();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Indigo;
            panel1.Controls.Add(LogoutBtn);
            panel1.Controls.Add(addUserBtn);
            panel1.Controls.Add(reportsBtn);
            panel1.Controls.Add(attendanceBtn);
            panel1.Controls.Add(usersBtn);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(252, 521);
            panel1.TabIndex = 0;
            // 
            // LogoutBtn
            // 
            LogoutBtn.CausesValidation = false;
            LogoutBtn.Dock = DockStyle.Top;
            LogoutBtn.FlatAppearance.BorderSize = 0;
            LogoutBtn.FlatStyle = FlatStyle.Flat;
            LogoutBtn.ForeColor = Color.White;
            LogoutBtn.Image = Properties.Resources.logout;
            LogoutBtn.ImageAlign = ContentAlignment.MiddleLeft;
            LogoutBtn.Location = new Point(8, 364);
            LogoutBtn.Name = "LogoutBtn";
            LogoutBtn.Size = new Size(244, 50);
            LogoutBtn.TabIndex = 15;
            LogoutBtn.Text = "Logout";
            LogoutBtn.UseVisualStyleBackColor = true;
            LogoutBtn.Click += LogoutBtn_Click;
            // 
            // addUserBtn
            // 
            addUserBtn.CausesValidation = false;
            addUserBtn.Dock = DockStyle.Top;
            addUserBtn.FlatAppearance.BorderSize = 0;
            addUserBtn.FlatStyle = FlatStyle.Flat;
            addUserBtn.ForeColor = Color.White;
            addUserBtn.Image = Properties.Resources.add_user;
            addUserBtn.ImageAlign = ContentAlignment.MiddleLeft;
            addUserBtn.Location = new Point(8, 314);
            addUserBtn.Name = "addUserBtn";
            addUserBtn.Size = new Size(244, 50);
            addUserBtn.TabIndex = 14;
            addUserBtn.Text = "Add user";
            addUserBtn.UseVisualStyleBackColor = true;
            addUserBtn.Click += addUserBtn_Click;
            // 
            // reportsBtn
            // 
            reportsBtn.CausesValidation = false;
            reportsBtn.Dock = DockStyle.Top;
            reportsBtn.FlatAppearance.BorderSize = 0;
            reportsBtn.FlatStyle = FlatStyle.Flat;
            reportsBtn.ForeColor = Color.White;
            reportsBtn.Image = Properties.Resources.report__1_;
            reportsBtn.ImageAlign = ContentAlignment.MiddleLeft;
            reportsBtn.Location = new Point(8, 264);
            reportsBtn.Name = "reportsBtn";
            reportsBtn.Size = new Size(244, 50);
            reportsBtn.TabIndex = 12;
            reportsBtn.Text = "Reports";
            reportsBtn.UseVisualStyleBackColor = true;
            reportsBtn.Click += reportsBtn_Click;
            // 
            // attendanceBtn
            // 
            attendanceBtn.CausesValidation = false;
            attendanceBtn.Dock = DockStyle.Top;
            attendanceBtn.FlatAppearance.BorderSize = 0;
            attendanceBtn.FlatStyle = FlatStyle.Flat;
            attendanceBtn.ForeColor = Color.White;
            attendanceBtn.Image = Properties.Resources.calendar;
            attendanceBtn.ImageAlign = ContentAlignment.MiddleLeft;
            attendanceBtn.Location = new Point(8, 214);
            attendanceBtn.Name = "attendanceBtn";
            attendanceBtn.Size = new Size(244, 50);
            attendanceBtn.TabIndex = 10;
            attendanceBtn.Text = "Attendance";
            attendanceBtn.UseVisualStyleBackColor = true;
            attendanceBtn.Click += attendanceBtn_Click;
            // 
            // usersBtn
            // 
            usersBtn.CausesValidation = false;
            usersBtn.Dock = DockStyle.Top;
            usersBtn.FlatAppearance.BorderSize = 0;
            usersBtn.FlatStyle = FlatStyle.Flat;
            usersBtn.ForeColor = Color.White;
            usersBtn.Image = Properties.Resources.multiple_users_silhouette;
            usersBtn.ImageAlign = ContentAlignment.MiddleLeft;
            usersBtn.Location = new Point(8, 164);
            usersBtn.Name = "usersBtn";
            usersBtn.Size = new Size(244, 50);
            usersBtn.TabIndex = 9;
            usersBtn.Text = "Users";
            usersBtn.UseVisualStyleBackColor = true;
            usersBtn.Click += usersBtn_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(sidePanel);
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 164);
            panel4.Name = "panel4";
            panel4.Size = new Size(8, 357);
            panel4.TabIndex = 1;
            // 
            // sidePanel
            // 
            sidePanel.BackColor = Color.White;
            sidePanel.ForeColor = Color.WhiteSmoke;
            sidePanel.Location = new Point(0, 0);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(8, 50);
            sidePanel.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Indigo;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(252, 164);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(8, 133);
            label1.Name = "label1";
            label1.Size = new Size(238, 20);
            label1.TabIndex = 1;
            label1.Text = "attendance management system";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.graduation;
            pictureBox1.Location = new Point(70, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(109, 118);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(label2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(252, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(930, 74);
            panel3.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 27);
            label2.Name = "label2";
            label2.Size = new Size(238, 20);
            label2.TabIndex = 2;
            label2.Text = "attendance management system";
            // 
            // panel5
            // 
            panel5.BackColor = Color.Indigo;
            panel5.Controls.Add(currentUserNameLabel);
            panel5.Controls.Add(label3);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(252, 74);
            panel5.Name = "panel5";
            panel5.Size = new Size(930, 56);
            panel5.TabIndex = 2;
            // 
            // currentUserNameLabel
            // 
            currentUserNameLabel.AutoSize = true;
            currentUserNameLabel.ForeColor = SystemColors.Window;
            currentUserNameLabel.Location = new Point(142, 16);
            currentUserNameLabel.Name = "currentUserNameLabel";
            currentUserNameLabel.Size = new Size(39, 20);
            currentUserNameLabel.TabIndex = 3;
            currentUserNameLabel.Text = "user";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Window;
            label3.Location = new Point(43, 16);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 2;
            label3.Text = "Welcome: ";
            // 
            // pagesPanel
            // 
            pagesPanel.Dock = DockStyle.Fill;
            pagesPanel.Location = new Point(252, 130);
            pagesPanel.Name = "pagesPanel";
            pagesPanel.Size = new Size(930, 391);
            pagesPanel.TabIndex = 3;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1182, 521);
            Controls.Add(pagesPanel);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ForeColor = Color.Indigo;
            Name = "mainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "mainForm";
            WindowState = FormWindowState.Maximized;
            Load += mainForm_Load;
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel3;
        private Panel panel4;
        private Label label2;
        private Panel panel5;
        private Label label3;
        private Panel sidePanel;
        private Label currentUserNameLabel;
        private Button reportsBtn;
        private Button attendanceBtn;
        private Button usersBtn;
        private Button LogoutBtn;
        private Button addUserBtn;
        private Panel pagesPanel;
    }
}