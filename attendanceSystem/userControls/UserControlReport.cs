using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;


namespace attendanceSystem.userControls
{
    public partial class UserControlReport : UserControl
    {
        private UserControlReport dataGridView1; // Declare custom DataGridView control

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
            dataGridView1 = this.dataGridView1;

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
            // Load the XML data
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("data.xml"); // Replace "data.xml" with the path to your transformed XML file

            // Parse the transformed XML and populate custom DataGridView
            ParseAndPopulateDataGridView(xmlDocument);
        }

        private void ParseAndPopulateDataGridView(XmlDocument xmlDocument)
        {
            // Clear existing rows
            //dataGridView1.Rows.Clear();

            // Loop through each <tr> element in the transformed XML
            foreach (XmlNode trNode in xmlDocument.SelectNodes("//tr"))
            {
                // Extract data from <td> elements within <tr>
                string studentId = trNode.SelectSingleNode("td[1]").InnerText;
                string studentName = trNode.SelectSingleNode("td[2]").InnerText;
                string studentClass = trNode.SelectSingleNode("td[3]").InnerText;
                string date = trNode.SelectSingleNode("td[4]").InnerText;
                string status = trNode.SelectSingleNode("td[5]").InnerText;

                // Add a new row to custom DataGridView with extracted data
                dataGridView1.rows.Add(studentId, studentName, studentClass, date, status);
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

        }
    }
}
