namespace attendanceSystem.userControls
{
    partial class adminPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            usersGridView = new DataGridView();
            userId = new DataGridViewTextBoxColumn();
            userName = new DataGridViewTextBoxColumn();
            userEmail = new DataGridViewTextBoxColumn();
            userRole = new DataGridViewTextBoxColumn();
            editBtn = new DataGridViewButtonColumn();
            deleteBtn = new DataGridViewButtonColumn();
            searchByNameBox = new TextBox();
            nxtPgaeBtn = new Button();
            prvPageBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)usersGridView).BeginInit();
            SuspendLayout();
            // 
            // usersGridView
            // 
            usersGridView.AllowUserToAddRows = false;
            usersGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.LightSkyBlue;
            usersGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            usersGridView.BackgroundColor = Color.MintCream;
            usersGridView.BorderStyle = BorderStyle.None;
            usersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usersGridView.Columns.AddRange(new DataGridViewColumn[] { userId, userName, userEmail, userRole, editBtn, deleteBtn });
            usersGridView.GridColor = Color.MediumBlue;
            usersGridView.Location = new Point(40, 123);
            usersGridView.Name = "usersGridView";
            usersGridView.ReadOnly = true;
            usersGridView.RowHeadersWidth = 51;
            usersGridView.Size = new Size(810, 277);
            usersGridView.TabIndex = 0;
            usersGridView.CellContentClick += usersGridView_CellContentClick;
            // 
            // userId
            // 
            userId.HeaderText = "ID";
            userId.MinimumWidth = 6;
            userId.Name = "userId";
            userId.ReadOnly = true;
            userId.Width = 125;
            // 
            // userName
            // 
            userName.HeaderText = "Name";
            userName.MinimumWidth = 6;
            userName.Name = "userName";
            userName.ReadOnly = true;
            userName.Width = 125;
            // 
            // userEmail
            // 
            userEmail.HeaderText = "Email";
            userEmail.MinimumWidth = 6;
            userEmail.Name = "userEmail";
            userEmail.ReadOnly = true;
            userEmail.Width = 125;
            // 
            // userRole
            // 
            userRole.HeaderText = "Role";
            userRole.MinimumWidth = 6;
            userRole.Name = "userRole";
            userRole.ReadOnly = true;
            userRole.Width = 125;
            // 
            // editBtn
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(128, 128, 255);
            editBtn.DefaultCellStyle = dataGridViewCellStyle2;
            editBtn.HeaderText = "Edit";
            editBtn.MinimumWidth = 6;
            editBtn.Name = "editBtn";
            editBtn.ReadOnly = true;
            editBtn.Text = "edit";
            editBtn.UseColumnTextForButtonValue = true;
            editBtn.Width = 125;
            // 
            // deleteBtn
            // 
            deleteBtn.HeaderText = "Delete";
            deleteBtn.MinimumWidth = 6;
            deleteBtn.Name = "deleteBtn";
            deleteBtn.ReadOnly = true;
            deleteBtn.Text = "delete";
            deleteBtn.UseColumnTextForButtonValue = true;
            deleteBtn.Width = 125;
            // 
            // searchByNameBox
            // 
            searchByNameBox.ForeColor = Color.DarkGray;
            searchByNameBox.Location = new Point(315, 59);
            searchByNameBox.Name = "searchByNameBox";
            searchByNameBox.Size = new Size(249, 27);
            searchByNameBox.TabIndex = 1;
            searchByNameBox.Text = "search by name";
            searchByNameBox.TextChanged += searchByNameBox_TextChanged;
            searchByNameBox.Enter += searchByNameBox_Enter;
            searchByNameBox.Leave += searchByNameBox_Leave;
            // 
            // nxtPgaeBtn
            // 
            nxtPgaeBtn.Location = new Point(449, 406);
            nxtPgaeBtn.Name = "nxtPgaeBtn";
            nxtPgaeBtn.Size = new Size(94, 29);
            nxtPgaeBtn.TabIndex = 2;
            nxtPgaeBtn.Text = "nextPage";
            nxtPgaeBtn.UseVisualStyleBackColor = true;
            nxtPgaeBtn.Click += nxtPgaeBtn_Click;
            // 
            // prvPageBtn
            // 
            prvPageBtn.Location = new Point(294, 406);
            prvPageBtn.Name = "prvPageBtn";
            prvPageBtn.Size = new Size(94, 29);
            prvPageBtn.TabIndex = 3;
            prvPageBtn.Text = "prevPage";
            prvPageBtn.UseVisualStyleBackColor = true;
            prvPageBtn.Click += prvPageBtn_Click;
            // 
            // adminPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(prvPageBtn);
            Controls.Add(nxtPgaeBtn);
            Controls.Add(searchByNameBox);
            Controls.Add(usersGridView);
            Name = "adminPanel";
            Size = new Size(887, 480);
            Load += adminPanel_Load;
            ((System.ComponentModel.ISupportInitialize)usersGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView usersGridView;
        private TextBox searchByNameBox;
        private Button nxtPgaeBtn;
        private Button prvPageBtn;
        private DataGridViewTextBoxColumn userId;
        private DataGridViewTextBoxColumn userName;
        private DataGridViewTextBoxColumn userEmail;
        private DataGridViewTextBoxColumn userRole;
        private DataGridViewButtonColumn editBtn;
        private DataGridViewButtonColumn deleteBtn;
    }
}
