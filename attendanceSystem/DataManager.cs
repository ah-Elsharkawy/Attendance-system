﻿    using System;
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
        private static XmlDocument BackupDocument;
        public static User currentUser = new Admin("AdminName", "admin@example.com", "adminPassword", "Admin");


        private static string dataFolderPath = @"..\..\..\Data";
        static DataManager() {
            DataDocument = new XmlDocument();
            BackupDocument = new XmlDocument();
            LoadData();
        }

        public static void LoadData()
        {
            try
            {
                DataDocument.Load($@"{dataFolderPath}\data.xml");
                BackupDocument = DataDocument;
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
                DataDocument = BackupDocument;
            }
        }
        private static void SaveData()
        {
            //saving here

            DataDocument.Save($@"{dataFolderPath}\data.xml");
            BackupDocument = DataDocument;
        }

        public static void addUser(XmlDocument user)
        {
            try
            {
                XmlElement element = DataDocument.CreateElement("user");
                element.InnerXml = user.DocumentElement.InnerXml;
                DataDocument.DocumentElement.AppendChild(element);

                ValidateData();
                SaveData();

            }catch(Exception ex)
            {
                Console.WriteLine($"couldn't add the user, Exception: {ex}");
            }
            
        }

        public static string getUsers()
        {
            return DataDocument.DocumentElement.OuterXml;
        }

        

        public static string getUsersByClass(string className)
        {

            return "string";
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
            //Console.WriteLine(xmlDocument.OuterXml);

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
        public static XmlDocument getUserXmlByEmail(string email)
        {
            XslCompiledTransform xslt = new();
            xslt.Load($@"{dataFolderPath}\filterByEmail.xslt");

            XsltArgumentList xsltArgs = new XsltArgumentList();
            xsltArgs.AddParam("userEmail", "", email);

            return GetXmlDocumentFromXslt(xslt, xsltArgs);
        }

        public static void addUser()
        {
            // add logic
        }

    }


}


