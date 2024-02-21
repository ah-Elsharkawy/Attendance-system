using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace attendanceSystem
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            currentUserName.Text = DataManager.currentUser.Name;
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
            MoveSidePanel(LogoutBtn);
            DialogResult result = MessageBox.Show("Are you sure?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Close();

        }

        private void MoveSidePanel(Control button)
        {
            sidePanel.Location = new Point(0, button.Location.Y - 164);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MoveSidePanel(button2);
        }

        private void usersBtn_Click(object sender, EventArgs e)
        {
            MoveSidePanel(usersBtn);
        }

        private void attendanceBtn_Click(object sender, EventArgs e)
        {
            MoveSidePanel(attendanceBtn);
        }

        private void reportsBtn_Click(object sender, EventArgs e)
        {
            MoveSidePanel(reportsBtn);
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            MoveSidePanel(addUserBtn);
        }


    }
}
