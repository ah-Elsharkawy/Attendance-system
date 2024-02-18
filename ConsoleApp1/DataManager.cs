using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp1
{
    public class DataManager
    {
        private XmlDocument dataDocument;
        public DataManager()
        {
            dataDocument = new XmlDocument();
            LoadData();
        }

        private XmlDocument DataDocument { get => dataDocument; set => dataDocument = value; }

        private void LoadData()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            DataDocument.Load(@"..\..\..\..\attendanceSystem\Data\data.xml");
            Console.WriteLine(DataDocument.OuterXml);
        }
    }
}
