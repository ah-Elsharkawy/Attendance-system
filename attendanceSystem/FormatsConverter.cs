using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
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
                return (T)serializer.Deserialize(reader);
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
                string xmlString;
                using (XmlWriter xmlWriter = XmlWriter.Create(writer, settings))
                {
                    
                    serializer.Serialize(xmlWriter, obj, namespaces);
                    //xmlWriter.WriteEndElement();
                    // Replace the root element tag with the specified root element name
                    xmlString = writer.ToString();
                    xmlString = xmlString.Replace("<" + typeof(T).Name + ">", "<" + "User" + ">");
                    xmlString = xmlString.Replace("</" + typeof(T).Name + ">", "</" + "User" + ">");
                }

                return xmlString;
            }
        }
    }
}
