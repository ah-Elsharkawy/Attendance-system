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
                dataGridViewClassReport.Columns.Add("Date", "Date");
                dataGridViewClassReport.Columns.Add("AttendanceStatus", "Attendance Status");

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

                // Show a message indicating successful export
                MessageBox.Show("Data exported to PDF successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    }
}

