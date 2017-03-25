using ConApp.Model;
using Net.Tools;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ConApp
{
    public partial class Program
    {
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
    }
}