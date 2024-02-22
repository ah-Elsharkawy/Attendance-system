namespace attendanceSystem
{
    partial class tet
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
            userControlAddUser1 = new UserControlAddUser();
            SuspendLayout();
            // 
            // userControlAddUser1
            // 
            userControlAddUser1.BackColor = Color.White;
            userControlAddUser1.Dock = DockStyle.Fill;
            userControlAddUser1.Font = new Font("Century Gothic", 9.75F);
            userControlAddUser1.Location = new Point(0, 0);
            userControlAddUser1.Margin = new Padding(4);
            userControlAddUser1.Name = "userControlAddUser1";
            userControlAddUser1.Size = new Size(1025, 537);
            userControlAddUser1.TabIndex = 0;
            // 
            // tet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1025, 537);
            Controls.Add(userControlAddUser1);
            Name = "tet";
            Text = "tet";
            ResumeLayout(false);
        }

        #endregion

        private UserControlAddUser userControlAddUser1;
    }
}