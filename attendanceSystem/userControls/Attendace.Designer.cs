namespace attendanceSystem.userControls
{
    partial class Attendace
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
            tabControl1 = new TabControl();
            tabPageMarkAttendance = new TabPage();
            panel6 = new Panel();
            comboBoxAttendanceClass = new ComboBox();
            label1 = new Label();
            dataGridViewStudentAtt = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            RegNo = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Status = new DataGridViewComboBoxColumn();
            panel5 = new Panel();
            panel3 = new Panel();
            panel12 = new Panel();
            panel4 = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            label14 = new Label();
            label15 = new Label();
            dateTimePickerAttendance = new DateTimePicker();
            tabControl1.SuspendLayout();
            tabPageMarkAttendance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudentAtt).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Alignment = TabAlignment.Bottom;
            tabControl1.Anchor = AnchorStyles.None;
            tabControl1.Controls.Add(tabPageMarkAttendance);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(942, 501);
            tabControl1.TabIndex = 3;
            // 
            // tabPageMarkAttendance
            // 
            tabPageMarkAttendance.Controls.Add(panel6);
            tabPageMarkAttendance.Controls.Add(comboBoxAttendanceClass);
            tabPageMarkAttendance.Controls.Add(label1);
            tabPageMarkAttendance.Controls.Add(dataGridViewStudentAtt);
            tabPageMarkAttendance.Controls.Add(panel5);
            tabPageMarkAttendance.Controls.Add(panel3);
            tabPageMarkAttendance.Controls.Add(panel12);
            tabPageMarkAttendance.Controls.Add(panel4);
            tabPageMarkAttendance.Controls.Add(panel1);
            tabPageMarkAttendance.Controls.Add(panel2);
            tabPageMarkAttendance.Controls.Add(label14);
            tabPageMarkAttendance.Controls.Add(label15);
            tabPageMarkAttendance.Controls.Add(dateTimePickerAttendance);
            tabPageMarkAttendance.Location = new Point(4, 4);
            tabPageMarkAttendance.Name = "tabPageMarkAttendance";
            tabPageMarkAttendance.Padding = new Padding(3);
            tabPageMarkAttendance.Size = new Size(934, 468);
            tabPageMarkAttendance.TabIndex = 0;
            tabPageMarkAttendance.Text = "Class Report";
            tabPageMarkAttendance.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            panel6.BackColor = Color.LightGray;
            panel6.Location = new Point(549, 100);
            panel6.Name = "panel6";
            panel6.Size = new Size(270, 2);
            panel6.TabIndex = 53;
            // 
            // comboBoxAttendanceClass
            // 
            comboBoxAttendanceClass.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAttendanceClass.FlatStyle = FlatStyle.Flat;
            comboBoxAttendanceClass.Font = new Font("Century Gothic", 9.75F);
            comboBoxAttendanceClass.ForeColor = Color.Black;
            comboBoxAttendanceClass.FormattingEnabled = true;
            comboBoxAttendanceClass.Items.AddRange(new object[] { "PD", "OS", "AI" });
            comboBoxAttendanceClass.Location = new Point(550, 72);
            comboBoxAttendanceClass.Name = "comboBoxAttendanceClass";
            comboBoxAttendanceClass.Size = new Size(270, 29);
            comboBoxAttendanceClass.TabIndex = 54;
            comboBoxAttendanceClass.SelectedIndexChanged += comboBoxAttendanceClass_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold);
            label1.Location = new Point(549, 50);
            label1.Name = "label1";
            label1.Size = new Size(58, 19);
            label1.TabIndex = 52;
            label1.Text = "Class:";
            // 
            // dataGridViewStudentAtt
            // 
            dataGridViewStudentAtt.AllowUserToDeleteRows = false;
            dataGridViewStudentAtt.AllowUserToResizeColumns = false;
            dataGridViewStudentAtt.AllowUserToResizeRows = false;
            dataGridViewStudentAtt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewStudentAtt.BackgroundColor = Color.White;
            dataGridViewStudentAtt.BorderStyle = BorderStyle.None;
            dataGridViewStudentAtt.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewStudentAtt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudentAtt.Columns.AddRange(new DataGridViewColumn[] { Column1, RegNo, Column3, Column4, Status });
            dataGridViewStudentAtt.Location = new Point(31, 131);
            dataGridViewStudentAtt.Name = "dataGridViewStudentAtt";
            dataGridViewStudentAtt.RowHeadersWidth = 51;
            dataGridViewStudentAtt.Size = new Size(872, 318);
            dataGridViewStudentAtt.TabIndex = 31;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "Student_Name";
            Column1.HeaderText = "Student Name";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // RegNo
            // 
            RegNo.DataPropertyName = "Student_Reg No";
            RegNo.HeaderText = "RegNo";
            RegNo.MinimumWidth = 6;
            RegNo.Name = "RegNo";
            // 
            // Column3
            // 
            Column3.DataPropertyName = "Class_Name";
            Column3.HeaderText = "Class";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.DataPropertyName = "Attendance_Date";
            Column4.HeaderText = "Date";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.Items.AddRange(new object[] { "Absent", "Present" });
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            // 
            // panel5
            // 
            panel5.BackColor = Color.LightGray;
            panel5.Location = new Point(95, 99);
            panel5.Name = "panel5";
            panel5.Size = new Size(270, 2);
            panel5.TabIndex = 25;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.None;
            panel3.BackColor = Color.Transparent;
            panel3.Location = new Point(682, 261);
            panel3.Name = "panel3";
            panel3.Size = new Size(10, 23);
            panel3.TabIndex = 24;
            // 
            // panel12
            // 
            panel12.Anchor = AnchorStyles.None;
            panel12.BackColor = Color.Transparent;
            panel12.Location = new Point(459, 252);
            panel12.Name = "panel12";
            panel12.Size = new Size(270, 10);
            panel12.TabIndex = 17;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.None;
            panel4.BackColor = Color.Transparent;
            panel4.Location = new Point(728, 261);
            panel4.Name = "panel4";
            panel4.Size = new Size(10, 23);
            panel4.TabIndex = 23;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.Transparent;
            panel1.Location = new Point(459, 283);
            panel1.Name = "panel1";
            panel1.Size = new Size(270, 10);
            panel1.TabIndex = 22;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = Color.Transparent;
            panel2.Location = new Point(450, 261);
            panel2.Name = "panel2";
            panel2.Size = new Size(10, 23);
            panel2.TabIndex = 19;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold);
            label14.Location = new Point(95, 49);
            label14.Name = "label14";
            label14.Size = new Size(52, 19);
            label14.TabIndex = 16;
            label14.Text = "Date:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            label15.ForeColor = Color.FromArgb(67, 31, 125);
            label15.Location = new Point(9, 6);
            label15.Name = "label15";
            label15.Size = new Size(219, 23);
            label15.TabIndex = 15;
            label15.Text = "Students Attendance:";
            // 
            // dateTimePickerAttendance
            // 
            dateTimePickerAttendance.CustomFormat = "yyyy/MM/dd";
            dateTimePickerAttendance.Format = DateTimePickerFormat.Custom;
            dateTimePickerAttendance.Location = new Point(93, 73);
            dateTimePickerAttendance.Name = "dateTimePickerAttendance";
            dateTimePickerAttendance.Size = new Size(270, 27);
            dateTimePickerAttendance.TabIndex = 27;
            dateTimePickerAttendance.ValueChanged += dateTimePickerAttendance_ValueChanged;
            // 
            // Attendace
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Name = "Attendace";
            Size = new Size(942, 501);
            tabControl1.ResumeLayout(false);
            tabPageMarkAttendance.ResumeLayout(false);
            tabPageMarkAttendance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudentAtt).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageMarkAttendance;
        private Panel panel6;
        private ComboBox comboBoxAttendanceClass;
        private Label label1;
        private DataGridView dataGridViewStudentAtt;
        private Panel panel5;
        private Panel panel3;
        private Panel panel12;
        private Panel panel4;
        private Panel panel1;
        private Panel panel2;
        private Label label14;
        private Label label15;
        private DateTimePicker dateTimePickerAttendance;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn RegNo;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewComboBoxColumn Status;
    }
}
