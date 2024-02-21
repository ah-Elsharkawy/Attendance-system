namespace attendanceSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
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
                    Records = new List<Record>
                    {
                        new Record { Date = new DateOnly(2024, 2, 20), Status = "Present" },
                        new Record { Date = new DateOnly(2024, 2, 21), Status = "Absent" }
                        // Add more records as needed
                    }
                }
            };
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new mainForm());
        }
    }
}