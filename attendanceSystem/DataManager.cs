using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Xsl;
using attendanceSystem;
using HtmlAgilityPack;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace attendanceSystem
{
    public static class DataManager
    {
        private static XmlDocument DataDocument;
        private static XmlDocument TestDocument;
        public static User currentUser = new Admin
        {
            Id = 1,
            Name = "AdminName",
            Email = "admin@example.com",
            Password = "adminPassword",
            Role = "Admin"
        };


        private static string dataFolderPath = @"..\..\..\Data";
        static DataManager() {
            DataDocument = new XmlDocument();
            TestDocument = new XmlDocument();
            LoadData();
        }

        private static void LoadData()
        {
            try
            {
                DataDocument.Load($@"{dataFolderPath}\data.xml");
            }
            catch (Exception ex)
            {
                Console.WriteLine("couldn't read the data file");
            }
        }

        private static void ValidateData()
        {
            try
            {
                //loading the scheme to validate the data
                DataDocument.Schemas.Add(null, $@"{dataFolderPath}\dataScheme.xsd");
                DataDocument.Validate(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("invalidData");
            }
        }
        private static void SaveData()
        {
            //saving here
        }

        public static string getUsers()
        {
            return DataDocument.DocumentElement.OuterXml;
        }

        private static HtmlAgilityPack.HtmlDocument GetHtmlDocumentFromXslt(XslCompiledTransform xsltFilter, XsltArgumentList xsltArgs)
        {
            HtmlAgilityPack.HtmlDocument htmlDocument = new();

            using (MemoryStream ms = new())
            {
                xsltFilter.Transform(DataDocument, xsltArgs, ms);
                ms.Seek(0, SeekOrigin.Begin);
                htmlDocument.Load(ms);
            }

            Console.WriteLine(htmlDocument.DocumentNode.InnerHtml);

            return htmlDocument;
        }

        private static XmlDocument GetXmlDocumentFromXslt(XslCompiledTransform xsltFilter, XsltArgumentList xsltArgs)
        {
            XmlDocument xmlDocument = new();

            using (MemoryStream ms = new())
            {
                xsltFilter.Transform(DataDocument, xsltArgs, ms);
                ms.Seek(0, SeekOrigin.Begin); // Reset the stream position to read from the beginning
                xmlDocument.Load(ms);
            }

            // Print the transformed XML content
            Console.WriteLine(xmlDocument.OuterXml);

            return xmlDocument;
        }
        public static HtmlAgilityPack.HtmlDocument getUserById(int Id)
        {

            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load($@"{dataFolderPath}\userIdFilter.xslt");

            XsltArgumentList xsltArgs = new XsltArgumentList();
            xsltArgs.AddParam("userId", "", Id);

            return GetHtmlDocumentFromXslt(xslt, xsltArgs);
            
        }

        public static XmlDocument getUserXmlById(int Id)
        {
            XslCompiledTransform xslt = new();
            xslt.Load($@"{dataFolderPath}\userIdXmlFilter.xslt");

            XsltArgumentList xsltArgs = new XsltArgumentList();
            xsltArgs.AddParam("userId", "", Id);

            return GetXmlDocumentFromXslt(xslt, xsltArgs);

        }

        public static void addUser()
        {
            // add logic
        }

    }


}


