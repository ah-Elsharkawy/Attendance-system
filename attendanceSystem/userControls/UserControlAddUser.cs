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
        public string UID = "2";
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            if (textBoxName.Text.Trim().Length < 3
                || string.IsNullOrWhiteSpace(textBoxEmail.Text)
                || !IsValidEmail(textBoxEmail.Text)
                || textBoxPassword.Text.Trim().Length < 8
                || comboBoxClass.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill out all fields correctly.", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Generate a unique ID for the new student
            //string newUserId = GenerateUniqueId();

            // Create a new XmlDocument instance

            try
            {

                Student newStudent = new Student(textBoxName.Text, textBoxEmail.Text, textBoxPassword.Text, "Student", comboBoxClass.SelectedItem.ToString());

                XmlDocument newStudenXml = FormatsConverter.Serialize<Student>(newStudent);
                //textBox1.Text = newStudenXml.OuterXml;
                DataManager.addUser(newStudenXml);

                // Load the XML document
                /*XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(newStudenXml);

                

                // Create a new user element
                XmlElement newUserElement = xmlDoc.CreateElement("user");

                // Add child elements for the new student
                AddXmlElement(xmlDoc, newUserElement, "Id", newStudent.Id.ToString());
                AddXmlElement(xmlDoc, newUserElement, "Name", newStudent.Name);
                AddXmlElement(xmlDoc, newUserElement, "Email", newStudent.Email);
                AddXmlElement(xmlDoc, newUserElement, "Password", newStudent.Password);
                AddXmlElement(xmlDoc, newUserElement, "Role", newStudent.Role);
                AddXmlElement(xmlDoc, newUserElement, "SClass", newStudent.SClass);

                // Append the new user element to the root element
                xmlDoc.DocumentElement.AppendChild(newUserElement);

                // Save the changes back to the XML file
                xmlDoc.Save(XmlFilePath);*/

                // Load the XML file
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.Load(XmlFilePath);

                //Student newStudent = new Student(textBoxName.Text, textBoxEmail.Text, textBoxPassword.Text, "Student", comboBoxClass.SelectedItem.ToString());
                //// FormatsConverter.Serialize<Student>(newUser);
                //string serializedStudent = FormatsConverter.Serialize(newStudent);
                //File.AppendAllText(XmlFilePath, serializedStudent + Environment.NewLine);
                // Create a new "user" element
                //XmlElement newUserElement = xmlDoc.CreateElement("user");

                // Create and append child elements for the new student
                //AddXmlElement(xmlDoc, newUserElement, "Id", newUserId);
                //AddXmlElement(xmlDoc, newUserElement, "Name", textBoxName.Text.Trim());
                //AddXmlElement(xmlDoc, newUserElement, "Email", textBoxEmail.Text.Trim());
                //AddXmlElement(xmlDoc, newUserElement, "Password", textBoxPassword.Text.Trim());
                //AddXmlElement(xmlDoc, newUserElement, "Role", "Student");

                // If a class is selected, add it as a child element
                //if (comboBoxClass.SelectedIndex != -1)
                //{
                //    string selectedClass = comboBoxClass.SelectedItem.ToString();
                //    AddXmlElement(xmlDoc, newUserElement, "SClass", selectedClass);
                //}

                //// Append the new user element to the root "users" element
                //xmlDoc.DocumentElement.AppendChild(newUserElement);

                //// Save the changes back to the XML file
                //xmlDoc.Save(XmlFilePath);

                // Clear text boxes after successful addition
                //ClearTextStudentBox();

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

            // Update user data in the XML file
            UpdateUserData(UID);
        }
        private void PopulateUserData(string userId)
        {
            // Load the XML file

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(XmlFilePath);

            // Find the user node with the specified ID
            XmlNode userNode = xmlDoc.SelectSingleNode($"//user[Id='{userId}']");

            if (userNode != null)
            {
                if (userNode.SelectSingleNode("Role").InnerText == "Student")
                {
                    //tabPageUpdate.Show();
                    // Populate text boxes with user data
                    textBoxNameU.Text = userNode.SelectSingleNode("Name").InnerText;
                    textBoxEmailU.Text = userNode.SelectSingleNode("Email").InnerText;
                    textBoxEmailU.ForeColor = Color.Black;
                    textBoxPasswordU.Text = userNode.SelectSingleNode("Password").InnerText;
                    comboBoxClassU.SelectedItem = userNode.SelectSingleNode("SClass").InnerText;
                    // Additional code for populating other fields if needed
                }
                else
                {
                    //tabPageUpdateTeacher.Show();
                    // Populate text boxes with user data
                    textBoxTeacherNameU.Text = userNode.SelectSingleNode("Name").InnerText;
                    textBoxTeacherEmailU.Text = userNode.SelectSingleNode("Email").InnerText;
                    textBoxTeacherEmailU.ForeColor = Color.Black;
                    textBoxTeacherPasswordU.Text = userNode.SelectSingleNode("Password").InnerText;
                    XmlNode classesNode = userNode.SelectSingleNode("Classes");
                    if (classesNode != null)
                    {
                        foreach (XmlNode classNode in classesNode.ChildNodes)
                        {
                            string className = classNode.InnerText;
                            if (className == "AI")
                                checkBoxAIU.Checked = true;
                            else if (className == "OS")
                                checkBoxOSU.Checked = true;
                            else if (className == "PD")
                                checkBoxPDU.Checked = true;
                        }
                    }
                    // Additional code for populating other fields if needed
                }
                // Populate text boxes with user data
                // Additional code for populating other fields if needed
            }
            else
            {
                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to update user data in the XML file
        private void UpdateUserData(string userId)
        {
            // Load the XML file
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(XmlFilePath);

            // Find the user node with the specified ID
            XmlNode userNode = xmlDoc.SelectSingleNode($"//user[Id='{userId}']");

            if (userNode != null)
            {
                // Update user data

                if (userNode.SelectSingleNode("Role").InnerText == "Student")
                {
                    userNode.SelectSingleNode("Name").InnerText = textBoxNameU.Text;
                    userNode.SelectSingleNode("Email").InnerText = textBoxEmailU.Text;
                    userNode.SelectSingleNode("Password").InnerText = textBoxPasswordU.Text;
                    userNode.SelectSingleNode("SClass").InnerText = comboBoxClassU.SelectedItem.ToString();

                }
                else
                {
                    userNode.SelectSingleNode("Name").InnerText = textBoxTeacherNameU.Text;
                    userNode.SelectSingleNode("Email").InnerText = textBoxTeacherEmailU.Text;
                    userNode.SelectSingleNode("Password").InnerText = textBoxTeacherPasswordU.Text;

                    // Remove the existing "Classes" element
                    XmlNode classesNode = userNode.SelectSingleNode("Classes");
                    if (classesNode != null)
                        userNode.RemoveChild(classesNode);

                    // Create a new "Classes" element if any class checkbox is checked
                    if (checkBoxAIU.Checked || checkBoxOSU.Checked || checkBoxPDU.Checked)
                    {
                        XmlElement newClassesElement = xmlDoc.CreateElement("Classes");

                        if (checkBoxAIU.Checked)
                            AddXmlElement(xmlDoc, newClassesElement, "class", "AI");
                        if (checkBoxOSU.Checked)
                            AddXmlElement(xmlDoc, newClassesElement, "class", "OS");
                        if (checkBoxPDU.Checked)
                            AddXmlElement(xmlDoc, newClassesElement, "class", "PD");

                        userNode.AppendChild(newClassesElement);
                    }
                }
                //userNode.SelectSingleNode("Name").InnerText = textBoxNameU.Text;
                //userNode.SelectSingleNode("Email").InnerText = textBoxEmailU.Text;
                //userNode.SelectSingleNode("Password").InnerText = textBoxPasswordU.Text;
                // Additional code for updating other fields if needed

                // Save the changes back to the XML file
                xmlDoc.Save(XmlFilePath);

                // Clear text boxes after successful update
                ClearTextStudentBoxUpdate();

                MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            //validate email
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
        private int GenerateUniqueId()
        {
            // Construct the full path to the XML file
            string xmlFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, XmlFilePath));

            // Load the XML file
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            // Get all user ID nodes
            XmlNodeList userIdNodes = xmlDoc.SelectNodes("//user/Id");

            // Initialize maxId to a minimum value
            int maxId = 0;

            // Find the maximum existing ID
            foreach (XmlNode userIdNode in userIdNodes)
            {
                int currentId;
                if (int.TryParse(userIdNode.InnerText, out currentId))
                {
                    if (currentId > maxId)
                    {
                        maxId = currentId;
                    }
                }
            }

            // Increment the maximum existing ID to generate the new ID
            int newId = maxId + 1;

            // Return the new ID as a string
            return newId;
        }
        private void buttonAddTeacher_Click(object sender, EventArgs e)
        {
            if (!checkBoxAI.Checked && !checkBoxOS.Checked && !checkBoxPD.Checked)
            {
                pictureBoxTeacherClasses.Visible = true;
            }
            else
            {
                pictureBoxTeacherClasses.Visible = false;
            }
            if (textBoxTeacherName.Text.Trim().Length < 3
                || !IsValidEmail(textBoxTeacherEmail.Text)
                || textBoxTeacherEmail.Text == "abdullah@gmail.com"
                || textBoxTeacherPassword.Text.Trim().Length < 8
                || (!checkBoxAI.Checked && !checkBoxOS.Checked && !checkBoxPD.Checked))
            {
                MessageBox.Show("Please fill out all fields correctly.", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  Generate a unique ID for the new user
            //Convert function return to string GenerateUniqueId();

            string newUserId = GenerateUniqueId().ToString();

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
                AddXmlElement(xmlDoc, newUserElement, "Id", newUserId);
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
            //validate email
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
            PopulateUserData(UID);
        }

        private void tabPageUpdateTeacher_Enter(object sender, EventArgs e)
        {

            ClearTextTeacherBoxUpdate();
            pictureBoxTeacherEmailU.Visible = false;
            PopulateUserData(UID);

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

            //compelete add code here
            UpdateUserData(UID);
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

        private void pictureBoxTeacherName_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Name must be longer than 3 char", pictureBoxTeacherName);

        }

        private void pictureBoxTeacherPassword_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Password must be longer than 8 char", pictureBoxTeacherPassword);

        }

        private void pictureBoxTeacherClasses_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Please chose class", pictureBoxTeacherClasses);

        }

        private void textBoxTeacherName_Leave(object sender, EventArgs e)
        {
            if (textBoxTeacherName.Text.Trim().Length < 3)
            {
                pictureBoxTeacherName.Visible = true;
            }
            else
            {
                pictureBoxTeacherName.Visible = false;
            }
        }

        private void textBoxTeacherPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxTeacherPassword.Text.Trim().Length < 8)
            {
                pictureBoxTeacherPassword.Visible = true;
            }
            else
            {
                pictureBoxTeacherPassword.Visible = false;
            }
        }

        private void pictureBoxStudentName_MouseHover(object sender, EventArgs e)
        {

            toolTip.Show("Name must be longer than 3 char", pictureBoxStudentName);
        }

        private void pictureBoxStudentPassword_MouseHover(object sender, EventArgs e)
        {

            toolTip.Show("Password must be longer than 8 char", pictureBoxStudentPassword);
        }

        private void pictureBoxStudentClass_MouseHover(object sender, EventArgs e)
        {

            toolTip.Show("Please chose class", pictureBoxStudentClass);
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {

            if (textBoxName.Text.Trim().Length < 3)
            {
                pictureBoxStudentName.Visible = true;
            }
            else
            {
                pictureBoxStudentName.Visible = false;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {

            if (textBoxPassword.Text.Trim().Length < 8)
            {
                pictureBoxStudentPassword.Visible = true;
            }
            else
            {
                pictureBoxStudentPassword.Visible = false;
            }
        }

        private void comboBoxClass_Leave(object sender, EventArgs e)
        {

            if (comboBoxClass.SelectedIndex == -1)
            {
                pictureBoxStudentClass.Visible = true;
            }
            else
            {
                pictureBoxStudentClass.Visible = false;
            }
        }
    }
}



