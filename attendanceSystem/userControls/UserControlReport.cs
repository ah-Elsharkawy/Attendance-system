using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

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
                if (role == "Student")
                {
                    string userId = userNode.SelectSingleNode("Id").InnerText;
                    string name = userNode.SelectSingleNode("Name").InnerText;
                    string sClass = userNode.SelectSingleNode("SClass")?.InnerText ?? "";
                    XmlNodeList attendanceRecords = userNode.SelectNodes("Attendance/Record");

                    // Check if the selected class matches the student's class
                    if (sClass == selectedClass)
                    {
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
            }
            return studentsAttendance;
        }
    }
}
