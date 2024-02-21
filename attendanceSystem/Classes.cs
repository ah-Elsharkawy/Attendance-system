using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attendanceSystem
{

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        // common methods like student report
    }

    public class Admin : User
    {
        // Admin methods
    }

    public class Teacher : User
    {
        public List<string> Classes { get; set; }
        
        // Teacher methods
      
    }

    public class Student : User
    {
        public string SClass { get; set; }
        public Attendance Attendance { get; set; }

        // Student methods
    }

    public class Attendance
    {
        public List<Record> Records { get; set; }
    }

    public class Record
    {
        public DateOnly Date { get; set; }
        public string Status { get; set; }
    }

}
