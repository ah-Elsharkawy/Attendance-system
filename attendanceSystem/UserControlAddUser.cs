using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace attendanceSystem
{
    public partial class UserControlAddUser : UserControl
    {
        public UserControlAddUser()
        {
            InitializeComponent();
        }
        public string UID;
        private string ID = "";
        public void ClearTextStudentBox()
        {
            textBoxName.Clear();
            textBoxPassword.Clear();
            textBoxEmail.Text = "abdullah@gmail.com";
            textBoxEmail.ForeColor = Color.DarkGray;
            comboBoxClass.SelectedIndex = -1;
            tabControlAddUser.SelectedTab = tabPageAddStudent;
        }
        private void ClearTextStudentBoxUpdate()
        {
            textBoxNameU.Clear();
            textBoxPasswordU.Clear();
            textBoxEmailU.Text = "abdullah@gmail.com";
            textBoxEmailU.ForeColor = Color.DarkGray;
            comboBoxClassU.SelectedIndex = -1;
        }
        public void ClearTextTeacherBox()
        {
            textBoxTeacherName.Clear();
            textBoxTeacherPassword.Clear();
            textBoxTeacherEmail.Text = "abdullah@gmail.com";
            textBoxTeacherEmail.ForeColor = Color.DarkGray;
            checkBoxPD.Checked = false;
            checkBoxAI.Checked = false;
            checkBoxOS.Checked = false;
            tabControlAddUser.SelectedTab = tabPageAddTeacher;
        }
        private void ClearTextTeacherBoxUpdate()
        {
            textBoxTeacherNameU.Clear();
            textBoxTeacherPasswordU.Clear();
            textBoxTeacherEmailU.Text = "abdullah@gmail.com";
            textBoxTeacherEmailU.ForeColor = Color.DarkGray;
            checkBoxPDU.Checked = false;
            checkBoxAIU.Checked = false;
            checkBoxOSU.Checked = false;
            ID = "";
        }
        public void HideErrorPic()
        {
            pictureBoxStudentEmailU.Visible = false;
            pictureBoxTeacherEmailU.Visible = false;
        }

        private void mask(MaskedTextBox txtBox)
        {
            BeginInvoke((MethodInvoker)delegate ()
            {
                txtBox.Select(0, 0);
            });
        }
        private bool IsVaildEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void tabPageAddTeacher_Enter(object sender, EventArgs e)
        {
            ClearTextTeacherBoxUpdate();
            pictureBoxTeacherEmail.Visible = false;
        }

        private void tabPageAddTeacher_Leave(object sender, EventArgs e)
        {
            ClearTextTeacherBox();
        }

        private void tabPageUpdate_Leave(object sender, EventArgs e)
        {
            ClearTextStudentBoxUpdate();
            pictureBoxStudentEmailU.Visible = false;
        }

        private void tabPageAddStudent_Enter(object sender, EventArgs e)
        {
            ClearTextStudentBoxUpdate();
            pictureBoxStudentEmail.Visible = false;
        }

        private void tabPageAddStudent_Leave(object sender, EventArgs e)
        {
            ClearTextStudentBox();

        }

        private void comboBoxClass_Click(object sender, EventArgs e)
        {
            comboBoxClass.Items.Clear();
            //write code here
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            if (textBoxName.Text.Trim() == string.Empty
                               || textBoxEmail.Text.Trim() == string.Empty
                                              || !IsVaildEmail(textBoxEmail.Text)
                                                             || textBoxPassword.Text.Trim() == string.Empty
                                                                            || comboBoxClass.SelectedIndex == -1)
            {
                MessageBox.Show("First fill out all fields", "Required all fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ClearTextStudentBox();
            //compelete add code here 
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxNameU.Text.Trim() == string.Empty
                || textBoxEmailU.Text.Trim() == string.Empty
                || !IsVaildEmail(textBoxEmailU.Text)
                || textBoxPasswordU.Text.Trim() == string.Empty
                || comboBoxClassU.SelectedIndex == -1)
            {
                MessageBox.Show("First fill out all fields", "Required all fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //compelete add code here 
            ClearTextStudentBoxUpdate();
        }

        private void textBoxTeacherEmail_Enter(object sender, EventArgs e)
        {
            if (textBoxTeacherEmail.Text == "abdullah@gmail.com")
            {
                textBoxTeacherEmail.Text = "";
                textBoxTeacherEmail.ForeColor = Color.Black;
            }

        }

        private void textBoxTeacherEmail_Leave(object sender, EventArgs e)
        {
            if (textBoxTeacherEmail.Text == "")
            {
                textBoxTeacherEmail.Text = "abdullah@gmail.com";
                textBoxTeacherEmail.ForeColor = Color.DarkGray;
            }
            else if (!IsVaildEmail(textBoxTeacherEmail.Text) || textBoxTeacherEmail.Text == "abdullah@gmail.com")
            {
                pictureBoxTeacherEmail.Visible = true;
            }
            else
            {
                pictureBoxTeacherEmail.Visible = false;
            }
        }

        private void pictureBoxTeacherEmail_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Invalid Email", pictureBoxTeacherEmail);
        }

        private void tabPageAddTeacher_Leave_1(object sender, EventArgs e)
        {
            ClearTextTeacherBox();
            pictureBoxTeacherEmail.Visible = false;
        }
        private void tabPageAddTeacher_Enter_1(object sender, EventArgs e)
        {
            ClearTextTeacherBox();
            pictureBoxTeacherEmail.Visible = false;
        }

        private void buttonAddTeacher_Click(object sender, EventArgs e)
        {

            if (textBoxTeacherName.Text.Trim() == string.Empty
                || !IsVaildEmail(textBoxTeacherEmail.Text)
                || textBoxTeacherEmail.Text == "abdullah@gmail.com"
                || textBoxTeacherPassword.Text.Trim() == string.Empty
                || (!checkBoxAI.Checked && !checkBoxOS.Checked && !checkBoxPD.Checked))
            {
                MessageBox.Show("First fill out all fields", "Required all fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ClearTextTeacherBox();
            //compelete add code here 
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {

            if (textBoxEmail.Text == "abdullah@gmail.com")
            {
                textBoxEmail.Text = "";
                textBoxEmail.ForeColor = Color.Black;
            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "")
            {
                textBoxEmail.Text = "abdullah@gmail.com";
                textBoxEmail.ForeColor = Color.DarkGray;
            }
            else if (!IsVaildEmail(textBoxEmail.Text) || textBoxEmail.Text == "abdullah@gmail.com")
            {
                pictureBoxStudentEmail.Visible = true;
            }
            else
            {
                pictureBoxStudentEmail.Visible = false;
            }
        }
        private void pictureBoxStudentEmail_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Invalid Email", pictureBoxStudentEmail);
        }

        private void pictureBoxStudentEmailU_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Invalid Email", pictureBoxStudentEmailU);
        }

        private void pictureBoxTeacherEmailU_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Invalid Email", pictureBoxTeacherEmailU);
        }

        private void textBoxEmailU_Enter(object sender, EventArgs e)
        {

            if (textBoxEmailU.Text == "abdullah@gmail.com")
            {
                textBoxEmailU.Text = "";
                textBoxEmailU.ForeColor = Color.Black;
            }
        }

        private void textBoxEmailU_Leave(object sender, EventArgs e)
        {

            if (textBoxEmailU.Text == "")
            {
                textBoxEmailU.Text = "abdullah@gmail.com";
                textBoxEmailU.ForeColor = Color.DarkGray;
            }
            else if (!IsVaildEmail(textBoxEmailU.Text) || textBoxEmailU.Text == "abdullah@gmail.com")
            {
                pictureBoxStudentEmailU.Visible = true;
            }
            else
            {
                pictureBoxStudentEmailU.Visible = false;
            }
        }
        private void textBoxTeacherEmailU_Enter(object sender, EventArgs e)
        {

            if (textBoxTeacherEmailU.Text == "abdullah@gmail.com")
            {
                textBoxTeacherEmailU.Text = "";
                textBoxTeacherEmailU.ForeColor = Color.Black;
            }
        }
        private void textBoxTeacherEmailU_Leave(object sender, EventArgs e)
        {

            if (textBoxTeacherEmailU.Text == "")
            {
                textBoxTeacherEmailU.Text = "abdullah@gmail.com";
                textBoxTeacherEmailU.ForeColor = Color.DarkGray;
            }
            else if (!IsVaildEmail(textBoxTeacherEmailU.Text) || textBoxTeacherEmailU.Text == "abdullah@gmail.com")
            {
                pictureBoxTeacherEmailU.Visible = true;
            }
            else
            {
                pictureBoxTeacherEmailU.Visible = false;
            }
        }

        private void tabPageUpdateTeacher_Leave(object sender, EventArgs e)
        {

            ClearTextTeacherBoxUpdate();
            pictureBoxTeacherEmailU.Visible = false;
        }

        private void tabPageUpdate_Enter(object sender, EventArgs e)
        {

            ClearTextStudentBoxUpdate();
            pictureBoxStudentEmailU.Visible = false;
        }

        private void tabPageUpdateTeacher_Enter(object sender, EventArgs e)
        {

            ClearTextTeacherBoxUpdate();
            pictureBoxTeacherEmailU.Visible = false;
        }

        private void buttonTeacherUpdate_Click(object sender, EventArgs e)
        {

            if (textBoxTeacherNameU.Text.Trim() == string.Empty
                               || !IsVaildEmail(textBoxTeacherEmailU.Text)
                                              || textBoxTeacherEmailU.Text == "abdullah@gmail.com"
                                              || textBoxTeacherPasswordU.Text.Trim() == string.Empty
                                                                                || (!checkBoxAIU.Checked && !checkBoxOSU.Checked && !checkBoxPDU.Checked)
                )
            {

                MessageBox.Show("First fill out all fields", "Required all fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ClearTextTeacherBoxUpdate();
            //compelete add code here
        }
    }
}
