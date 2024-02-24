using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace attendanceSystem
{


    [XmlRoot("User")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public class Admin : User
    {
        // Add any additional properties or methods specific to the Admin class here
    }

    public class Teacher : User
    {
        public List<string> Classes { get; set; }
        public override string ToString()
        {
            return $"Teacher Id: {Id}, Name: {Name}, Email: {Email}, Role: {Role}, Classes: {string.Join(", ", Classes)}";
        }
    }

    public class Student : User
    {
        public string SClass { get; set; } 
        public Attendance Attendance { get; set; }
        public override string ToString()
        {
            return $"Student Id: {Id}, Name: {Name}, Email: {Email}, Role: {Role}, SClass: {SClass}, Attendance: {Attendance}";
        }   
    }

    public class Attendance
    {
        [XmlElement("Record")]
        public List<Record> Record { get; set; } = new List<Record>(); // List of attendance records
        public override string ToString()
        {
            string res = "";
            foreach (Record record in Record)
            {
                res += record.ToString();
            }
            return res;
        }
    }

    public class Record
    {
        public DateOnly Date { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return $"record date: {Date}, Status: {Status}";
        }
    }

}
