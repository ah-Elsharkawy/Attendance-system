using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace attendanceSystem.userControls
{
    public partial class UserControlReport : UserControl
    {
        public UserControlReport()
        {
            InitializeComponent();
            LoadAndDisplayTransformedData();
            comboBox3.SelectedIndexChanged += ComboBox3_SelectedIndexChanged; // Attach event handler for combo box
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged; // Attach event handler for tab control
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged; // Attach event handler for combo box
        }

        private void LoadAndDisplayTransformedData()
        {
            try
            {
                // Clear existing columns and rows in DataGridView
                dataGridViewClassReport.Columns.Clear();
                dataGridViewClassReport.Rows.Clear();

                // Add columns to DataGridView
                dataGridViewClassReport.Columns.Add("StudentID", "Student ID");
                dataGridViewClassReport.Columns.Add("Name", "Name");
                dataGridViewClassReport.Columns.Add("Date", "Date");
                dataGridViewClassReport.Columns.Add("AttendanceStatus", "Attendance Status");

                // Filter students based on selected tab
                if (tabControl1.SelectedTab == tabPageClassAttendance)
                {
                    // Filter by class
                    string selectedClass = comboBox3.SelectedItem as string;
                    List<StudentAttendance> studentsAttendance = GetStudentsAttendance(@"..\..\..\Data\data.xml", selectedClass);

                    // Add rows to DataGridView
                    foreach (var studentAttendance in studentsAttendance)
                    {
                        dataGridViewClassReport.Rows.Add(
                            studentAttendance.StudentID,
                            studentAttendance.Name,
                            studentAttendance.Date,
                            studentAttendance.AttendanceStatus);
                    }
                }
                else if (tabControl1.SelectedTab == tabPageIdAttendance)
                {
                    // Filter by ID
                    string selectedID = comboBox1.SelectedItem as string; // Assuming comboBox1 contains the ID
                    List<StudentAttendance> studentsAttendance = GetStudentsAttendanceByID(@"..\..\..\Data\data.xml", selectedID);

                    // Add rows to DataGridView
                    foreach (var studentAttendance in studentsAttendance)
                    {
                        dataGridViewClassReport.Rows.Add(
                            studentAttendance.StudentID,
                            studentAttendance.Name,
                            studentAttendance.Date,
                            studentAttendance.AttendanceStatus);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAndDisplayTransformedData(); // Reload data based on selected class when combo box selection changes
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAndDisplayTransformedData(); // Reload data when tab control selection changes
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAndDisplayTransformedData(); // Reload data based on selected ID when combo box selection changes
        }

        public class StudentAttendance
        {
            public string StudentID { get; set; }
            public string Name { get; set; }
            public string Date { get; set; }
            public string AttendanceStatus { get; set; }
        }

        static List<StudentAttendance> GetStudentsAttendance(string xmlFilePath, string selectedClass)
        {
            List<StudentAttendance> studentsAttendance = new List<StudentAttendance>();

            // Load the XML document
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            // Select all user nodes
            XmlNodeList userNodes = xmlDoc.SelectNodes("/users/user");

            // Iterate through each user
            foreach (XmlNode userNode in userNodes)
            {
                string role = userNode.SelectSingleNode("Role").InnerText;

                // Check if the user is a student
                if (role == "Student")
                {
                    string userId = userNode.SelectSingleNode("Id").InnerText;
                    string name = userNode.SelectSingleNode("Name").InnerText;
                    XmlNodeList attendanceRecords = userNode.SelectNodes("Attendance/Record");
                    string sClass = userNode.SelectSingleNode("SClass")?.InnerText ?? ""; // Get SClass or set to empty string if not found

                    // Check if the selected class matches the student's class
                    if (selectedClass == null || sClass == selectedClass)
                    {
                        // Check and retrieve attendance records
                        foreach (XmlNode recordNode in attendanceRecords)
                        {
                            string date = recordNode.SelectSingleNode("Date").InnerText;
                            string status = recordNode.SelectSingleNode("Status").InnerText;

                            // Add student details to the list
                            studentsAttendance.Add(new StudentAttendance
                            {
                                StudentID = userId,
                                Name = name,
                                Date = date,
                                AttendanceStatus = status
                            });
                        }
                    }
                }
            }
            return studentsAttendance;
        }

        static List<StudentAttendance> GetStudentsAttendanceByID(string xmlFilePath, string selectedID)
        {
            List<StudentAttendance> studentsAttendance = new List<StudentAttendance>();

            // Load the XML document
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            // Select all user nodes
            XmlNodeList userNodes = xmlDoc.SelectNodes("/users/user");

            // Iterate through each user
            foreach (XmlNode userNode in userNodes)
            {
                string role = userNode.SelectSingleNode("Role").InnerText;
                if (role == "Student")
                {
                    string sClass = userNode.SelectSingleNode("SClass").InnerText;
                    string name = userNode.SelectSingleNode("Name").InnerText;
                    XmlNodeList attendanceRecords = userNode.SelectNodes("Attendance/Record");
                    string userId  = userNode.SelectSingleNode("Id")?.InnerText ?? "";

                    // Check if the ID matches
                    if ( userId == selectedID)
               
                    // Retrieve attendance records
                    foreach (XmlNode recordNode in attendanceRecords)
                    {
                        string date = recordNode.SelectSingleNode("Date").InnerText;
                        string status = recordNode.SelectSingleNode("Status").InnerText;

                        // Add student details to the list
                        studentsAttendance.Add(new StudentAttendance
                        {
                            StudentID = userId,
                            Name = name,
                            Date = date,
                            AttendanceStatus = status
                        });
                    }
                }
            }
            return studentsAttendance;
        }
    }
}
