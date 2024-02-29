namespace attendanceSystem.userControls
{
    partial class UserControlReport
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
            components = new System.ComponentModel.Container();
            tabControl1 = new TabControl();
            tabPageClassAttendance = new TabPage();
            panel6 = new Panel();
            comboBox3 = new ComboBox();
            pictureBoxPrinter = new PictureBox();
            label1 = new Label();
            dataGridViewClassReport = new DataGridView();
            label15 = new Label();
            tabPageIdAttendance = new TabPage();
            resultStudentName = new Label();
            button1 = new Button();
            label2 = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            dataGridViewStudentReport = new DataGridView();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            comboBoxRegNo = new Label();
            tabPageStudentReport = new Label();
            toolTip1 = new ToolTip(components);
            tabControl1.SuspendLayout();
            tabPageClassAttendance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPrinter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClassReport).BeginInit();
            tabPageIdAttendance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudentReport).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Alignment = TabAlignment.Bottom;
            tabControl1.Anchor = AnchorStyles.None;
            tabControl1.Controls.Add(tabPageClassAttendance);
            tabControl1.Controls.Add(tabPageIdAttendance);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(942, 501);
            tabControl1.TabIndex = 2;
            tabControl1.Enter += tabControl1_Enter;
            // 
            // tabPageClassAttendance
            // 
            tabPageClassAttendance.Controls.Add(panel6);
            tabPageClassAttendance.Controls.Add(comboBox3);
            tabPageClassAttendance.Controls.Add(pictureBoxPrinter);
            tabPageClassAttendance.Controls.Add(label1);
            tabPageClassAttendance.Controls.Add(dataGridViewClassReport);
            tabPageClassAttendance.Controls.Add(label15);
            tabPageClassAttendance.Location = new Point(4, 4);
            tabPageClassAttendance.Name = "tabPageClassAttendance";
            tabPageClassAttendance.Padding = new Padding(3);
            tabPageClassAttendance.Size = new Size(934, 467);
            tabPageClassAttendance.TabIndex = 0;
            tabPageClassAttendance.Text = "Class Report";
            tabPageClassAttendance.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            panel6.BackColor = Color.LightGray;
            panel6.Location = new Point(306, 104);
            panel6.Name = "panel6";
            panel6.Size = new Size(270, 2);
            panel6.TabIndex = 53;
            // 
            // comboBox3
            // 
            comboBox3.FlatStyle = FlatStyle.Flat;
            comboBox3.ForeColor = SystemColors.InfoText;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "PD", "OS", "AI" });
            comboBox3.Location = new Point(307, 76);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(270, 29);
            comboBox3.TabIndex = 54;
            // 
            // pictureBoxPrinter
            // 
            pictureBoxPrinter.Cursor = Cursors.Hand;
            pictureBoxPrinter.Image = Properties.Resources.icons8_printer_100;
            pictureBoxPrinter.Location = new Point(789, 2);
            pictureBoxPrinter.Name = "pictureBoxPrinter";
            pictureBoxPrinter.Size = new Size(30, 30);
            pictureBoxPrinter.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPrinter.TabIndex = 32;
            pictureBoxPrinter.TabStop = false;
            pictureBoxPrinter.Click += pictureBoxPrinter_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold);
            label1.Location = new Point(303, 51);
            label1.Name = "label1";
            label1.Size = new Size(58, 19);
            label1.TabIndex = 52;
            label1.Text = "Class:";
            // 
            // dataGridViewClassReport
            // 
            dataGridViewClassReport.AllowUserToAddRows = false;
            dataGridViewClassReport.AllowUserToDeleteRows = false;
            dataGridViewClassReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewClassReport.BackgroundColor = Color.White;
            dataGridViewClassReport.BorderStyle = BorderStyle.None;
            dataGridViewClassReport.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewClassReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClassReport.Location = new Point(31, 171);
            dataGridViewClassReport.Name = "dataGridViewClassReport";
            dataGridViewClassReport.ReadOnly = true;
            dataGridViewClassReport.RowHeadersWidth = 51;
            dataGridViewClassReport.Size = new Size(872, 278);
            dataGridViewClassReport.TabIndex = 31;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            label15.ForeColor = Color.FromArgb(67, 31, 125);
            label15.Location = new Point(17, 9);
            label15.Name = "label15";
            label15.Size = new Size(137, 23);
            label15.TabIndex = 15;
            label15.Text = "Class Report:";
            // 
            // tabPageIdAttendance
            // 
            tabPageIdAttendance.Controls.Add(resultStudentName);
            tabPageIdAttendance.Controls.Add(button1);
            tabPageIdAttendance.Controls.Add(label2);
            tabPageIdAttendance.Controls.Add(dateTimePicker2);
            tabPageIdAttendance.Controls.Add(dateTimePicker1);
            tabPageIdAttendance.Controls.Add(textBox1);
            tabPageIdAttendance.Controls.Add(pictureBox1);
            tabPageIdAttendance.Controls.Add(dataGridViewStudentReport);
            tabPageIdAttendance.Controls.Add(comboBoxRegNo);
            tabPageIdAttendance.Controls.Add(tabPageStudentReport);
            tabPageIdAttendance.Location = new Point(4, 4);
            tabPageIdAttendance.Name = "tabPageIdAttendance";
            tabPageIdAttendance.Padding = new Padding(3);
            tabPageIdAttendance.Size = new Size(934, 467);
            tabPageIdAttendance.TabIndex = 1;
            tabPageIdAttendance.Text = "Student Report";
            tabPageIdAttendance.UseVisualStyleBackColor = true;
            tabPageIdAttendance.Click += tabPageIdAttendance_Click;
            tabPageIdAttendance.Enter += tabPageIdAttendance_Enter;
            // 
            // resultStudentName
            // 
            resultStudentName.AutoSize = true;
            resultStudentName.Location = new Point(158, 57);
            resultStudentName.Name = "resultStudentName";
            resultStudentName.Size = new Size(0, 21);
            resultStudentName.TabIndex = 59;
            // 
            // button1
            // 
            button1.Location = new Point(813, 159);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 58;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold);
            label2.Location = new Point(18, 57);
            label2.Name = "label2";
            label2.Size = new Size(134, 19);
            label2.TabIndex = 56;
            label2.Text = "Student Name :";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(527, 127);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 55;
            dateTimePicker2.Value = new DateTime(2024, 2, 29, 0, 0, 0, 0);
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(208, 127);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 54;
            dateTimePicker1.Value = new DateTime(2024, 2, 29, 0, 0, 0, 0);
            // 
            // textBox1
            // 
            textBox1.Location = new Point(491, 51);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(86, 27);
            textBox1.TabIndex = 53;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = Properties.Resources.icons8_printer_100;
            pictureBox1.Location = new Point(886, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 52;
            pictureBox1.TabStop = false;
            // 
            // dataGridViewStudentReport
            // 
            dataGridViewStudentReport.AllowUserToAddRows = false;
            dataGridViewStudentReport.AllowUserToDeleteRows = false;
            dataGridViewStudentReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewStudentReport.BackgroundColor = Color.White;
            dataGridViewStudentReport.BorderStyle = BorderStyle.None;
            dataGridViewStudentReport.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewStudentReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudentReport.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dataGridViewStudentReport.Location = new Point(208, 187);
            dataGridViewStudentReport.Name = "dataGridViewStudentReport";
            dataGridViewStudentReport.ReadOnly = true;
            dataGridViewStudentReport.RowHeadersWidth = 51;
            dataGridViewStudentReport.Size = new Size(569, 274);
            dataGridViewStudentReport.TabIndex = 44;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "Attendance_Date";
            dataGridViewTextBoxColumn4.HeaderText = "Date";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "Attendance_Status";
            dataGridViewTextBoxColumn5.HeaderText = "Status";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // comboBoxRegNo
            // 
            comboBoxRegNo.AutoSize = true;
            comboBoxRegNo.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold);
            comboBoxRegNo.Location = new Point(409, 55);
            comboBoxRegNo.Name = "comboBoxRegNo";
            comboBoxRegNo.Size = new Size(65, 19);
            comboBoxRegNo.TabIndex = 41;
            comboBoxRegNo.Text = "ID No.:";
            // 
            // tabPageStudentReport
            // 
            tabPageStudentReport.AutoSize = true;
            tabPageStudentReport.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            tabPageStudentReport.ForeColor = Color.FromArgb(67, 31, 125);
            tabPageStudentReport.Location = new Point(19, 10);
            tabPageStudentReport.Name = "tabPageStudentReport";
            tabPageStudentReport.Size = new Size(157, 23);
            tabPageStudentReport.TabIndex = 32;
            tabPageStudentReport.Text = "Student Report:";
            // 
            // UserControlReport
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(tabControl1);
            Font = new Font("Century Gothic", 9.75F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UserControlReport";
            Size = new Size(942, 501);
            tabControl1.ResumeLayout(false);
            tabPageClassAttendance.ResumeLayout(false);
            tabPageClassAttendance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPrinter).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClassReport).EndInit();
            tabPageIdAttendance.ResumeLayout(false);
            tabPageIdAttendance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudentReport).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageClassAttendance;
        private Label label15;
        private TabPage tabPageIdAttendance;
        private DataGridView dataGridViewStudentReport;
        private Label comboBoxRegNo;
        private Label tabPageStudentReport;
        private PictureBox pictureBoxPrinter;
        private ToolTip toolTip1;
        private Panel panel6;
        private ComboBox comboBox3;
        private Label label1;
        private PictureBox pictureBox1;
        private DataGridView dataGridViewClassReport;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private Label label2;
        private Button button1;
        private Label resultStudentName;
        //private ComboBox comboBox1;
    }
}