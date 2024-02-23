namespace attendanceSystem
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        public void loginBtn_Click(object sender, EventArgs e)
        {
            List<Record> attendanceRecords = new List<Record>
        {
            new Record { Date = DateOnly.Parse("2024-02-02"), Status = "absent" },
            new Record { Date = DateOnly.Parse("2024-02-03"), Status = "present" }
            // Add more records if needed
        };

            // Create an instance of the Attendance class
            Attendance attendance = new Attendance
            {
                Record = attendanceRecords
            };

            Student student = new Student
            {
                Id = 1,
                Name = "John Doe",
                Email = "john@example.com",
                Password = "password123",
                Role = "Student",
                SClass = "PD",
                Attendance = attendance
            };

            Button button = sender as Button;

            if (button != null)
            {
                textBox1.Text = DataManager.getUsers();
                //textBox1.Text = FormatsConverter.Serialize<Student>(student);
            }
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
