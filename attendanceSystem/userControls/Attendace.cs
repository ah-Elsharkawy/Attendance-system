using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace attendanceSystem.userControls
{
    public partial class Attendace : UserControl
    {
        private XmlDocument xmlDoc;
        public Attendace()
        {
            InitializeComponent();

            // Load the XML document
            xmlDoc = new XmlDocument();
            xmlDoc.Load(@"..\..\..\Data\data.xml");


            // Populate comboBoxAttendanceClass with unique class values from XML
            PopulateComboBox();
        }
        private void PopulateComboBox()
        {
            // Clear existing items
            comboBoxAttendanceClass.Items.Clear();

            // Get unique class values using XPath
            XmlNodeList classNodes = xmlDoc.SelectNodes("//user/SClass[not(. = following::SClass)]");
            foreach (XmlNode classNode in classNodes)
            {
                comboBoxAttendanceClass.Items.Add(classNode.InnerText);
            }
        }

        //private void comboBoxAttendanceClass_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // Clear existing rows in dataGridViewStudentAtt
        //    dataGridViewStudentAtt.Rows.Clear();

        //    // Get selected class
        //    string selectedClass = comboBoxAttendanceClass.SelectedItem.ToString();

        //    // Filter users based on the selected class using XPath
        //    XmlNodeList userNodes = xmlDoc.SelectNodes($"//user[SClass='{selectedClass}']");

        //    // Populate dataGridViewStudentAtt
        //    foreach (XmlNode userNode in userNodes)
        //    {
        //        string name = userNode.SelectSingleNode("Name").InnerText;
        //        string id = userNode.SelectSingleNode("Id").InnerText;
        //        string date = dateTimePickerAttendance.Value.ToString("yyyy-MM-dd");
        //        string status = GetStatus(userNode.SelectSingleNode("Attendance/Record[Date='" + date + "']/Status"));

        //        dataGridViewStudentAtt.Rows.Add(name, id, selectedClass, date, status);
        //    }
        //}

        private string GetStatus(XmlNode statusNode)
        {
            if (statusNode != null)
            {
                return statusNode.InnerText;
            }
            else
            {
                // Default status if no record found
                return "Absent";
            }
        }

        private void tabPageMarkAttendance_Click(object sender, EventArgs e)
        {

        }

        //private void comboBoxAttendanceClass_SelectedIndexChanged_1(object sender, EventArgs e)
        //{
        //    // Clear existing rows in dataGridViewStudentAtt
        //    dataGridViewStudentAtt.Rows.Clear();

        //    // Get selected class
        //    string selectedClass = comboBoxAttendanceClass.SelectedItem.ToString();

        //    // Filter users based on the selected class using XPath
        //    XmlNodeList userNodes = xmlDoc.SelectNodes($"//user[SClass='{selectedClass}']");

        //    // Populate dataGridViewStudentAtt
        //    foreach (XmlNode userNode in userNodes)
        //    {
        //        string name = userNode.SelectSingleNode("Name").InnerText;
        //        string id = userNode.SelectSingleNode("Id").InnerText;
        //        string date = dateTimePickerAttendance.Value.ToString("yyyy-MM-dd");
        //        string status = GetStatus(userNode.SelectSingleNode("Attendance/Record[Date='" + date + "']/Status"));

        //        dataGridViewStudentAtt.Rows.Add(name, id, selectedClass, date, status);
        //    }
        //}

        private void dateTimePickerAttendance_ValueChanged(object sender, EventArgs e)
        {
            // Clear existing rows in dataGridViewStudentAtt
            dataGridViewStudentAtt.Rows.Clear();

            // Get selected class
            string selectedClass = comboBoxAttendanceClass.SelectedItem.ToString();

            // Filter users based on the selected class using XPath
            XmlNodeList userNodes = xmlDoc.SelectNodes($"//user[SClass='{selectedClass}']");

            // Populate dataGridViewStudentAtt
            foreach (XmlNode userNode in userNodes)
            {
                string name = userNode.SelectSingleNode("Name").InnerText;
                string id = userNode.SelectSingleNode("Id").InnerText;
                string date = dateTimePickerAttendance.Value.ToString("yyyy-MM-dd");
                string status = GetStatus(userNode.SelectSingleNode("Attendance/Record[Date='" + date + "']/Status"));

                dataGridViewStudentAtt.Rows.Add(name, id, selectedClass, date, status);
            }
        }
    }
}
