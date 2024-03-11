using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Net.Tools
{
    public class XmlSerializeHelper
    {
        public static object Deserialize(Type type, string xml)
        {
            using (StringReader sr = new StringReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(sr);
            }
        }

        public static object Deserialize(Type type, Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            return serializer.Deserialize(stream);
        }

        public static string Serializer(object obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, System.Text.Encoding.UTF8);
            xmlSerializer.Serialize(xmlTextWriter, obj);
            xmlTextWriter.Close();
            return System.Text.Encoding.UTF8.GetString(memoryStream.ToArray()).Trim();

            //MemoryStream stream = new MemoryStream();
            //XmlSerializer serializer = new XmlSerializer(obj.GetType());
            //serializer.Serialize(stream, obj);
            //stream.Position = 0;
            //StreamReader sr = new StreamReader(stream);
            //string str = sr.ReadToEnd();

            //sr.Dispose();
            //stream.Dispose();

            //return str;
        }
    }
}