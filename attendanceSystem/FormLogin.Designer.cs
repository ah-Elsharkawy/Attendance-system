namespace attendanceSystem
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            panel2 = new Panel();
            label1 = new Label();
            textBoxEmail = new TextBox();
            label2 = new Label();
            textBoxPassword = new TextBox();
            labelError = new Label();
            labelFP = new Label();
            groupBox1 = new GroupBox();
            pictureBoxShow = new PictureBox();
            pictureBoxHide = new PictureBox();
            buttonLogin = new Button();
            pictureBoxError = new PictureBox();
            toolTip = new ToolTip(components);
            pictureBoxMinimize = new PictureBox();
            pictureBoxClose = new PictureBox();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxShow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHide).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxError).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMinimize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxClose).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(67, 3, 125);
            label3.Location = new Point(906, 377);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(362, 32);
            label3.TabIndex = 0;
            label3.Text = "Attendance Management ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(67, 3, 125);
            label4.Location = new Point(1031, 415);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(106, 32);
            label4.TabIndex = 0;
            label4.Text = "System";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 15.75F);
            label5.ForeColor = Color.FromArgb(17, 123, 201);
            label5.Location = new Point(944, 461);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(282, 33);
            label5.TabIndex = 0;
            label5.Text = "By C# Model Design";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 9F);
            label6.ForeColor = SystemColors.WindowText;
            label6.Location = new Point(11, 591);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(275, 20);
            label6.TabIndex = 6;
            label6.Text = "copyright © 2024.All Rights Reserved.";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Location = new Point(732, 149);
            panel2.Margin = new Padding(2, 3, 2, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(4, 373);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(77, 54);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(58, 19);
            label1.TabIndex = 0;
            label1.Text = "Email:";

            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(79, 84);
            textBoxEmail.Margin = new Padding(2, 3, 2, 3);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(222, 28);
            textBoxEmail.TabIndex = 1;
            textBoxEmail.Leave += textBoxEmail_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(77, 121);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(92, 19);
            label2.TabIndex = 0;
            label2.Text = "Password:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPassword.Location = new Point(79, 153);
            textBoxPassword.Margin = new Padding(2, 3, 2, 3);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(222, 28);
            textBoxPassword.TabIndex = 2;
            textBoxPassword.TextChanged += textBoxPassword_TextChanged;
            textBoxPassword.Leave += textBoxPassword_Leave;
            // 
            // labelError
            // 
            labelError.AutoSize = true;
            labelError.Font = new Font("Century Gothic", 9F);
            labelError.ForeColor = Color.FromArgb(234, 73, 73);
            labelError.Location = new Point(103, 189);
            labelError.Margin = new Padding(2, 0, 2, 0);
            labelError.Name = "labelError";
            labelError.Size = new Size(230, 20);
            labelError.TabIndex = 0;
            labelError.Text = "Invalid Username or Password";
            // 
            // labelFP
            // 
            labelFP.AutoSize = true;
            labelFP.Cursor = Cursors.Hand;
            labelFP.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFP.ForeColor = Color.FromArgb(67, 3, 125);
            labelFP.Location = new Point(138, 218);
            labelFP.Margin = new Padding(2, 0, 2, 0);
            labelFP.Name = "labelFP";
            labelFP.Size = new Size(152, 19);
            labelFP.TabIndex = 0;
            labelFP.Text = "Forget Password?";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBoxShow);
            groupBox1.Controls.Add(pictureBoxHide);
            groupBox1.Controls.Add(buttonLogin);
            groupBox1.Controls.Add(labelFP);
            groupBox1.Controls.Add(labelError);
            groupBox1.Controls.Add(pictureBoxError);
            groupBox1.Controls.Add(textBoxPassword);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBoxEmail);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(154, 160);
            groupBox1.Margin = new Padding(2, 3, 2, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 3, 2, 3);
            groupBox1.Size = new Size(440, 344);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Please Login First";
            // 
            // pictureBoxShow
            // 
            pictureBoxShow.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxShow.Cursor = Cursors.Hand;
            pictureBoxShow.Image = (Image)resources.GetObject("pictureBoxShow.Image");
            pictureBoxShow.Location = new Point(266, 153);
            pictureBoxShow.Margin = new Padding(2, 3, 2, 3);
            pictureBoxShow.Name = "pictureBoxShow";
            pictureBoxShow.Size = new Size(35, 28);
            pictureBoxShow.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxShow.TabIndex = 7;
            pictureBoxShow.TabStop = false;
            pictureBoxShow.Click += pictureBoxShow_Click;
            pictureBoxShow.MouseHover += pictureBoxShow_MouseHover;
            // 
            // pictureBoxHide
            // 
            pictureBoxHide.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxHide.Cursor = Cursors.Hand;
            pictureBoxHide.Image = Properties.Resources.icons8_hide_96;
            pictureBoxHide.Location = new Point(266, 153);
            pictureBoxHide.Margin = new Padding(2, 3, 2, 3);
            pictureBoxHide.Name = "pictureBoxHide";
            pictureBoxHide.Size = new Size(35, 28);
            pictureBoxHide.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxHide.TabIndex = 8;
            pictureBoxHide.TabStop = false;
            pictureBoxHide.Click += pictureBoxHide_Click;
            pictureBoxHide.MouseHover += pictureBoxHide_MouseHover;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.FromArgb(67, 3, 125);
            buttonLogin.Cursor = Cursors.Hand;
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Image = Properties.Resources.icons8_login_50__1_1;
            buttonLogin.Location = new Point(78, 255);
            buttonLogin.Margin = new Padding(2, 3, 2, 3);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(222, 53);
            buttonLogin.TabIndex = 3;
            buttonLogin.Text = "Log In";
            buttonLogin.TextAlign = ContentAlignment.MiddleRight;
            buttonLogin.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // pictureBoxError
            // 
            pictureBoxError.Cursor = Cursors.Hand;
            pictureBoxError.Image = Properties.Resources.icons8_exclamation_mark_96__1_;
            pictureBoxError.Location = new Point(78, 187);
            pictureBoxError.Margin = new Padding(2, 3, 2, 3);
            pictureBoxError.Name = "pictureBoxError";
            pictureBoxError.Size = new Size(21, 23);
            pictureBoxError.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxError.TabIndex = 5;
            pictureBoxError.TabStop = false;
            // 
            // pictureBoxMinimize
            // 
            pictureBoxMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBoxMinimize.Cursor = Cursors.Hand;
            pictureBoxMinimize.Image = Properties.Resources.icons8_minimize_100;
            pictureBoxMinimize.Location = new Point(1263, 8);
            pictureBoxMinimize.Margin = new Padding(2, 3, 2, 3);
            pictureBoxMinimize.Name = "pictureBoxMinimize";
            pictureBoxMinimize.Size = new Size(26, 28);
            pictureBoxMinimize.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxMinimize.TabIndex = 1;
            pictureBoxMinimize.TabStop = false;
            pictureBoxMinimize.Click += pictureBoxMinimize_Click;
            pictureBoxMinimize.MouseHover += pictureBoxMinimize_MouseHover;
            // 
            // pictureBoxClose
            // 
            pictureBoxClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBoxClose.Cursor = Cursors.Hand;
            pictureBoxClose.Image = Properties.Resources.icons8_x_96__4_;
            pictureBoxClose.Location = new Point(1294, 8);
            pictureBoxClose.Margin = new Padding(2, 3, 2, 3);
            pictureBoxClose.Name = "pictureBoxClose";
            pictureBoxClose.Size = new Size(26, 28);
            pictureBoxClose.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxClose.TabIndex = 0;
            pictureBoxClose.TabStop = false;
            pictureBoxClose.Click += pictureBoxClose_Click;
            pictureBoxClose.MouseHover += pictureBoxClose_MouseHover;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_graduate_64;
            pictureBox1.Location = new Point(990, 160);
            pictureBox1.Margin = new Padding(2, 3, 2, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(168, 199);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1402, 634);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(panel2);
            Controls.Add(groupBox1);
            Controls.Add(pictureBoxMinimize);
            Controls.Add(pictureBoxClose);
            Cursor = Cursors.Hand;
            Font = new Font("Century Gothic", 10F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            WindowState = FormWindowState.Maximized;
            Load += FormLogin_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxShow).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHide).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxError).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMinimize).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxClose).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.PictureBox pictureBoxMinimize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.PictureBox pictureBoxError;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelFP;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip;
        private PictureBox pictureBox1;
        private PictureBox pictureBoxShow;
        private PictureBox pictureBoxHide;
    }
}