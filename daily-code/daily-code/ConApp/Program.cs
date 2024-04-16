using ConApp.Infrastructure;
using ConApp.Model;
using ConApp.Samples;

using Microsoft.VisualBasic;
using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Management;
using System.Net;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ConApp
{
    public class Program
    {
        public static int Number0;

        public static int? Number1;

        public Program(int mNData)
        {
            MnData = mNData;
        }

        public static string encode(string str)
        {
            string htext = "";

            for (int i = 0; i < str.Length; i++)
            {
                htext = htext + (char)(str[i] + 10 - 1 * 2);
            }
            return htext;
        }

        public static string Decode(string str)
        {
            string dtext = "";

            for (int i = 0; i < str.Length; i++)
            {
                dtext = dtext + (char)(str[i] - 10 + 1 * 2);
            }
            return dtext;
        }

        public static void Main(string[] args)
        {
            //https://www.cnblogs.com/dmhp/p/5291129.html
            //https://www.cnblogs.com/dmhp/p/5291106.html
            //stackalloc
            //TypeFilter
            //WeakReference
            //volatile

            Test10_TimeZone();

            ToSimpleChinese(@"D:\Work\CS\00\hello.txt");
            Console.ReadKey();
        }

        [DllImport("msvcrt.dll", SetLastError = false, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern void system(string command);

        public static void Demo_System_Date()
        {
            system("title 纪念日");
            system(" Color 1f");
            for (int year = 2020; year <= 9999; year++)
            {
                Console.WriteLine($"----------------------------------------------------{year}----------------------------------------------------");
                for (int month = 1; month < 13; month++)
                {
                    if (month < DateTime.Now.Month && DateTime.Now.Year == year)
                    {
                        continue;
                    }
                    Console.WriteLine($"*****************************************************{month}******************************************************");

                    var daysInMonth = DateTime.DaysInMonth(year, month);
                    for (int day = 1; day <= daysInMonth; day++)
                    {
                        DateTime dateTime = new DateTime(year, month, day);
                        DayOfWeek dayOfWeek = dateTime.DayOfWeek;
                        int week = 0;

                        switch (dayOfWeek)
                        {
                            case DayOfWeek.Monday: week = 1; break;
                            case DayOfWeek.Tuesday: week = 2; break;
                            case DayOfWeek.Wednesday: week = 3; break;
                            case DayOfWeek.Thursday: week = 4; break;
                            case DayOfWeek.Friday: week = 5; break;
                            case DayOfWeek.Saturday: week = 6; break;
                            case DayOfWeek.Sunday: week = 7; break;
                        }

                        if (day == 1)
                        {
                            for (int i = 0; i < (week - day) * 16; i++)
                            {
                                Console.Write("-");
                            }
                        }

                        Console.ForegroundColor = day == 26 ? ConsoleColor.Red : ConsoleColor.Yellow;
                        Console.Write(week + "-" + year + "-" + month.ToString().PadLeft(2, '0') + "-" + day.ToString().PadLeft(2, '0') + "\t");
                        if (dayOfWeek == DayOfWeek.Sunday)
                        {
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine($"*****************************************************{month}******************************************************");
                    if (month == 12)
                    {
                        Console.WriteLine($"----------------------------------------------------{year}----------------------------------------------------");
                    }
                    Console.ReadKey();
                }
            }
        }

        public static void MemoryDemo()
        {
            int[] a = { 90, 91, 92, 93, 94, 95, 96, 97, 98, 99 };
            Memory<int> memory = new Memory<int>(a);
            Console.WriteLine(memory.Length);

            memory = memory.Slice(6);

            Console.WriteLine(memory.Length);

            Console.ReadKey();
        }

        private static void ToSimpleChinese(String file)
        {
            Encoding encoding = TxtFileEncoder.GetEncoding(file);
            //Encoding.GetEncoding(encoding.BodyName);
            string readAllText = File.ReadAllText(file);
            string strConv = Strings.StrConv(readAllText, VbStrConv.SimplifiedChinese);
            Console.WriteLine(strConv);
        }

        //静态变量存储在堆上，查看指针时需用fixed固定
        public static int MSz = 100;

        //普通数据成员，也是放在堆上了，查看指针时需用fixed固定
        public int MnData;

        //等价于C/C++的 #define 语句，不分配内存
        public const int Pi = 31415;

        private static bool RemoteCertificateCallback(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        /// <summary>
        /// Post数据【参数1：网关地址，2：提交的XML消费交易数据，3：商户号，4商户密码，5：商户证书地址，6：商户证书密码】
        /// </summary>
        public string HttpPost(string sUrl, string sPostData, string sMerId, string sMerPw, string prikeyPath, string prikeyPassword)
        {
            try
            {
                //将输入的xml内容转化为byte数组，
                byte[] data = Encoding.UTF8.GetBytes(sPostData);
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateCallback;
                HttpWebRequest xmlhttprequest = (HttpWebRequest)WebRequest.Create(new Uri(sUrl));
                xmlhttprequest.Method = "POST";
                xmlhttprequest.ContentType = "application/x-www-form-urlencoded";
                xmlhttprequest.ContentLength = data.Length;
                xmlhttprequest.Credentials = CredentialCache.DefaultCredentials;
                string userNamePassword = sMerId + ":" + sMerPw;
                CredentialCache mycache = new CredentialCache
                {
                    { new Uri(sUrl), "Basic", new NetworkCredential(sMerId, sMerPw) }
                };
                xmlhttprequest.Credentials = mycache;
                xmlhttprequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(userNamePassword)));
                X509Certificate2 objX5092 = new X509Certificate2(prikeyPath, prikeyPassword);
                xmlhttprequest.ClientCertificates.Add(objX5092);
                Stream newStream = xmlhttprequest.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                HttpWebResponse res = (HttpWebResponse)xmlhttprequest.GetResponse();
                string rtnRes = String.Empty;

                if (res.GetResponseStream() != null)
                {
                    StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                    //得到返回值
                    rtnRes = reader.ReadToEnd();
                    reader.Close();
                }

                return rtnRes; //返回TR2数据
            }
            catch (Exception ex)
            {
                string sStr = ex.Message;
                return sStr; //返回错误
            }
        }

        public static void WriteMatches(string text, MatchCollection matches)
        {
            Console.WriteLine("Original text was: \n\n" + text + "\n");
            Console.WriteLine("No. of matches: " + matches.Count);
            foreach (Match nextMatch in matches)
            {
                int index = nextMatch.Index;
                string result = nextMatch.ToString();
                int charsBefore = (index < 5) ? index : 5;
                int fromEnd = text.Length - index - result.Length;
                int charsAfter = (fromEnd < 5) ? fromEnd : 5;
                int charsToDisplay = charsBefore + charsAfter + result.Length;

                Console.WriteLine("Index: {0}, \tString: {1}, \t{2}", index, result, text.Substring(index - charsBefore, charsToDisplay));
            }
        }

        public static void CdromManagement()
        {
            WqlEventQuery q;
            ManagementOperationObserver observer = new ManagementOperationObserver();
            observer.Completed += Observer_Completed;
            // Bind to local machine
            ConnectionOptions opt = new ConnectionOptions
            {
                EnablePrivileges = true
            };
            //sets required privilege
            ManagementScope scope = new ManagementScope("root\\CIMV2", opt);
            q = new WqlEventQuery
            {
                EventClassName = "__InstanceModificationEvent",
                WithinInterval = new TimeSpan(0, 0, 1),
                Condition = @"TargetInstance ISA 'Win32_LogicalDisk' and TargetInstance.DriveType = 5"
            };
            // DriveType - 5: CDROM
            var watcher = new ManagementEventWatcher(scope, q);
            // register async. event handler
            watcher.EventArrived += (sender, e) =>
            {
                // Get the Event object and display it
                PropertyData propertyData = e.NewEvent.Properties["TargetInstance"];
                ManagementBaseObject mbo = propertyData.Value as ManagementBaseObject;

                // if CD removed VolumeName == null
                Console.WriteLine(mbo?.Properties["VolumeName"].Value != null ? "CD has been inserted" : "CD has been ejected");
            };
            watcher.Start();
            // Do something usefull,block thread for testing
            Console.ReadLine();
            watcher.Stop();
        }

        private static void Observer_Completed(object sender, CompletedEventArgs e)
        {
            Console.WriteLine("Observer_Completed.................");
        }

        public static void VolatileTest()
        {
            // Create the worker thread object. This does not start the thread.
            Worker workerObject = new Worker();
            Thread workerThread = new Thread(workerObject.DoWork);

            // Start the worker thread.
            workerThread.Start();
            Console.WriteLine("Main thread: starting worker thread...");

            // Loop until the worker thread activates.
            while (!workerThread.IsAlive)
            {
            }

            // Put the main thread to sleep for 1 millisecond to
            // allow the worker thread to do some work.
            Thread.Sleep(1);

            // Request that the worker thread stop itself.
            workerObject.RequestStop();

            // Use the Thread.Join method to block the current thread
            // until the object's thread terminates.
            workerThread.Join();
            Console.WriteLine("Main thread: worker thread has terminated.");
        }

        private static void StrongBoxInt(StrongBox<int> sint)
        {
            sint.Value = 456789;
        }

        private static void StrongBoxDemo()
        {
            StrongBox<int> sint = new StrongBox<int>(123465);
            Console.WriteLine(sint.Value);
            StrongBoxInt(sint);
            Console.WriteLine(sint.Value);
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

        public static void Test10_TimeZone()
        {
            ReadOnlyCollection<TimeZoneInfo> tzCollections = TimeZoneInfo.GetSystemTimeZones();

            foreach (TimeZoneInfo item in tzCollections)
            {
                Console.WriteLine(item.DisplayName + "  " + item.DaylightName);
            }
        }

        public static void Test09()
        {
            int? ni = new int?(12);
            ni = 123456;
            Console.WriteLine(ni);
            ni = null;
            Console.WriteLine(ni);

            Console.WriteLine(Number0);
            Console.WriteLine(Number1 == null ? 123 : 456);
        }

        private static bool FindText(string str)
        {
            return string.CompareOrdinal(str, "7") >= 0;
        }

        public static void Test08()
        {
            List<string> list = new List<string>
            {
                "3","4","7","9","11"
            };
            var lists1 = list.MyFindAll<string>(FindText);
            lists1.ForEach((item) =>
            {
                Console.WriteLine(item);
            });

            var lists2 = list.MyFindAll(str =>
            {
                return string.CompareOrdinal(str, "7") >= 0;
            });
            lists2.ForEach((item) =>
            {
                Console.WriteLine(item);
            });
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