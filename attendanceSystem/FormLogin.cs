using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace attendanceSystem
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }



        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxShow_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(pictureBoxShow, "show Password");
        }

        private void pictureBoxHide_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(pictureBoxHide, "Hide Password");
        }

        private void pictureBoxShow_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = false;
            pictureBoxShow.Hide();
            pictureBoxHide.Show();
        }

        private void pictureBoxHide_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true;
            pictureBoxShow.Show();
            pictureBoxHide.Hide();
        }

        private void pictureBoxError_Click(object sender, EventArgs e)
        {

        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            pictureBoxHide.Hide();
            pictureBoxError.Hide();
            labelError.Hide();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBoxClose_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(pictureBoxClose, "Close");

        }

        private void pictureBoxMinimize_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(pictureBoxMinimize, "Minimize");

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim(); //trim to remove spaces before or after their email address
            string password = textBoxPassword.Text;
            if (IsValidPassword(email) && IsValidPassword(password))
            {
                // Valid email and password, perform login logic here
                MessageBox.Show("Login successful!");
            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.");
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim(); //trim to remove spaces before or after their email address
            string password = textBoxPassword.Text;
        }
        private bool IsValidPassword(string password)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
