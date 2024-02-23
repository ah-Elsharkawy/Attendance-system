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
    public partial class usersPage : UserControl
    {
        public usersPage()
        {
            InitializeComponent();
            //PopulateDataGridView();

            //var students = DataManager.getUsers();
            //usersdataGrid.DataSource = students;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void usersPage_Load(object sender, EventArgs e)
        {
            Admin admin = new Admin
            {
                Id = 1,
                Name = "AdminName",
                Email = "admin@example.com",
                Password = "adminPassword",
                Role = "Admin"
            };

            // Creating an instance of Teacher
            Teacher teacher = new Teacher
            {
                Id = 2,
                Name = "TeacherName",
                Email = "teacher@example.com",
                Password = "teacherPassword",
                Role = "Teacher",
                Classes = new List<string> { "ClassA", "ClassB" }
            };

            // Creating an instance of Student
            Student student = new Student
            {
                Id = 3,
                Name = "StudentName",
                Email = "student@example.com",
                Password = "studentPassword",
                Role = "Student",
                SClass = "ClassA",
                Attendance = new Attendance
                {
                    Record = new List<Record>
                    {
                        new Record { Date = new DateOnly(2024, 2, 20), Status = "Present" },
                        new Record { Date = new DateOnly(2024, 2, 21), Status = "Absent" }
                        // Add more records as needed
                    }
                }
            };
            List<User> users = new List<User>
            {
                student,teacher,admin
            };

            XmlDocument xmlUsers = new();
            xmlUsers.LoadXml(DataManager.getUsers());

            foreach(XmlNode u in xmlUsers.SelectNodes("//user"))
            {
                var role = u.SelectSingleNode("Role").InnerText;


                if (role == "Student")
                {
                    Student studentt = FormatsConverter.Deserialize<Student>(u.InnerXml, "Student");
                    users.Add(studentt);
                    textBox1.Text += studentt;
                }
                else if(role == "Teacher")
                {
                    Teacher teachert = FormatsConverter.Deserialize<Teacher>(u.InnerXml, "Teacher");
                    textBox1.Text += teachert;
                    //textBox1.Text += teachert;
                    users.Add(teachert);
                }

            }

            userBindingSource.DataSource = users;

            foreach (DataGridViewColumn column in testDataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            testDataGridView1.AutoResizeColumns();
        }

        private void testDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.RowIndex == -1)
            //    MessageBox.Show($"header: {testDataGridView1.Columns[e.ColumnIndex].Name}");

            if(e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var columnNmae = testDataGridView1.Columns[e.ColumnIndex].Name;
                var clickedUserId = testDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                var clickedUserName = testDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                if (columnNmae == "deleteUser")
                {
                    DialogResult d = MessageBox.Show($"delete user: {clickedUserName} with id: {clickedUserId}","delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(d == DialogResult.Yes)
                    {
                        // delete user from the db
                        userBindingSource.RemoveCurrent();
                        MessageBox.Show("Removed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }

                else if(columnNmae == "editUser")
                {
                    // edit user
                }
            }

            //if (testDataGridView1.Columns[e.ColumnIndex].Name == "deleteUser")
            //{
            //    //MessageBox.Show("delete clicked");
            //    MessageBox.Show($"delete user with id: {testDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()}");
            //    userBindingSource.RemoveCurrent();

            //}
                
        }

        //private void PopulateDataGridView()
        //{
        //    // Create a new DataSet
        //    DataSet dataSet = new DataSet();

        //    // Load the XML data into the DataSet
        //    
        //    XmlReader reader = XmlReader.Create(new System.IO.StringReader(xmlData));
        //    dataSet.ReadXml(reader);

        //    // Set the DataGridView data source to the DataSet
        //    usersdataGrid.DataSource = dataSet.Tables[0];

        //    // Define the columns
        //    userID.DataPropertyName = "Id";
        //    userName.DataPropertyName = "Name";
        //    roleColumn.DataPropertyName = "Role";

        //    // Optional: Auto-resize the columns to fit the content
        //    usersdataGrid.AutoResizeColumns();
        //}
    }
}
