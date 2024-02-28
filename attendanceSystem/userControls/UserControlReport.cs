using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;



namespace attendanceSystem.userControls
{
    public partial class UserControlReport : UserControl
    {

        public UserControlReport()
        {
            InitializeComponent();
            LoadAndDisplayTransformedData();
            //InitializeDataGridView(); // Initialize custom DataGridView control
        }
        private void LoadAndDisplayTransformedData()
        {
            try
            {
                comboBox1.Items.Add("AI");
                comboBox1.Items.Add("PD");
                comboBox1.Items.Add("OS");

                List<StudentAttendance> studentsAttendance = GetStudentsAttendance(@"D:\iti\11-C#\Trial\Trial\data.xml");
                // Create a DataGridView

                // Add columns to DataGridView
                dataGridViewClassReport.Columns.Add("StudentID", "Student ID");
                dataGridViewClassReport.Columns.Add("Name", "Name");
                dataGridViewClassReport.Columns.Add("Date", "Date");
                dataGridViewClassReport.Columns.Add("AttendanceStatus", "Attendance Status");
                // Add rows to DataGridView
                foreach (var studentAttendance in studentsAttendance)
                {
                    Console.WriteLine(studentAttendance.StudentID);
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
        public class StudentAttendance
        {
            public string StudentID { get; set; }
            public string Name { get; set; }
            public string Date { get; set; }
            public string AttendanceStatus { get; set; }
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
            return studentsAttendance;
        }
    }
}

