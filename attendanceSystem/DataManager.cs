    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;
using System.Xml.Linq;
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
        private static System.Timers.Timer timer;


        private static string dataFolderPath = @"..\..\..\Data";
        private static string backupPath = $@"{dataFolderPath}\backup.xml";
        static DataManager()
        {
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
                Console.WriteLine("saved");
            }
            catch (Exception ex)
            {
                Console.WriteLine("couldn't save the data file");
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
            try
            {
                DataDocument.Save($@"{dataFolderPath}\data.xml");
                BackupDocument = DataDocument;
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
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

            }
            catch (Exception ex)
            {
                Console.WriteLine($"couldn't add the user, Exception: {ex}");
            }

        }

        public static string getUsers()
        {
            try
            {
                return DataDocument.DocumentElement.OuterXml;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "";
            }
            
        }

        public static string getUsersByName(string subName)
        {
            try
            {
                XslCompiledTransform usersFilterByName = new();
                usersFilterByName.Load($@"{dataFolderPath}\searchByNameFilter.xslt");

                XsltArgumentList xsltArgs = new XsltArgumentList();
                xsltArgs.AddParam("substring", "", subName);

                return GetXmlDocumentFromXslt(usersFilterByName, xsltArgs).DocumentElement.OuterXml;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "";
            }
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
        public static XmlDocument getUserXmlByClass(string Sclass)
        {
            XslCompiledTransform xslt = new();
            xslt.Load($@"{dataFolderPath}\filterByClass.xslt");

            XsltArgumentList xsltArgs = new XsltArgumentList();
            xsltArgs.AddParam("classFilter", "", Sclass);

            return GetXmlDocumentFromXslt(xslt, xsltArgs);

        }

        public static void deleteUserById(string Id)
        {
            try
            {
                XmlNode userToRemove = DataDocument.SelectSingleNode($"//user[Id='{Id}']");
                if (userToRemove != null)
                {
                    userToRemove.ParentNode.RemoveChild(userToRemove);
                    SaveData();
                }


                Console.WriteLine("removed successfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        public static void startBackup()
        {
            if (timer == null)
            {
                // Create a timer with a 10 minute interval
                timer = new System.Timers.Timer();
                timer.Interval = 5000; // 10 minute
                timer.Elapsed += Timer_Tick;
                timer.AutoReset = true;
            }

            // Start the timer
            timer.Start();
        }

        private static void Timer_Tick(object sender, ElapsedEventArgs e)
        {

            // save the path in queue and auto delete the oldest 10nth file

            try
            {
                DataDocument.Save(backupPath);
                BackupDocument = DataDocument;
                Console.WriteLine("backup created");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private static void restoreBackUp()
        {
            DataDocument.Load(backupPath);
        }

    }

}





