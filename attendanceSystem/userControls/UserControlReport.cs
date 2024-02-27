using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;


namespace attendanceSystem.userControls
{
    public partial class UserControlReport : UserControl
    {
        //private UserControlReport dataGridView1; // Declare custom DataGridView control

        public UserControlReport()
        {
            InitializeComponent();
            InitializeDataGridView(); // Initialize custom DataGridView control

            // Attach event handler for when the UserControl becomes visible
            this.VisibleChanged += UserControlReport_VisibleChanged;
        }

        private void InitializeDataGridView()
        {
            // Assuming you have already designed DataGridView in your UserControl
            // Get the custom DataGridView instance
            //dataGridViewClassReport = this.dataGridViewClassReport;

            // Set DataGridView properties if necessary
            // Example:
            // dataGridView1.AllowUserToAddRows = false;
            // dataGridView1.AutoGenerateColumns = false;

            // You may need to create columns in code if not done in the designer
            // Example:
            // dataGridView1.Columns.Add("ID", "Student ID");
            // dataGridView1.Columns.Add("Name", "Name");
            // dataGridView1.Columns.Add("Class", "Class");
            // dataGridView1.Columns.Add("Date", "Date");
            // dataGridView1.Columns.Add("Status", "Status");
        }

        private void UserControlReport_VisibleChanged(object sender, EventArgs e)
        {
            // When the UserControl becomes visible, load the data
            if (this.Visible)
            {
                LoadData();
            }
        }

        public void LoadData()
        {
            DataManager.getUserXmlByClass("PD");

        }

        private void ParseAndPopulateDataGridView()
        {
            XmlDocument xmlDocument = DataManager.getUserXmlByClass("PD");
            // Clear existing rows
            //dataGridView1.Rows.Clear();

            // Loop through each <tr> element in the transformed XML
            foreach (XmlNode trNode in xmlDocument.SelectNodes("//tr"))
            {
                // Extract data from <td> elements within <tr>
                string studentId = trNode.SelectSingleNode("td[1]").InnerText;
                string studentName = trNode.SelectSingleNode("td[2]").InnerText;
                string studentClass = trNode.SelectSingleNode("td[3]").InnerText;

                // Add a new row to custom DataGridView with extracted data
                dataGridViewClassReport.Rows.Add(studentId, studentName, studentClass);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewClassReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ParseAndPopulateDataGridView();
        }
    }
}
