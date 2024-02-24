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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace attendanceSystem
{
    public partial class UserControlAddUser : UserControl
    {
        public string UID;
        private string ID = "";
        private const string XmlFilePath = "../../../Data/data.xml";

        public UserControlAddUser()
        {
            InitializeComponent();
            InitializeDefaultValues();
        }
        private void InitializeDefaultValues()
        {
            textBoxEmail.Text = "abdullah@gmail.com";
            textBoxEmail.ForeColor = Color.DarkGray;
            textBoxTeacherEmail.Text = "abdullah@gmail.com";
            textBoxTeacherEmail.ForeColor = Color.DarkGray;
            textBoxEmailU.Text = "abdullah@gmail.com";
            textBoxEmailU.ForeColor = Color.DarkGray;
            textBoxTeacherEmailU.Text = "abdullah@gmail.com";
            textBoxTeacherEmailU.ForeColor = Color.DarkGray;
        }

        private void ClearTextStudentBox()
        {
            textBoxName.Clear();
            textBoxPassword.Clear();
            textBoxEmail.Text = "abdullah@gmail.com";
            textBoxEmail.ForeColor = Color.DarkGray;
            comboBoxClass.SelectedIndex = -1;
            tabControlAddUser.SelectedTab = tabPageAddStudent;
        }

        private void ClearTextTeacherBox()
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
        private void ClearTextStudentBoxUpdate()
        {
            textBoxNameU.Clear();
            textBoxPasswordU.Clear();
            textBoxEmailU.Text = "abdullah@gmail.com";
            textBoxEmailU.ForeColor = Color.DarkGray;
            comboBoxClassU.SelectedIndex = -1;
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
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch (FormatException)
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
        /*
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxEmail.Text)
                || !IsValidEmail(textBoxEmail.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text)
                || comboBoxClass.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill out all fields correctly.", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClearTextStudentBox();
            // Complete add code here 
        }
        */
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text) 
                || string.IsNullOrWhiteSpace(textBoxEmail.Text)
                || !IsValidEmail(textBoxEmail.Text) 
                || string.IsNullOrWhiteSpace(textBoxPassword.Text)
                || comboBoxClass.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill out all fields correctly.", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Generate a unique ID for the new student
            //string newUserId = GenerateUniqueId();

            // Create a new XmlDocument instance
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                // Load the XML file
                xmlDoc.Load(XmlFilePath);

                Student newUser = new (textBoxName.Text, textBoxEmail.Text, textBoxPassword.Text, "Student", comboBoxClass.SelectedItem.ToString());
               // FormatsConverter.Serialize<Student>(newUser);
                textBox1.Text = FormatsConverter.Serialize(newUser);

                // Create a new "user" element
                XmlElement newUserElement = xmlDoc.CreateElement("user");

                // Create and append child elements for the new student
                //AddXmlElement(xmlDoc, newUserElement, "Id", newUserId);
                AddXmlElement(xmlDoc, newUserElement, "Name", textBoxName.Text.Trim());
                AddXmlElement(xmlDoc, newUserElement, "Email", textBoxEmail.Text.Trim());
                AddXmlElement(xmlDoc, newUserElement, "Password", textBoxPassword.Text.Trim());
                AddXmlElement(xmlDoc, newUserElement, "Role", "Student");

                // If a class is selected, add it as a child element
                if (comboBoxClass.SelectedIndex != -1)
                {
                    string selectedClass = comboBoxClass.SelectedItem.ToString();
                    AddXmlElement(xmlDoc, newUserElement, "SClass", selectedClass);
                }

                // Append the new user element to the root "users" element
                xmlDoc.DocumentElement.AppendChild(newUserElement);

                // Save the changes back to the XML file
                xmlDoc.Save(XmlFilePath);

                // Clear text boxes after successful addition
                ClearTextStudentBox();

                // Show success message
                MessageBox.Show("Student added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNameU.Text) || string.IsNullOrWhiteSpace(textBoxEmailU.Text)
                || !IsValidEmail(textBoxEmailU.Text) || string.IsNullOrWhiteSpace(textBoxPasswordU.Text)
                || comboBoxClassU.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill out all fields correctly.", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Complete update code here
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
            else if (!IsValidEmail(textBoxTeacherEmail.Text) || textBoxTeacherEmail.Text == "abdullah@gmail.com")
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
        /*
        private void buttonAddTeacher_Click(object sender, EventArgs e)
        {

            if (textBoxTeacherName.Text.Trim() == string.Empty
                || !IsValidEmail(textBoxTeacherEmail.Text)
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

        */
        private void buttonAddTeacher_Click(object sender, EventArgs e)
        {
            if (textBoxTeacherName.Text.Trim() == string.Empty
                || !IsValidEmail(textBoxTeacherEmail.Text)
                || textBoxTeacherEmail.Text == "abdullah@gmail.com"
                || textBoxTeacherPassword.Text.Trim() == string.Empty
                || (!checkBoxAI.Checked && !checkBoxOS.Checked && !checkBoxPD.Checked))
            {
                MessageBox.Show("Please fill out all fields correctly.", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Generate a unique ID for the new user
            //string newUserId = GenerateUniqueId();

            // Create a new XmlDocument instance
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                // Load the XML file
                xmlDoc.Load(XmlFilePath);

                // Create a new "user" element
                XmlElement newUserElement = xmlDoc.CreateElement("user");

                // Create and append child elements for the new user
                //AddXmlElement(xmlDoc, newUserElement, "Id", newUserId);
                AddXmlElement(xmlDoc, newUserElement, "Name", textBoxTeacherName.Text.Trim());
                AddXmlElement(xmlDoc, newUserElement, "Email", textBoxTeacherEmail.Text.Trim());
                AddXmlElement(xmlDoc, newUserElement, "Password", textBoxTeacherPassword.Text.Trim());
                AddXmlElement(xmlDoc, newUserElement, "Role", "Teacher");

                // Create a "Classes" element if any class checkbox is checked
                if (checkBoxAI.Checked || checkBoxOS.Checked || checkBoxPD.Checked)
                {
                    XmlElement classesElement = xmlDoc.CreateElement("Classes");

                    if (checkBoxAI.Checked)
                        AddXmlElement(xmlDoc, classesElement, "class", "AI");
                    if (checkBoxOS.Checked)
                        AddXmlElement(xmlDoc, classesElement, "class", "OS");
                    if (checkBoxPD.Checked)
                        AddXmlElement(xmlDoc, classesElement, "class", "PD");

                    newUserElement.AppendChild(classesElement);
                }

                // Append the new user element to the root "users" element
                xmlDoc.DocumentElement.AppendChild(newUserElement);

                // Save the changes back to the XML file
                xmlDoc.Save(XmlFilePath);

                // Clear text boxes after successful addition
                ClearTextTeacherBox();
                // Show success message
                MessageBox.Show("Teacher added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) || textBoxEmail.Text == "abdullah@gmail.com")
            {
                textBoxEmail.Text = "abdullah@gmail.com";
                textBoxEmail.ForeColor = Color.DarkGray;
            }
            else if (!IsValidEmail(textBoxEmail.Text))
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
            else if (!IsValidEmail(textBoxEmailU.Text) || textBoxEmailU.Text == "abdullah@gmail.com")
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
            else if (!IsValidEmail(textBoxTeacherEmailU.Text) || textBoxTeacherEmailU.Text == "abdullah@gmail.com")
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
                               || !IsValidEmail(textBoxTeacherEmailU.Text)
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








        // Helper method to add a new XML element
        private void AddXmlElement(XmlDocument xmlDoc, XmlElement parentElement, string elementName, string elementValue)
        {
            XmlElement newElement = xmlDoc.CreateElement(elementName);
            newElement.InnerText = elementValue;
            parentElement.AppendChild(newElement);
        }

        // Generate a unique ID for the new user (you can implement your own logic here)
        



        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}



