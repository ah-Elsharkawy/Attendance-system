using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace attendanceSystem
{
    public static class FormatsConverter
    {
        public static T Deserialize<T>(string xmlData, string role)
        {
            xmlData = $"<{role}>{xmlData}</{role}>";
            Console.WriteLine(xmlData);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xmlData))
            {
                T result = (T)serializer.Deserialize(reader);
                if(role == "Teacher")
                {
                    PropertyInfo classesProp = typeof(T).GetProperty("Classes");
                    if (classesProp != null && classesProp.PropertyType == typeof(List<string>))
                    {
                        List<string> classesList = new List<string>();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(xmlData);
                        var classes = doc.SelectNodes("//class");
                        foreach (XmlNode c in classes)
                        {
                            classesList.Add(c.InnerText);
                        }
                        classesProp.SetValue(result, classesList);
                    }
                    
                }
                return result;
            }
        }
        public static string Serialize<T>(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", ""); // Remove namespace declaration

            using (StringWriter writer = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    OmitXmlDeclaration = true // Remove XML declaration
                };

                using (XmlWriter xmlWriter = XmlWriter.Create(writer, settings))
                {
                    serializer.Serialize(xmlWriter, obj, namespaces);
                }

                string xmlString = writer.ToString();

                // Replace the root element tag with the specified root element name
                xmlString = xmlString.Replace("<" + typeof(T).Name + ">", "<user>");
                xmlString = xmlString.Replace("</" + typeof(T).Name + ">", "</user>");

                return xmlString;
            }
        }

    }
}
