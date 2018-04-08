using ConApp.Model;
using ConApp.Properties;
using Net.Tools;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConApp
{
    public class XMLDemo
    {
        [XmlRoot("Cat")]
        public class Cat
        {
            //定义Color属性的序列化为cat节点的属性
            [XmlAttribute("Color")]
            public string Color { get; set; }

            //要求不序列化Speed属性    [XmlIgnore]
            [XmlElement("Speed")]
            public int Speed { get; set; }

            //设置Saying属性序列化为Xml子元素
            [XmlElement("Saying")]
            public string Saying { get; set; }
        }

        [XmlRoot("RootItem")]
        public class CatCollection
        {
            [XmlArray("ICats"), XmlArrayItem("ICat")]
            public Cat[] Cats { get; set; }
        }

        public static string ObjectToXMl(object p)
        {
            string result = "";
            XmlSerializer xmlSerializer = new XmlSerializer(p.GetType());
            //  xmlSerializer.Serialize(Console.Out, p);
            Encoding encoding2 = new UTF8Encoding(false);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, encoding2))
                {
                    XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
                    xmlSerializerNamespaces.Add("", "");
                    xmlSerializer.Serialize(xmlTextWriter, p, xmlSerializerNamespaces);
                    result = Encoding.UTF8.GetString(memoryStream.ToArray());
                }
            }
            return result;
        }

        public static void XmlSerializerDemo()
        {
            //XmlMapping
            XMLPlatformModel model = new XMLPlatformModel
            {
                CheckCode = "180014190010",
                Token = "H29G3-MZTKQ535-D7T95OAK-1PKOEV48",
                AplData = new AplDataPlatform
                {
                    Code = "01"
                }
            };

            StringBuilder sb = new StringBuilder();
            StringWriter tw = new StringWriter(sb);
            XmlSerializer sz = new XmlSerializer(typeof(XMLPlatformModel));
            sz.Serialize(tw, model);
            tw.Close();
            Console.WriteLine(sb.ToString());
        }

        public static void XMLDemo1()
        {
            //删除节点
            //XDocument XMLDoc = XDocument.Load(path);
            //XElement elment = (from xml1 in XMLDoc.Descendants("Node")
            //                   select xml1).FirstOrDefault();
            //elment.Remove();
            //XMLDoc.Save(path);

            string xmlInfo = Properties.Resources.XML;

            DirectoryInfo basrDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            DirectoryInfo codeDir = basrDir.Parent.Parent;
            string path = Path.Combine(codeDir.FullName, "Resource", "XML.xml");

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/info/collage");
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                Console.WriteLine(xmlNode["name"].InnerText, xmlNode["students"].InnerText);
            }
        }

        public static void XMLDemo2()
        {
            CitiesListResponse response = new CitiesListResponse
            {
                Result = new Result
                {
                    Value = "123465",
                    Code = "001"
                },
                CitiesList = new City[]
                {
                    new City {PinYin="suzhou",Value="苏州" ,HasOutService="123",Info="苏州",Population=123456},
                    new City {PinYin="wuxi",Value="无锡" ,HasOutService="234",Info="无锡",Population=234567},
                    new City {PinYin="nanjing",Value="南京" ,HasOutService="456",Info="南京",Population=345678},
                }
            };
            string str = XmlSerializeHelper.Serializer(response);
            Console.WriteLine(str);
            Console.ReadLine();

            XmlSerializer serializer = new XmlSerializer(typeof(CitiesListResponse));
            serializer.Serialize(Console.Out, response);
            Console.Read();
        }

        public static void XMLDemo3()
        {
            string xmlString = @"﻿<?xml version='1.0' encoding='utf-8'?>
                                <GetCitiesListResponse xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>
                                    <Result Code='000000'>成功</Result>
                                    <CitiesList>
                                        <City PinYin='beijing' HasOutService='Y'>北京</City>
                                        <City PinYin='shanghai' HasOutService='Y'>上海</City>
                                    </CitiesList>
                                </GetCitiesListResponse>";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CitiesListResponse));

            using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
            {
                Object obj = xmlSerializer.Deserialize(memoryStream);
            }
        }

        public static void XMLDemo4()
        {
            int i = 10;
            //声明Xml序列化对象实例serializer
            XmlSerializer serializer = new XmlSerializer(typeof(int));
            //执行序列化并将序列化结果输出到控制台
            serializer.Serialize(Console.Out, i);
        }

        public static void XMLDemo5()
        {
            Person p = new Person
            {
                Name = "N1",
                Sex = '男',
                Age = 20,
                Hobbys = new[] { "hobby1", "hobby2" }
            };
            ObjectToXMl(p);
        }

        public static void XMLDemo6()
        {
            Cat cWhite = new Cat { Color = "White", Speed = 10, Saying = "White cat" };
            Cat cBlack = new Cat { Color = "Black", Speed = 15, Saying = "Black cat" };

            CatCollection cc = new CatCollection
            {
                Cats = new[] { cWhite, cBlack }
            };

            //序列化这个对象
            XmlSerializer serializer = new XmlSerializer(typeof(CatCollection));

            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add("", "");
            serializer.Serialize(Console.Out, cc, xmlSerializerNamespaces);
        }

        private const string XmlPath = "C:\\doc.XML";

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

            string xml = Resources.Person;
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

        #region XElement Demo

        public static void CreateEmployees()
        {
            XDocument doc = new XDocument(
                // To use a XElement the XDeclaration and XCooment can't be used
                //XElement doc = new XElement(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("A sample xml file"),
                new XElement("employees",
                    new XElement("employee",
                        new XAttribute("id", 1),
                        new XAttribute("salaried", "false"),
                        new XElement("name", "Gustavo Achong"),
                        new XElement("hire_date", "7/31/1996")),
                    new XElement("employee",
                        new XAttribute("id", 3),
                        new XAttribute("salaried", "true"),
                        new XElement("name", "Kim Abercrombie"),
                        new XElement("hire_date", "12/12/1997")),
                    new XElement("employee",
                        new XAttribute("id", 8),
                        new XAttribute("salaried", "false"),
                        new XElement("name", "Carla Adams"),
                        new XElement("hire_date", "2/6/1998")),
                    new XElement("employee",
                        new XAttribute("id", 9),
                        new XAttribute("salaried", "false"),
                        new XElement("name", "Jay Adams"),
                        new XElement("hire_date", "2/6/1998"))
                )
            );

            Console.WriteLine(doc.ToString());

            doc.Save(@"f:\test.xml");
        }

        public static void SingleEmployee()
        {
            XElement employee = new XElement("employee",
                new XAttribute("id", 1),
                new XAttribute("salaried", "false"),
                new XElement("name", "Gustavo Achong"),
                new XElement("hire_date", "7/31/1996"));

            Console.WriteLine(employee.ToString());
        }

        public static void WithNamespace()
        {
            XNamespace ns = "http://mycompany.com";

            XElement doc = new XElement(
                new XElement(ns + "employees",
                    new XElement("employee",
                        new XAttribute("id", 1),
                        new XAttribute("salaried", "false"),
                        // Note here that a namespace is not supplied on these
                        // elements. This will cause an emoty namespace to be
                        // included
                        new XElement("name", "Gustavo Achong"),
                        new XElement("hire_date", "7/31/1996")),
                    new XElement(ns + "employee",
                        new XAttribute("id", 3),
                        new XAttribute("salaried", "true"),
                        new XElement("name", "Kim Abercrombie"),
                        new XElement("hire_date", "12/12/1997")),
                    new XElement(ns + "employee",
                        new XAttribute("id", 8),
                        new XAttribute("salaried", "false"),
                        new XElement("name", "Carla Adams"),
                        new XElement("hire_date", "2/6/1998")),
                    new XElement(ns + "employee",
                        new XAttribute("id", 9),
                        new XAttribute("salaried", "false"),
                        new XElement("name", "Jay Adams"),
                        new XElement("hire_date", "2/6/1998"))
                )
            );
            Console.WriteLine(doc.ToString());
        }

        public static void WithNamespaceWithPrefix()
        {
            XNamespace ns1 = "http://mycompany.com";
            XNamespace ns2 = "http://somecompany.com";

            XElement doc = new XElement(
                  new XElement(ns1 + "employees",
                  new XAttribute(XNamespace.Xmlns + "ns1", ns1),
                     new XElement(ns2 + "employee",
                         new XAttribute("id", 1),
                         new XAttribute("salaried", "false"),
                         new XAttribute(XNamespace.Xmlns + "ns2", ns2),
                             new XElement(ns2 + "name", "Gustavo Achong"),
                             new XElement(ns2 + "hire_date", "7/31/1996")),
                     new XElement(ns2 + "employee",
                         new XAttribute("id", 3),
                         new XAttribute("salaried", "true"),
                         new XAttribute(XNamespace.Xmlns + "ns2", ns2),
                             new XElement(ns2 + "name", "Kim Abercrombie"),
                             new XElement(ns2 + "hire_date", "12/12/1997")),
                     new XElement(ns2 + "employee",
                         new XAttribute("id", 8),
                         new XAttribute("salaried", "false"),
                         new XAttribute(XNamespace.Xmlns + "ns2", ns2),
                            new XElement(ns2 + "name", "Carla Adams"),
                             new XElement(ns2 + "hire_date", "2/6/1998")),
                     new XElement(ns2 + "employee",
                         new XAttribute("id", 9),
                         new XAttribute("salaried", "false"),
                         new XAttribute(XNamespace.Xmlns + "ns2", ns2),
                             new XElement(ns2 + "name", "Jay Adams"),
                             new XElement(ns2 + "hire_date", "2/6/1998"))
                         )
                        );
            Console.WriteLine(doc.ToString());
        }

        public static void Casting()
        {
            XElement element1 = new XElement("number", 42);
            // It doesn't matter it the value is a string or int
            XElement element2 = new XElement("number", "42");

            int num1 = (int)element1;
            int num2 = (int)element2;
        }

        public static void TraverseTree()
        {
            XDocument doc = CreateEmployeesPrivate();

            Console.WriteLine("-- All nodes --");

            // Iterate over all nodes
            foreach (var node in doc.Nodes())
            {
                Console.WriteLine(node);
            }
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("-- XElement nodes --");

            // Iterate over the XElement nodes
            foreach (var node in doc.Nodes().OfType<XElement>())
            {
                Console.WriteLine(node);
            }
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("-- XComment nodes --");

            // Iterate over only the XComment nodes
            foreach (var node in doc.Nodes().OfType<XComment>())
            {
                Console.WriteLine(node);
            }

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("-- Employee name nodes --");

            // Iterate over only the XComment nodes
            foreach (var node in doc.Elements("employees").Elements("employee").Elements("name"))
            {
                Console.WriteLine(node);
            }
        }

        public static void CreateFromQuery()
        {
            XDocument doc = CreateEmployeesPrivate();

            // Order the employee elements by hire date and select
            // the first one as the newest employee
            var newElement = doc.Descendants("employee").Select(e => e).OrderBy(e => DateTime.Parse((string)e.Element("hire_date"))).First();

            // Create an element from the above query
            XElement element = new XElement("newest_hire", newElement);

            Console.WriteLine(element);
        }

        public static void Transform()
        {
            XDocument doc = CreateEmployeesPrivate();

            // Use query expression to find all salaried employees
            // and create a new XElement with their name(s)
            XElement element = new XElement("salaried_employees", from e in doc.Descendants("employee")
                                                                  where e.Attribute("salaried").Value == "true"
                                                                  select new XElement("employee",
                                                                      new XElement(e.Element("name")))
            );
            Console.WriteLine(element);
        }

        private static XDocument CreateEmployeesPrivate()
        {
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("A sample xml file"),
                new XElement("employees",
                    new XElement("employee",
                        new XAttribute("id", 1),
                        new XAttribute("salaried", "false"),
                        new XElement("name", "Gustavo Achong"),
                        new XElement("hire_date", "7/31/1996")),
                    new XElement("employee",
                        new XAttribute("id", 3),
                        new XAttribute("salaried", "true"),
                        new XElement("name", "Kim Abercrombie"),
                        new XElement("hire_date", "12/12/1997")),
                    new XElement("employee",
                        new XAttribute("id", 8),
                        new XAttribute("salaried", "false"),
                        new XElement("name", "Carla Adams"),
                        new XElement("hire_date", "2/6/1998")),
                    new XElement("employee",
                        new XAttribute("id", 9),
                        new XAttribute("salaried", "false"),
                        new XElement("name", "Jay Adams"),
                        new XElement("hire_date", "2/6/1998"))
                )
            );

            return doc;
        }

        #endregion XElement Demo

        #region XmlElement Demo Old

        private static XmlDocument m_doc = new XmlDocument();

        public static void CreateEmployees_Old()
        {
            XmlElement root = m_doc.CreateElement("employees");
            root.AppendChild(AddEmployee(1, "Gustavo Achong", DateTime.Parse("7/31/1996"), false));
            root.AppendChild(AddEmployee(3, "Kim Abercrombie", DateTime.Parse("12/12/1997"), true));
            root.AppendChild(AddEmployee(8, "Carla Adams", DateTime.Parse("2/6/1998"), false));
            root.AppendChild(AddEmployee(9, "Jay Adams", DateTime.Parse("2/6/1998"), false));

            m_doc.AppendChild(root);

            Console.WriteLine(m_doc.OuterXml);
        }

        private static XmlElement AddEmployee(int ID, string name, DateTime hireDate, bool isSalaried)
        {
            XmlElement employee = m_doc.CreateElement("employee");

            XmlElement nameElement = m_doc.CreateElement("name");
            nameElement.InnerText = name;

            XmlElement hireDateElement = m_doc.CreateElement("hire_date");
            hireDateElement.InnerText = hireDate.ToShortDateString();

            employee.SetAttribute("id", ID.ToString());
            employee.SetAttribute("salaried", isSalaried.ToString());
            employee.AppendChild(nameElement);
            employee.AppendChild(hireDateElement);

            return employee;
        }

        public static void Casting_Old()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("employees");
            XmlElement employee = doc.CreateElement("employee");

            XmlElement nameElement = doc.CreateElement("name");
            nameElement.InnerText = "Jay Adams";
            employee.AppendChild(nameElement);

            XmlElement idElement = doc.CreateElement("id");

            idElement.InnerText = "42";

            employee.AppendChild(idElement);

            root.AppendChild(employee);
            doc.AppendChild(root);

            // Cannot convert type 'string' to 'int'
            // No explict cast available
            //int id = (int)idElement.Value;

            int id = Convert.ToInt32(idElement.Value);
        }

        public static void GetElments()
        {
            XmlElement root = m_doc.CreateElement("employees");
            root.AppendChild(AddEmployee(1, "Gustavo Achong", DateTime.Parse("7/31/1996"), false));
            root.AppendChild(AddEmployee(3, "Kim Abercrombie", DateTime.Parse("12/12/1997"), true));
            root.AppendChild(AddEmployee(8, "Carla Adams", DateTime.Parse("2/6/1998"), false));
            root.AppendChild(AddEmployee(9, "Jay Adams", DateTime.Parse("2/6/1998"), false));

            m_doc.AppendChild(root);

            foreach (XmlNode node in m_doc.DocumentElement.ChildNodes)
            {
                Console.WriteLine(node.ToString());
            }
        }

        #endregion XmlElement Demo Old
    }
}