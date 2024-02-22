namespace attendanceSystem.userControls
{
    partial class usersPage
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
            usersdataGrid = new DataGridView();
            userID = new DataGridViewTextBoxColumn();
            userName = new DataGridViewTextBoxColumn();
            roleColumn = new DataGridViewTextBoxColumn();
            editColumn = new DataGridViewTextBoxColumn();
            deleteColumn = new DataGridViewTextBoxColumn();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)usersdataGrid).BeginInit();
            SuspendLayout();
            // 
            // usersdataGrid
            // 
            usersdataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            usersdataGrid.BackgroundColor = Color.White;
            usersdataGrid.BorderStyle = BorderStyle.None;
            usersdataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usersdataGrid.Columns.AddRange(new DataGridViewColumn[] { userID, userName, roleColumn, editColumn, deleteColumn });
            usersdataGrid.Location = new Point(79, 114);
            usersdataGrid.Name = "usersdataGrid";
            usersdataGrid.RowHeadersWidth = 51;
            usersdataGrid.Size = new Size(803, 283);
            usersdataGrid.TabIndex = 0;
            usersdataGrid.CellContentClick += dataGridView1_CellContentClick;
            // 
            // userID
            // 
            userID.HeaderText = "userID";
            userID.MinimumWidth = 6;
            userID.Name = "userID";
            // 
            // userName
            // 
            userName.HeaderText = "Name";
            userName.MinimumWidth = 6;
            userName.Name = "userName";
            // 
            // roleColumn
            // 
            roleColumn.HeaderText = "Role";
            roleColumn.MinimumWidth = 6;
            roleColumn.Name = "roleColumn";
            // 
            // editColumn
            // 
            editColumn.HeaderText = "Edit";
            editColumn.MinimumWidth = 6;
            editColumn.Name = "editColumn";
            // 
            // deleteColumn
            // 
            deleteColumn.HeaderText = "Delete";
            deleteColumn.MinimumWidth = 6;
            deleteColumn.Name = "deleteColumn";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(385, 65);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // usersPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label1);
            Controls.Add(usersdataGrid);
            Name = "usersPage";
            Size = new Size(942, 501);
            ((System.ComponentModel.ISupportInitialize)usersdataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView usersdataGrid;
        private DataGridViewTextBoxColumn userID;
        private DataGridViewTextBoxColumn userName;
        private DataGridViewTextBoxColumn roleColumn;
        private DataGridViewTextBoxColumn editColumn;
        private DataGridViewTextBoxColumn deleteColumn;
        private Label label1;
    }
}
