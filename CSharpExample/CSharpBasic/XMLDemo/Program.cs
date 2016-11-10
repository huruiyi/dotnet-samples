using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XMLDemo.Properties;

namespace XMLDemo
{
    internal class Program
    {
        private const string XmlPath = "C:\\doc.XML";

        private static void Main(string[] args)
        {
            QueryXml3();

            Console.ReadKey();
        }

        public static void CreateXml0()
        {
            XmlDocument xml = new XmlDocument();

            XmlDeclaration xmlDec = xml.CreateXmlDeclaration("1.0", "utf-8", null);
            xml.AppendChild(xmlDec);

            XmlElement parent = xml.CreateElement("Books");
            xml.AppendChild(parent);

            XmlElement book1 = xml.CreateElement("Book");
            parent.AppendChild(book1);
            XmlElement name1 = xml.CreateElement("Name");
            name1.InnerText = "红楼梦";
            book1.AppendChild(name1);
            XmlElement price1 = xml.CreateElement("Price");
            price1.InnerText = "10";
            book1.AppendChild(price1);

            XmlElement book2 = xml.CreateElement("Book");
            book2.SetAttribute("ChineseName", "西游记");
            parent.AppendChild(book2);
            XmlElement name2 = xml.CreateElement("Name");
            name2.InnerText = "西游记";
            book2.AppendChild(name2);
            XmlElement price2 = xml.CreateElement("Price");
            price2.InnerText = "30";
            book2.AppendChild(price2);
            xml.Save(XmlPath);
        }

        public static void CreateXml1()
        {
            XElement xPersons = new XElement("Persons");

            XElement xPerson1 = new XElement("Person");
            xPerson1.SetAttributeValue("name", "小明");
            xPerson1.SetAttributeValue("sex", "男");
            xPersons.Add(xPerson1);

            XElement xPerson2 = new XElement("Person");
            xPerson2.SetAttributeValue("name", "小红");
            xPerson2.SetAttributeValue("sex", "女");
            xPersons.Add(xPerson2);

            string xmlString = xPersons.ToString();
            Console.WriteLine(xmlString);

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlString);
            xml.Save("docc.xml");
        }

        public static void CreateXml2()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmldeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(xmldeclaration);

            XmlElement order = doc.CreateElement("Order");
            doc.AppendChild(order);

            XmlElement customerName = doc.CreateElement("CustomerName");
            customerName.InnerText = "洪磊";
            order.AppendChild(customerName);

            XmlElement customerNumber = doc.CreateElement("CustomerNumber");
            customerNumber.InnerText = "HLK20130728";
            order.AppendChild(customerNumber);

            XmlElement items = doc.CreateElement("Items");
            order.AppendChild(items);

            XmlElement orderItem1 = doc.CreateElement("OrderItem");
            orderItem1.SetAttribute("Name", "电脑");
            orderItem1.SetAttribute("Count", "20");
            items.AppendChild(orderItem1);

            XmlElement orderItem2 = doc.CreateElement("OrderItem");
            orderItem2.SetAttribute("Name", "电话");
            orderItem2.SetAttribute("Count", "10");
            orderItem2.SetAttribute("Brand", "SONY");
            items.AppendChild(orderItem2);

            doc.Save("test.xml");
        }

        public static void UpdateXml()
        {
            XmlDocument xml = new XmlDocument();
            if (!File.Exists(XmlPath))
            {
                XmlDeclaration xmlDec = xml.CreateXmlDeclaration("1.0", "utf-8", null);
                xml.AppendChild(xmlDec);

                XmlElement parent = xml.CreateElement("Books");
                xml.AppendChild(parent);

                XmlElement book1 = xml.CreateElement("Book");
                book1.InnerXml = " \n<Name>三国演义</Name>\n<Price>10</Price>\n";
                parent.AppendChild(book1);
            }
            else
            {
                xml.Load(XmlPath);

                XmlElement parent = xml.DocumentElement;

                XmlElement book2 = xml.CreateElement("Book");
                book2.InnerXml = " \n<Name>红楼梦</Name>\n<Price>11</Price>\n";
                parent.AppendChild(book2);
            }
            xml.Save("C:\\doc.XML");
        }

        public static void QueryXml0()
        {
            XmlDocument doc = new XmlDocument();

            string xml = Resources.ID;
            doc.LoadXml(xml);
            XmlElement elem = doc.GetElementById("A111");
            if (elem != null)
                Console.WriteLine(elem.OuterXml);

            elem = doc.GetElementById("A222");
            if (elem != null)
                Console.WriteLine(elem.OuterXml);
        }

        public static void QueryXml1()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(XmlPath);

            XmlNodeList list1 = xml.SelectNodes("Books/Book/Name");
            if (list1 != null)
                Console.WriteLine(list1[0].InnerText);

            XmlNodeList list2 = xml.SelectNodes("Books/Book");
            if (list2 != null)
            {
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine(list2[0].InnerText);
                Console.WriteLine(list2[0].InnerXml);
                Console.WriteLine(list2[1].InnerText);
                Console.WriteLine(list2[1].InnerXml);
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++");

                Console.WriteLine(list2[0].Name);
                Console.WriteLine(list2[0].HasChildNodes);
                // Console.WriteLine(list2[0].Attributes[0].Name);没有属性值

                Console.WriteLine(list2[1].Name);
                Console.WriteLine(list2[1].HasChildNodes);
                Console.WriteLine(list2[1].Attributes[0].Name);
                Console.WriteLine(list2[1].Attributes[0].Value);
            }
        }

        public static void QueryXml2()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(XmlPath);

            //获取根节点
            XmlElement parent = doc.DocumentElement;
            // XmlNode node = doc.SelectSingleNode("Books");
            XmlNodeList xnl = parent.ChildNodes;
            foreach (XmlNode node in xnl)
            {
                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    Console.WriteLine(node.ChildNodes[i].Name + ":" + node.ChildNodes[i].InnerText);
                }
                Console.WriteLine();
            }
        }

        public static void QueryXml3()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Resources.UserInfo);

            XmlElement parent = doc.DocumentElement;
            XmlNode items = parent.SelectSingleNode("Items");
            foreach (XmlNode item in items.ChildNodes)
            {
                Console.WriteLine(item.Attributes["Name"].Value + "  " + item.Attributes["Count"].Value);
            }

            XmlNodeList xmnl = doc.SelectNodes("Order/Items/OrderItem");
            foreach (XmlNode m in xmnl)
            {
                Console.WriteLine(m.Attributes["Name"].Value + "   " + m.Attributes["Count"].Value);
            }

            XmlNode xmlNode0 = doc.SelectSingleNode("Order/Items/OrderItem[@Name='电话']");
            Console.WriteLine(xmlNode0.Attributes["Count"].Value);

            XmlNode xmlNode1 = doc.SelectSingleNode("Order/Items");
            Console.WriteLine(xmlNode1.InnerXml);
        }
    }
}