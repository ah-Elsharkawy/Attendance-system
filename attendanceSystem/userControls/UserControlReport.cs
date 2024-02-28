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
        }

        private void LoadAndDisplayTransformedData()
        {
            try
            {
                List<StudentAttendance> studentsAttendance = GetStudentsAttendance(@"..\..\..\Data\data.xml");

                // Clear existing columns and rows in DataGridView
                dataGridViewClassReport.Columns.Clear();
                dataGridViewClassReport.Rows.Clear();

                // Add columns to DataGridView
                dataGridViewClassReport.Columns.Add("StudentID", "Student ID");
                dataGridViewClassReport.Columns.Add("Name", "Name");
                dataGridViewClassReport.Columns.Add("Date", "Date");
                dataGridViewClassReport.Columns.Add("AttendanceStatus", "Attendance Status");
                dataGridViewClassReport.Columns.Add("SClass", "Class"); // Add SClass column

                // Add rows to DataGridView
                foreach (var studentAttendance in studentsAttendance)
                {
                    // Loop through all SClass values for the student
                    foreach (var sClass in studentAttendance.SClasses)
                    {
                        dataGridViewClassReport.Rows.Add(
                            studentAttendance.StudentID,
                            studentAttendance.Name,
                            studentAttendance.Date,
                            studentAttendance.AttendanceStatus,
                            sClass); // Add SClass value
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class StudentAttendance
        {
            public string StudentID { get; set; }
            public string Name { get; set; }
            public string Date { get; set; }
            public string AttendanceStatus { get; set; }
            public List<string> SClasses { get; set; } // Change SClass to List<string>

            public StudentAttendance()
            {
                SClasses = new List<string>(); // Initialize SClasses list
            }
        }

        static List<StudentAttendance> GetStudentsAttendance(string xmlFilePath)
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

                    // Create a new StudentAttendance object
                    StudentAttendance studentAttendance = new StudentAttendance();
                    studentAttendance.StudentID = userId;
                    studentAttendance.Name = name;

                    // Check and retrieve attendance records
                    foreach (XmlNode recordNode in attendanceRecords)
                    {
                        string date = recordNode.SelectSingleNode("Date").InnerText;
                        string status = recordNode.SelectSingleNode("Status").InnerText;

                        // Add attendance details to the StudentAttendance object
                        studentAttendance.Date = date;
                        studentAttendance.AttendanceStatus = status;
                    }

                    XmlNodeList sClasses = userNode.SelectNodes("SClass");
                    // Add all SClass values to the StudentAttendance object
                    foreach (XmlNode sClassNode in sClasses)
                    {
                        studentAttendance.SClasses.Add(sClassNode.InnerText);
                    }

                    // Add the StudentAttendance object to the list
                    studentsAttendance.Add(studentAttendance);
                }
            }
            return studentsAttendance;
        }
    }
}
