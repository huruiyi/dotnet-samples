using ConApp.Model;

using MailKit.Net.Smtp;

using Microsoft.Win32;

using MimeKit;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Management;
using System.Threading;

namespace ConApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
        }

        private static void SendMailDemo()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("胡睿毅", "807776962@qq.com"));
            message.To.Add(new MailboxAddress("胡一刀", "38761770@qq.com"));
            message.Subject = "How are you ?";

            message.Body = new TextPart("plain")
            {
                Text = @"Hey Chandler,
                        I just wanted to let you know that Monica and I were going to go play some paintball, you in?
                        -- Joey"
            };

            var client = new SmtpClient();
            client.Connect("smtp.qq.com", 587, false);
            client.Authenticate("807776962@qq.com", "rvcwelbqaasfbdeh");
            client.Send(message);
            client.Disconnect(true);
        }

        private static void VmiDemo()
        {
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (var o in moc)
            {
                var mo = (ManagementObject)o;
                PropertyDataCollection collections = mo.Properties;
                foreach (PropertyData data in collections)
                {
                    Console.WriteLine($"{data.Name,40}:" + "\t" + data.Value);
                }
            }
        }

        private static void Expression_Demo1()
        {
            bool func1(int i) => i < 5;
            Console.WriteLine(func1(5));

            Func<int, bool> func2 = i => i < 5;
            Console.WriteLine("deleg(4) = {0}", func2(4));

            Expression<Func<int, bool>> expr = i => i < 5;
            Func<int, bool> func3 = expr.Compile();
            Console.WriteLine("deleg2(4) = {0}", func3(4));
        }

        private static void Expression_Demo2()
        {
            int num = 100;

            Expression constantExpr = Expression.Constant(num);
            Console.WriteLine(constantExpr.ToString());

            Expression conditionExpr = Expression.Condition(
                Expression.Constant(num > 10),
                Expression.Constant("num is greater than 10"),
                Expression.Constant("num is smaller than 10")
            );

            // Print out the expression.
            Console.WriteLine(conditionExpr.ToString());

            Console.WriteLine(Expression.Lambda<Func<string>>(conditionExpr).Compile()());
        }

        private static void Expression_Demo3()
        {
            BlockExpression blockExpr = Expression.Block(
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("Write", new Type[] { typeof(String) }),
                    Expression.Constant("Hello ")
                ),
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                    Expression.Constant("World!")
                ),
                Expression.Constant(100)
            );
            Console.WriteLine("The result of executing the expression tree:");
            var result = Expression.Lambda<Func<int>>(blockExpr).Compile()();

            Console.WriteLine("The expressions from the block expression:");
            foreach (var expression in blockExpr.Expressions)
                Console.WriteLine(expression.ToString());

            Console.WriteLine("The return value of the block expression:");
            Console.WriteLine(result);
        }

        private static void Expression_Demo4()
        {
            string dateStr = "20210706";
            DateTime dateTime = DateTime.ParseExact(dateStr, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
            Article article = new Article { Id = 111, Name = "论道百天" };
            int id = (int)typeof(Article).GetProperty("Id").GetValue(article, null);
            Console.WriteLine(id);

            ParameterExpression target = Expression.Parameter(typeof(Article), "t");
            MemberExpression bodyExp = Expression.Property(target, "Id");

            Expression<Func<Article, int>> selector = Expression.Lambda<Func<Article, int>>(bodyExp, target);
            Console.WriteLine(selector);

            List<Article> list = new List<Article>
            {
                new Article {Id = 1, Name = "A1"},
                new Article {Id = 2, Name = "A2"},
                new Article {Id = 3, Name = "A3"},
                new Article {Id = 4, Name = "A4"},
            };

            Expression<Func<Article, bool>> fbExpression = t => t.Id == 1;
            IEnumerable<Article> enumerable = list.Where(fbExpression.Compile());
        }

        private static void Test07()
        {
            var date = DateTime.Today;
            var order = new Order { Customer = "Tom", Amount = 1000 };

            Expression<Func<Order, bool>> filter
                = x => (x.Customer == order.Customer && x.Amount > order.Amount) || (x.TheDate == date && !x.Discount);
            var visitor = new FilterConstructor();
            var query = visitor.GetQuery(filter);

            Console.WriteLine(query);
        }

        private static void Test06()
        {
            ProcessStartInfo info = new ProcessStartInfo
            {
                FileName = "notepad.exe",
                Arguments = @"C:\Windows\System32\drivers\etc\hosts"
            };
            Process.Start(info);
        }

        private void AddFileContextMenuItem(string itemName, string associatedProgramFullPath)
        {
            //创建项：shell
            RegistryKey shellKey = Registry.ClassesRoot.OpenSubKey(@"*\shell", true) ?? Registry.ClassesRoot.CreateSubKey(@"*\shell");
            if (shellKey == null)
            {
                return;
            }
            //创建项：右键显示的菜单名称
            RegistryKey registryKey = shellKey.CreateSubKey(itemName);
            if (registryKey == null)
            {
                return;
            }
            RegistryKey associatedProgramKey = registryKey.CreateSubKey("command");

            if (associatedProgramKey == null)
            {
                return;
            }
            //创建默认值：关联的程序
            associatedProgramKey.SetValue(string.Empty, associatedProgramFullPath);

            //刷新到磁盘并释放资源
            associatedProgramKey.Close();
            registryKey.Close();
            shellKey.Close();
        }

        private void AddDirectoryContextMenuItem(string itemName, string associatedProgramFullPath)
        {
            //创建项：shell
            RegistryKey shellKey = Registry.ClassesRoot.OpenSubKey(@"directory\shell", true) ?? Registry.ClassesRoot.CreateSubKey(@"*\shell");
            if (shellKey == null)
            {
                return;
            }

            //创建项：右键显示的菜单名称
            RegistryKey registryKey = shellKey.CreateSubKey(itemName);
            if (registryKey == null)
            {
                return;
            }
            RegistryKey associatedProgramKey = registryKey.CreateSubKey("command");
            if (associatedProgramKey == null)
            {
                return;
            }
            //创建默认值：关联的程序
            associatedProgramKey.SetValue("", associatedProgramFullPath);

            //刷新到磁盘并释放资源
            associatedProgramKey.Close();
            registryKey.Close();
            shellKey.Close();
        }

        private static void Test05()
        {
            string date = "20100821";
            DateTime dateTime = DateTime.Parse(date);
            Console.WriteLine(dateTime);

            List<Person> listPerson = new List<Person>();

            List<Person> persons = GetList();

            List<Person> findList = persons.FindAll(m => m.Id == 1).Select(m => new Person
            {
                Id = m.Id
            }).ToList();

            Console.WriteLine(findList.Any() ? "not null" : "nulls");
            if (persons != null)
            {
                List<Person> alls = persons.FindAll(m => m.Id == 2).ToList();
                Console.WriteLine(alls.Count);
            }
            else
            {
                Console.WriteLine("null");
            }
        }

        private static void Test04_MonitorPrintJobWmi()
        {
            var scope = new ManagementScope(ManagementPath.DefaultPath);
            scope.Connect();

            var selectQuery = new SelectQuery { QueryString = @"select *  from Win32_PrintJob" };

            var objSearcher = new ManagementObjectSearcher(scope, selectQuery);
            var objCollection = objSearcher.Get();

            foreach (var job in objCollection)
            {
                PropertyDataCollection collection = job.Properties;
                foreach (PropertyData data in collection)
                {
                    Console.WriteLine(data.Name + "\t\t:" + job[data.Name]);
                }

                Console.WriteLine("***************************************************************************");
            }
        }

        private static void Test03()
        {
            string[] paths = File.ReadAllLines(@"C:\Users\hurui\Downloads\list\changelist");
            foreach (string path in paths)
            {
                string destFile = path.Replace("source code", "source code copy");
                FileInfo fileInfo = new FileInfo(destFile);
                if (!Directory.Exists(fileInfo.DirectoryName))
                {
                    Directory.CreateDirectory(fileInfo.DirectoryName);
                }
                File.Copy(path, path.Replace("source code", "source code copy"), true);
            }
        }

        private static void Test02()
        {
            string[] paths = File.ReadAllLines(@"d:\rs.txt");
            foreach (string path in paths)
            {
                FileInfo fileInfo = new FileInfo(path);
                string destFileName = fileInfo.FullName.Replace("Work", "Work2");
                string directoryName = new FileInfo(destFileName).DirectoryName;
                if (!string.IsNullOrWhiteSpace(directoryName) && !Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
                fileInfo.CopyTo(destFileName, true);
            }

            Console.ReadKey();
        }

        private static void Test01()
        {
            for (int i = 0; i < 10; i++)
            {
                DateTime? dateTime;

                Thread.Sleep(500);
                if (DateTime.Now.Millisecond % 2 == 0)
                {
                    dateTime = DateTime.Now;
                }
                else
                {
                    dateTime = null;
                }
                if (dateTime != null)
                {
                    Console.WriteLine(dateTime);
                }
                else
                {
                    Console.WriteLine("null.....");
                }
            }
        }

        public static List<Person> GetList()
        {
            return new List<Person>
            {
                new Person{Id = 1},
                new Person{Id = 1},
                new Person{Id = 1},
                new Person{Id = 1},
                new Person{Id = 1},
                new Person{Id = 1},
            };
        }
    }
}