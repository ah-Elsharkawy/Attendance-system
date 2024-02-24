﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace attendanceSystem
{
    public partial class FormLogin : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public FormLogin()
        {
            InitializeComponent();
            AllocConsole(); 

        }

        /// fatma/
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
            var inputEmail = textBoxEmail.Text.Trim();
            //Console.WriteLine(inputEmail);
            var inputPassword = textBoxPassword.Text;

            // Retrieve user XML data by email
            XmlDocument loggedUser = DataManager.getUserXmlByEmail(inputEmail);
            Console.WriteLine(loggedUser.OuterXml);
/*
            XmlNode emailNode = loggedUser.SelectSingleNode("/user/Email");
            if (emailNode != null)
            {
                // Get the inner text of the Email element
                string email = emailNode.InnerText;
                Console.WriteLine("Email: " + email);
            }
            else
            {
                Console.WriteLine("Email element not found.");
            }
            Console.WriteLine(loggedUser.SelectSingleNode("/user/Email").InnerText);
*/


            /*if (loggedUser != null)
            {
                // Get the email node
                var emailNode = loggedUser.SelectSingleNode("//Email");
                Console.WriteLine(emailNode);

                if (emailNode != null)
                {
                    // Get the email value from the XML
                    var rightEmail = emailNode.InnerText;

                    if (rightEmail == inputEmail)
                    {
                        // Email matches, proceed to check password
                        var passwordNode = loggedUser.SelectSingleNode("Password");

                        if (passwordNode != null)
                        {
                            // Get the password value from the XML
                            var rightPassword = passwordNode.InnerText;

                            if (rightPassword == inputPassword)
                            {
                                // Password matches, login successful
                                MessageBox.Show("Successful Login.");
                            }
                            else
                            {
                                // Incorrect password
                                MessageBox.Show("Incorrect Password.");
                            }
                        }
                        else
                        {
                            // Password node not found, handle accordingly
                            MessageBox.Show("Incorrect Password.");
                        }
                    }
                    else
                    {
                        // Email does not match
                        MessageBox.Show("Incorrect Email.");
                    }
                }
                else
                {
                    // Email node not found, handle accordingly
                    MessageBox.Show("This Email doesn't exist.");
                }
            }
            else
            {
                // User data not found for the given email, handle accordingly
                MessageBox.Show("User not found.");
            }*/
        }




        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            /*string password = textBoxPassword.Text;
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a password.");
            }
            else if (!IsValidPassword(password))
            {
                MessageBox.Show("Password must be at least 6 characters long.");
            }*/
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            /*if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                MessageBox.Show("Please enter an email address.");
            }
            else if (!IsValidEmail(textBoxEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.");
            }*/

        }

        private bool IsValidEmail(string email)
        {
            // Basic email validation logic
            // You can use more sophisticated methods or regex for validation
            return !string.IsNullOrEmpty(email) && email.Contains("@") && email.Contains(".");
        }

        private bool IsValidPassword(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Length >= 6;
        }


        private void textBoxEmail_Leave(object sender, CancelEventArgs e)
        {

        }

    }
}
