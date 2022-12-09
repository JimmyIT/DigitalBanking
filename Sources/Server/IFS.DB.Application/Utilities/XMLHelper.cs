using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace IFS.DB.Application.Utilities
{
    public static class XMLHelper
    {
        public static string Serialize<T>(T entry)
        {
            string utf8Str = string.Empty;
            var serializer = new XmlSerializer(typeof(T));
            using (StringWriter writer = new Utf8StringWriter())
            {
                serializer.Serialize(writer, entry);
                utf8Str = writer.ToString();
            }
            return utf8Str;
        }

        public static T Deserialize<T>(string xmlData)
        {
            XmlSerializer s = new XmlSerializer(typeof(T));
            TextReader reader = new StringReader(xmlData);
            T entity = (T)s.Deserialize(reader);
            reader.Close();
            return entity;
        }

        public static string RemoveIndentationFormat(string xmlString)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            using (var sw = new StringWriter())
            {
                using (var xw = XmlWriter.Create(sw, new XmlWriterSettings() { Encoding = Encoding.UTF8 }))
                {
                    doc.WriteTo(xw);
                }
                return sw.ToString();
            }
        }
    }

    public class Utf8StringWriter : System.IO.StringWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}
