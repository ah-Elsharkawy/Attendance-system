﻿using attendanceSystem.userControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace attendanceSystem
{
    public partial class mainForm : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        public mainForm()
        {
            InitializeComponent();
            AllocConsole();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            currentUserNameLabel.Text = DataManager.currentUser.Name;
            var role = DataManager.currentUser.Role;
            if (role == "Admin")
            {
                attendanceBtn.Hide();
                adminPanel adminPanel = new adminPanel();
                displayUserControl(adminPanel);
            }
                
            else if (role == "Teacher")
            {
                Attendace attendace = new Attendace();
                displayUserControl(attendace);
                usersBtn.Hide();
                addUserBtn.Hide();
            }
            else
            {
                UserControlReport userControlReport = new UserControlReport();
                displayUserControl(userControlReport);
                usersBtn.Hide();
                addUserBtn.Hide();
                attendanceBtn.Hide();
                // hide get class attendance don't forget 
            }

            DataManager.startBackup();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            // clear current user data before closing
            DataManager.currentUser = null;
            MoveSidePanel(LogoutBtn);
            DialogResult result = MessageBox.Show("Are you sure?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Close();

        }

        private void MoveSidePanel(Control button)
        {
            sidePanel.Location = new Point(0, button.Location.Y - 164);
        }

        private void usersBtn_Click(object sender, EventArgs e)
        {
            adminPanel adminPanel = new adminPanel();
            displayUserControl(adminPanel);
            MoveSidePanel(usersBtn);
        }

        private void attendanceBtn_Click(object sender, EventArgs e)
        {
            Attendace attendance = new Attendace();
            displayUserControl(attendance);
            MoveSidePanel(attendanceBtn);
        }

        private void reportsBtn_Click(object sender, EventArgs e, UserControlReport userControlReport)
        {
            MoveSidePanel(reportsBtn);
            //userControlAddUser1.Visible = false;            
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            UserControlAddUser userControlAddUser = new UserControlAddUser();
            displayUserControl(userControlAddUser);
            MoveSidePanel(addUserBtn);
        }

        private void reportsBtn_Click(object sender, EventArgs e)
        {
            
            UserControlReport userControlReport = new UserControlReport();
            displayUserControl(userControlReport);
            MoveSidePanel(reportsBtn);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void userControlReport2_Load(object sender, EventArgs e)
        {

        }

        private void adminPanel1_Load(object sender, EventArgs e)
        {
            
        }

        public void displayUserControl(UserControl userControl)
        {
            pagesPanel.Controls.Clear();
            pagesPanel.Controls.Add(userControl);
        }

        //private void userControlReport2_Load(object sender, EventArgs e)
        //{

        //}
    }
}
