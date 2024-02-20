namespace attendanceSystem
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            loginBtn = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(29, 25);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(744, 322);
            textBox1.TabIndex = 0;
            textBox1.Text = "Name";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(253, 353);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(286, 27);
            textBox2.TabIndex = 1;
            textBox2.Text = "password";
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(334, 386);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(94, 29);
            loginBtn.TabIndex = 2;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(loginBtn);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Button loginBtn;
    }
}
