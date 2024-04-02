using ConsoleApp2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ConsoleApp2;
using Fairy.ConApp.Exe;
using Fairy.ConApp.Model;
using Fairy.ConApp.Utils;

namespace Fairy.ConApp.Test
{
    public class XmlTest
    {
        public static void Class1_Test()
        {
            Class1 c1 = new Class1 { IntValue = 3, StrValue = "Fish Li" };
            string xml = XmlHelper.XmlSerialize(c1, Encoding.UTF8);
            Console.WriteLine(xml);

            Console.WriteLine("---------------------------------------");

            Class1 c2 = XmlHelper.XmlDeserialize<Class1>(xml, Encoding.UTF8);
            Console.WriteLine("IntValue: " + c2.IntValue);
            Console.WriteLine("StrValue: " + c2.StrValue);
        }

        public static void Class2_Test()
        {
            Class2 c1 = new Class2 { IntValue = 3, StrValue = "Fish Li" };
            string xml = XmlHelper.XmlSerialize(c1, Encoding.UTF8);
            Console.WriteLine(xml);

            Console.WriteLine("---------------------------------------");

            Class2 c2 = XmlHelper.XmlDeserialize<Class2>(xml, Encoding.UTF8);
            Console.WriteLine("IntValue: " + c2.IntValue);
            Console.WriteLine("StrValue: " + c2.StrValue);
        }

        public static void Class3_Test()
        {
            Class3 c1 = new Class3 { IntValue = 3, StrValue = "Fish Li" };
            string xml = XmlHelper.XmlSerialize(c1, Encoding.UTF8);
            Console.WriteLine(xml);

            Console.WriteLine("---------------------------------------");

            Class3 c2 = XmlHelper.XmlDeserialize<Class3>(xml, Encoding.UTF8);
            Console.WriteLine("IntValue: " + c2.IntValue);
            Console.WriteLine("StrValue: " + c2.StrValue);
        }

        public static void Class4_Test()
        {
            Class4 c1 = new Class4 { IntValue = 3, StrValue = "Fish Li" };
            Class4 c2 = new Class4 { IntValue = 4, StrValue = "http://www.cnblogs.com/fish-li/" };

            List<Class4> list = new List<Class4> { c1, c2 };
            string xml = XmlHelper.XmlSerialize(list, Encoding.UTF8);
            Console.WriteLine(xml);

            Class4[] list2 = new Class4[] { c1, c2 };
            string xml2 = XmlHelper.XmlSerialize(list2, Encoding.UTF8);
            Console.WriteLine(xml2);
        }

        public static void Class4List_Test()
        {
            Class4 c1 = new Class4 { IntValue = 3, StrValue = "Fish Li" };
            Class4 c2 = new Class4 { IntValue = 4, StrValue = "http://www.cnblogs.com/fish-li/" };
            Class4List list = new Class4List { c1, c2 };
            string xml = XmlHelper.XmlSerialize(list, Encoding.UTF8);
            Console.WriteLine(xml);
        }

        private static void Root_Test()
        {
            Class2 c1 = new Class2 { IntValue = 3, StrValue = "Fish Li" };
            Class2 c2 = new Class2 { IntValue = 4, StrValue = "http://www.cnblogs.com/fish-li/" };

            Class3 c3 = new Class3 { IntValue = 5, StrValue = "Test List" };

            Root root = new Root { Class3 = c3, List = new List<Class2> { c1, c2 } };
            string xml = XmlHelper.XmlSerialize(root, Encoding.UTF8);
            Console.WriteLine(xml);

            Root2 root2 = new Root2 { Class3 = c3, List = new List<Class2> { c1, c2 } };
            string xml2 = XmlHelper.XmlSerialize(root2, Encoding.UTF8);
            Console.WriteLine(xml2);
        }

        public static void X_Test()
        {
            X1 x1a = new X1 { AA = 1, BB = 2 };
            X1 x1b = new X1 { AA = 3, BB = 4 };
            X2 x2 = new X2 { CC = "ccccccccccc", DD = "dddddddddddd" };
            XRoot root = new XRoot { List = new List<XBase> { x1a, x1b, x2 } };

            string xml = XmlHelper.XmlSerialize(root, Encoding.UTF8);
            Console.WriteLine(xml);
        }

        public static void Exe_Test()
        {
            string directory = Directory.GetCurrentDirectory();

            string xmlPath = Path.Combine(directory, "xml", "Links.xml");
            DynamicHelp help = XmlHelper.XmlDeserializeFromFile<DynamicHelp>(xmlPath, Encoding.UTF8);

            foreach (LinkGroup group in help.Groups)
            {
                Console.WriteLine("ID: {0}, Title: {1}, Priority: {2}, Collapsed: {3}, Expanded: {4}", group.ID, group.Title, group.Priority, group.Glyph.Collapsed, group.Glyph.Expanded);
            }
            Console.WriteLine("***********************************************************************");

            foreach (LItem item in help.Context.Links)
            {
                Console.WriteLine("URL: {0}, LinkGroup: {1}, Title: {2}", item.URL.Substring(0, 15), item.LinkGroup, item.Title);
            }
        }

        public static void TestIgnore_Test()
        {
            TestIgnore c1 = new TestIgnore { IntValue = 3, StrValue = "Fish Li" };
            c1.Url = "http://www.cnblogs.com/fish-li/";

            string xml = XmlHelper.XmlSerialize(c1, Encoding.UTF8);
            Console.WriteLine(xml);
        }

        public static void TestClass_Test()
        {
            TestClass test = new TestClass { StrValue = "Fish Li", List = new List<int> { 1, 2, 3, 4, 5 } };
            ClassB1 b1 = new ClassB1 { Test = test };

            string xml = XmlHelper.XmlSerialize(b1, Encoding.UTF8);
            Console.WriteLine(xml);

            Console.WriteLine("-----------------------------------------------------");

            ClassB1 b2 = XmlHelper.XmlDeserialize<ClassB1>(xml, Encoding.UTF8);
            Console.WriteLine("StrValue: " + b2.Test.StrValue);
            foreach (int n in b2.Test.List)
            {
                Console.WriteLine(n);
            }
        }
    }
}
