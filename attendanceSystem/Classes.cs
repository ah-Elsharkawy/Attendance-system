using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace attendanceSystem
{


    [XmlRoot("user")]
    public class User
    {
        private const string XmlFilePath = "../../../Data/data.xml";

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User() { }
        public User(string name, string email, string password, string role)
        {
            Id = GenerateUniqueId();
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }

        private int GenerateUniqueId()
        {
            // Construct the full path to the XML file
            string xmlFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, XmlFilePath));

            // Load the XML file
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            // Get all user ID nodes
            XmlNodeList userIdNodes = xmlDoc.SelectNodes("//user/Id");

            // Initialize maxId to a minimum value
            int maxId = 0;

            // Find the maximum existing ID
            foreach (XmlNode userIdNode in userIdNodes)
            {
                int currentId;
                if (int.TryParse(userIdNode.InnerText, out currentId))
                {
                    if (currentId > maxId)
                    {
                        maxId = currentId;
                    }
                }
            }

            // Increment the maximum existing ID to generate the new ID
            int newId = maxId + 1;

            // Return the new ID as a string
            return newId;
        }
    }

    public class Admin : User
    {
        public Admin() { }
        public Admin(string name, string email, string password, string role) : base(name, email, password, role) { }
        // Add any additional properties or methods specific to the Admin class here
    }

    public class Teacher : User
    {
        public List<string> Classes { get; set; }

        public Teacher() { }
        public Teacher(string name, string email, string password, string role, List<string> classes) : base(name, email, password, role)
        {
            Classes = classes;
        }
        public override string ToString()
        {
            return $"Teacher Id: {Id}, Name: {Name}, Email: {Email}, Role: {Role}, Classes: {string.Join(", ", Classes)}";
        }
    }

    public class Student : User
    {
        public Attendance Attendance { get; set; } = new Attendance();
        public string SClass { get; set; }
        

        public Student() { }
        public Student(string name, string email, string password, string role, string sClass) : base(name, email, password, role)
        {
            SClass = sClass;
        }
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
