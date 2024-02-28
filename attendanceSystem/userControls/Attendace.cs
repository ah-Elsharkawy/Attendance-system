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

            // Handle DataError event of dataGridViewStudentAtt
            dataGridViewStudentAtt.DataError += DataGridViewStudentAtt_DataError;
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

        private void dateTimePickerAttendance_ValueChanged(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        private void comboBoxAttendanceClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        private void PopulateDataGridView()
        {
            // Clear existing rows in dataGridViewStudentAtt
            dataGridViewStudentAtt.Rows.Clear();

            // Get selected class
            string selectedClass = comboBoxAttendanceClass.SelectedItem?.ToString() ?? "PD";

            // Get selected date
            string selectedDate = dateTimePickerAttendance.Value.ToString("yyyy-MM-dd");

            // If no date is selected, set default date to "2024-02-01"
            if (string.IsNullOrEmpty(selectedDate))
            {
                selectedDate = "2024-02-01";
            }

            // Filter users based on the selected class using XPath
            XmlNodeList userNodes = xmlDoc.SelectNodes($"//user[SClass='{selectedClass}']");

            // Populate dataGridViewStudentAtt
            foreach (XmlNode userNode in userNodes)
            {
                string name = userNode.SelectSingleNode("Name").InnerText;
                string id = userNode.SelectSingleNode("Id").InnerText;
                string status = "Absent"; // Default status is Absent

                // Check if Attendance node exists
                XmlNode attendanceNode = userNode.SelectSingleNode("Attendance");
                if (attendanceNode != null)
                {
                    // Check if any Record nodes exist for the selected date
                    XmlNodeList recordNodes = attendanceNode.SelectNodes($"Record[Date='{selectedDate}']");
                    if (recordNodes.Count > 0)
                    {
                        // Get the status from the first Record node for the selected date
                        status = recordNodes[0].SelectSingleNode("Status").InnerText;
                    }
                    else
                    {
                        // Create a new Record node for the selected date with default status
                        XmlElement newRecord = xmlDoc.CreateElement("Record");
                        XmlElement newDate = xmlDoc.CreateElement("Date");
                        newDate.InnerText = selectedDate;
                        XmlElement newStatus = xmlDoc.CreateElement("Status");
                        newStatus.InnerText = "Absent"; // Default status is Absent
                        newRecord.AppendChild(newDate);
                        newRecord.AppendChild(newStatus);
                        attendanceNode.AppendChild(newRecord);
                        xmlDoc.Save(@"..\..\..\Data\data.xml");
                    }
                }
                else
                {
                    // Create Attendance node and add a new Record node with default status
                    XmlElement newAttendance = xmlDoc.CreateElement("Attendance");
                    XmlElement newRecord = xmlDoc.CreateElement("Record");
                    XmlElement newDate = xmlDoc.CreateElement("Date");
                    newDate.InnerText = selectedDate;
                    XmlElement newStatus = xmlDoc.CreateElement("Status");
                    newStatus.InnerText = "Absent"; // Default status is Absent
                    newRecord.AppendChild(newDate);
                    newRecord.AppendChild(newStatus);
                    newAttendance.AppendChild(newRecord);
                    userNode.AppendChild(newAttendance);
                    xmlDoc.Save(@"..\..\..\Data\data.xml");
                }


                dataGridViewStudentAtt.Rows.Add(name, id, selectedClass, selectedDate, status);
            }
        }

        private void DataGridViewStudentAtt_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Handle DataGridViewComboBoxCell value not valid error
            if (e.Exception is ArgumentException)
            {
                e.ThrowException = false;
                MessageBox.Show("Invalid value encountered. Setting default value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Set default value for DataGridViewComboBoxCell
                if (dataGridViewStudentAtt.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewComboBoxCell comboBoxCell)
                {
                    comboBoxCell.Value = comboBoxCell.Items[0]; // Assuming the first item is the default value
                }
            }
            else
            {
                // If not the DataGridViewComboBoxCell value error, re-throw the exception
                e.ThrowException = true;
            }
        }
    }
}


        //        private void PopulateDataGridView()
        //        {
        //            // Clear existing rows in dataGridViewStudentAtt
        //            dataGridViewStudentAtt.Rows.Clear();

        //            // Get selected class
        //            string selectedClass = comboBoxAttendanceClass.SelectedItem?.ToString() ?? "PD";

        //            // Get selected date
        //            string selectedDate = dateTimePickerAttendance.Value.ToString("yyyy-MM-dd");

        //            // If no date is selected, set default date to "2024-02-01"
        //            if (string.IsNullOrEmpty(selectedDate))
        //            {
        //                selectedDate = "2024-02-01";
        //            }

        //            // Filter users based on the selected class using XPath
        //            XmlNodeList userNodes = xmlDoc.SelectNodes($"//user[SClass='{selectedClass}']");

        //            // Populate dataGridViewStudentAtt
        //            foreach (XmlNode userNode in userNodes)
        //            {
        //                string name = userNode.SelectSingleNode("Name").InnerText;
        //                string id = userNode.SelectSingleNode("Id").InnerText;
        //                string status = "Absent";

        //                #region Ali edite
        //                var attendance = userNode.SelectSingleNode("Attendance");
        //                if (attendance == null)
        //                {
        //                    var newAttendance = xmlDoc.CreateElement("Attendance");
        //                    userNode.AppendChild(newAttendance);
        //                    xmlDoc.Save(@"..\..\..\Data\data.xml");
        //                }
        //                else

        //                {
        //                    var records=attendance.SelectNodes("Record");
        //                    if(records!=null)
        //                    {
        //                        bool findFlag=false;
        //                        foreach (XmlNode record in records)
        //                        {
        //                            var date1 = record.SelectSingleNode("Date");
        //                            if (date1.InnerText == selectedDate)
        //                            {
        //                                var status1 = record.SelectSingleNode("Status");
        //                                status = status1.InnerText;
        //                                if (status1 == null)
        //                                {
        //                                    var newStatus = xmlDoc.CreateElement("Status");
        //                                    newStatus.InnerText = "Absent";
        //                                    record.AppendChild(newStatus);
        //                                    status = newStatus.InnerText;
        //                                    xmlDoc.Save(@"..\..\..\Data\data.xml");
        //                                }
        //                                findFlag = true;
        //                                break;


        //                            }

        //                        }
        //                        if (!findFlag)
        //                        {
        //                            var newRecord = xmlDoc.CreateElement("Record");
        ////create date
        //                            var newDate = xmlDoc.CreateElement("Date");
        //                            //appeand date to record
        //                            newDate.InnerText = selectedDate;
        //                            newRecord.AppendChild(newDate);
        //                            //create status
        //                            var newStatus = xmlDoc.CreateElement("Status");
        //                            newStatus.InnerText = "Absent";
        //                            status=newStatus.InnerText;
        //                            newRecord.AppendChild(newStatus);
        //                            //append record to attendance

        //                            attendance.AppendChild(newRecord);
        //                            xmlDoc.Save(@"..\..\..\Data\data.xml");

        //                        }   

        //                    }

        //                    xmlDoc.Load(@"..\..\..\Data\data.xml");

        //                }



        //                #endregion

        //                //string status = "Absent";

        //                //try
        //                //{
        //                //    // Get attendance status for the selected date
        //                //    XmlNode statusNode = userNode.SelectSingleNode($"Attendance/Record[Date='{selectedDate}']/Status");
        //                //    if (statusNode != null)
        //                //    {
        //                //        status = statusNode.InnerText;
        //                //    }
        //                //}
        //                //catch (Exception ex)
        //                //{
        //                //    // Handle any exceptions that occur during status retrieval
        //                //    MessageBox.Show($"Error retrieving status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                //}

        //                dataGridViewStudentAtt.Rows.Add(name, id, selectedClass, selectedDate,status);
        //            }
        //        }