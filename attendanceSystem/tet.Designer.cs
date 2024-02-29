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
            attendace1 = new userControls.Attendace();
            SuspendLayout();
            // 
            // attendace1
            // 
            attendace1.Location = new Point(55, -49);
            attendace1.Name = "attendace1";
            attendace1.Size = new Size(1178, 626);
            attendace1.TabIndex = 0;
            // 
            // tet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 623);
            Controls.Add(attendace1);
            Name = "tet";
            Text = "tet";
            ResumeLayout(false);
        }

        #endregion

        private userControls.Attendace attendace1;
    }
}