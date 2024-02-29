using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;
using PdfWriter = iTextSharp.text.pdf.PdfWriter;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Pdf;
using iText.Layout;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace attendanceSystem.userControls
{
    public partial class UserControlReport : UserControl
    {
        private List<string> studentsIds = new List<string>();
        public UserControlReport()
        {
            InitializeComponent();
            LoadAndDisplayTransformedData();
            comboBox3.SelectedIndexChanged += ComboBox3_SelectedIndexChanged; // Attach event handler for combo box
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged; // Attach event handler for tab control
            tabControl1.TabPages[1].Enter += tabPageIdAttendance_Enter; // Attach event handler for entering the second tab
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
                dataGridViewClassReport.Columns.Add("AbsentDays", "Number of Absence Days"); // Add new column

                // Filter by class
                string selectedClass = comboBox3.SelectedItem as string;
                List<StudentAttendance> studentsAttendance;
                if (selectedClass != null)
                {
                    studentsAttendance = GetStudentsAttendance(@"..\..\..\Data\data.xml", selectedClass);
                }
                else
                {
                    studentsAttendance = GetAllStudentsAttendance(@"..\..\..\Data\data.xml");
                }

                // Dictionary to store the total absence days for each student
                Dictionary<string, int> studentAbsenceDays = new Dictionary<string, int>();

                // Calculate total absence days for each student
                // Calculate total absence days for each student
                foreach (var studentAttendance in studentsAttendance)
                {
                    string studentKey = studentAttendance.StudentID + "|" + studentAttendance.Name;

                    if (studentAttendance.AttendanceStatus == "Absent")
                    {
                        if (studentAbsenceDays.ContainsKey(studentKey))
                        {
                            // If student already exists in the dictionary, increment absence days count
                            studentAbsenceDays[studentKey]++;
                        }
                        else
                        {
                            // If student doesn't exist in the dictionary, initialize absence days count to 1
                            studentAbsenceDays.Add(studentKey, 1);
                        }
                    }
                }


                // Add rows to DataGridView
                foreach (var studentInfo in studentAbsenceDays)
                {
                    string[] studentData = studentInfo.Key.Split('|');
                    string studentID = studentData[0];
                    string studentName = studentData[1];
                    int absenceCount = studentInfo.Value;

                    // Add row to DataGridView
                    dataGridViewClassReport.Rows.Add(studentID, studentName, absenceCount);
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

        private void tabPageIdAttendance_Enter(object sender, EventArgs e)
        {
            LoadAndDisplayTransformedData(); // Load all data when entering the second tab
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

        static List<StudentAttendance> GetAllStudentsAttendance(string xmlFilePath)
        {
            List<StudentAttendance> allStudentsAttendance = new List<StudentAttendance>();

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

                    // Retrieve attendance records
                    foreach (XmlNode recordNode in attendanceRecords)
                    {
                        string date = recordNode.SelectSingleNode("Date").InnerText;
                        string status = recordNode.SelectSingleNode("Status").InnerText;

                        // Add student details to the list
                        allStudentsAttendance.Add(new StudentAttendance
                        {
                            StudentID = userId,
                            Name = name,
                            Date = date,
                            AttendanceStatus = status
                        });
                    }
                }
            }
            return allStudentsAttendance;
        }

        private void ExportDataToPdf()
        {
            try
            {
                // Create a Document
                iTextSharp.text.Document doc = new iTextSharp.text.Document();
                // Set the file path for the PDF file
                string filePath = @"..\..\..\Data\report.pdf";

                // Create a PdfWriter instance to write the document to the file
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

                // Open the Document for writing
                doc.Open();

                // Add a title to the document
                doc.Add(new iTextSharp.text.Paragraph("Attendance Report"));

                // Create a PdfPTable with the same number of columns as the DataGridView
                PdfPTable table = new PdfPTable(dataGridViewClassReport.Columns.Count);

                // Add column headers from the DataGridView to the PdfPTable
                foreach (DataGridViewColumn column in dataGridViewClassReport.Columns)
                {
                    table.AddCell(new PdfPCell(new iTextSharp.text.Phrase(column.HeaderText)));
                }

                // Add data from the DataGridView to the PdfPTable
                foreach (DataGridViewRow row in dataGridViewClassReport.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        table.AddCell(new PdfPCell(new iTextSharp.text.Phrase(cell.Value?.ToString() ?? "")));
                    }
                }

                // Add the PdfPTable to the document
                doc.Add(table);

                // Close the document
                doc.Close();

                // Open the PDF file after successful export
                //System.Diagnostics.Process.Start(filePath);

                // Show a message indicating successful export
                MessageBox.Show("Data exported to PDF successfully and file opened!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void pictureBoxPrinter_Click_1(object sender, EventArgs e)
        {
            ExportDataToPdf();
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            LoadStudentsIds();
            //studentRecords(DataManager.getUserXmlById(4).InnerXml);
            //Console.WriteLine(DataManager.getUserXmlById(4).InnerXml);
        }

        private void LoadStudentsIds()
        {
            XmlDocument userDoc = new XmlDocument();
            userDoc.LoadXml(DataManager.getUsers());

            foreach (XmlNode u in userDoc.SelectNodes("//user"))
            {
                var uId = u.SelectSingleNode("Id").InnerText;
                var uRole = u.SelectSingleNode("Role").InnerText;

                if (uRole == "Student")
                    studentsIds.Add(uId);
            }
        }
        private void studentRecords(string userXml, DateTime? startDate, DateTime? endDate)
        {
            Console.WriteLine(userXml);
            XmlDocument userDoc = new XmlDocument();
            userDoc.LoadXml(userXml);
            var studentName = userDoc.SelectSingleNode("//Name").InnerText;
            resultStudentName.Text = studentName;
            dataGridViewStudentReport.Rows.Clear();
            foreach (XmlNode r in userDoc.SelectNodes("//Record"))
            {
                var rDate = DateTime.Parse(r.SelectSingleNode("Date").InnerText);
                var rStatus = r.SelectSingleNode("Status").InnerText;

                if ((!startDate.HasValue || rDate.Date >= startDate.Value.Date) &&
                    (!endDate.HasValue || rDate.Date <= endDate.Value.Date))

                    dataGridViewStudentReport.Rows.Add(rDate.ToShortDateString(), rStatus);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*var searchId = textBox1.Text;
            var found = studentsIds.Find(id => id == searchId);

            if (found != null)
            {
                //studentRecords(DataManager.getUserXmlById(int.Parse(searchId)).InnerXml);
            }
            else
            {

            }*/
        }


        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPageIdAttendance_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var searchId = textBox1.Text;
            var found = studentsIds.Find(id => id == searchId);
            var startDate = dateTimePicker1.Value;
            var endDate = dateTimePicker2.Value;

            if (found != null)
            {
                studentRecords(DataManager.getUserXmlById(int.Parse(searchId)).InnerXml, startDate, endDate);
            }
            else
            {
                dataGridViewStudentReport.Rows.Clear();
            }
        }
    }
}
