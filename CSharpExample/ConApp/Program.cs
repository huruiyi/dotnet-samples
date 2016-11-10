using ConApp.Class;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace ConApp
{
    public class A
    {
        public string P1 { get; set; }
        public int P2 { get; set; }

        public void M1()
        {
            Console.WriteLine("MI1....");
        }

        public string M2()
        {
            return string.Format("{0}:{1}", this.P1, this.P2);
        }

        public static void M2(string s)
        {
            Console.WriteLine(s);
        }

        protected string M2(string s, string s1)
        {
            return s + s1;
        }
    }

    internal class Program
    {
        public static unsafe void Main(string[] args)
        {
            HashtableTest();
            Console.ReadKey();
        }

        #region 01-foreach原理

        public static void Cus_foreach()
        {
            MyCollection myCol = new MyCollection();
            foreach (var a in myCol)
            {
                Console.WriteLine(a);
            }
            MyCollection2 myCol2 = new MyCollection2();
            foreach (var m in myCol2)
            {
                Console.WriteLine(m);
            }
        }

        #endregion 01-foreach原理

        #region 02-EnumDemo

        /*
         “X”或“x” 以十六进制格式表示 value（不带前导“0x”）。
         “D”或“d” 以十进制形式表示 value。
         “F”或“f” 对于“G”或“g”执行的行为是相同的，只是在 Enum 声明中不需要 FlagsAttribute。

         “G”或“g”
         如果 value 等于某个已命名的枚举常数，则返回该常数的名称；否则返回 value 的等效十进制数。
         例如，假定唯一的枚举常数命名为 Red，其值为 1。如果将 value 指定为 1，则此格式返回“Red”。然而，如果将 value 指定为 2，则此格式返回“2”。
         - 或 -
         如果将 FlagsAttribute 自定义特性应用于枚举，则 value 将被视为位域，该位域包含一个或多个由一位或多位组成的标志。
         如果 value i等于命名枚举常数的组合，则将返回这些常量名的分隔符分隔列表。将在 value 中搜索标志，从具有最大值的标志到具有最小值的标志进行搜索。
         对于与 value 中的位域相对应的每个标志，常数的名称连接到用分隔符分隔的列表。则将不再考虑该标记的值，而继续搜索下一个标志。
         如果 value 不等于已命名的枚举常数的组合，则返回 value 的等效十进制数。
     */

        public static void EnumDemo01()
        {
            Console.WriteLine($"Season.夏={Season.夏}");
            Console.WriteLine($"(int)Season.夏={(int)Season.夏}");

            int b = (int)Season.春;
            Console.WriteLine(b);
            Console.WriteLine((Season)b);

            Season s = (Season)100;
            int e = (int)s;
            Console.WriteLine(s);
            Console.WriteLine(e);
        }

        public static void EnumDemo02_Parse()
        {
            string a = "夏";
            try
            {
                Season season = (Season)(Enum.Parse(typeof(Season), a));
                Console.WriteLine("season=" + season);
            }
            catch
            {
                Console.WriteLine("无此枚举");
            }
        }

        public static void EnumDemo3_Format()
        {
            Season s = Season.冬;
            Console.WriteLine($"d={Enum.Format(typeof(Season), s, "d")} x={Enum.Format(typeof(Season), s, "x")} g={Enum.Format(typeof(Season), s, "g")} f={Enum.Format(typeof(Season), s, "f")}");
            Season se = Season.夏 | Season.秋 | Season.冬;
            Console.WriteLine(se);

            Console.WriteLine(Enum.GetName(typeof(Season), 4));
        }

        public static void EnumDemo04_GetNames()
        {
            Type season = typeof(Season);
            foreach (string s in Enum.GetNames(season))
            {
                Console.WriteLine("{0,-11}= {1}", s, Enum.Format(season, Enum.Parse(season, s), "d"));
            }
        }

        public static void EnumDemo05_GetValues()
        {
            Type season = typeof(Season);
            foreach (int i in Enum.GetValues(season))
            {
                Console.WriteLine(i);
            }
        }

        #endregion 02-EnumDemo

        #region 03-EventDemo

        public static void EventDemo()
        {
            ExampleMethod(p2: "");
            Console.WriteLine("\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

            ExampleMethod(WriteLetter("A"), b: WriteLetter("B"), c: WriteLetter("C"));
            ExampleMethod(WriteLetter("A"), c: WriteLetter("C"), b: WriteLetter("B"));
            Console.WriteLine("\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

            var methods = new List<Action>();
            foreach (var word in new string[] { "hello", "world" })
            {
                methods.Add(() => Console.Write(word + " "));
            }

            methods[0]();
            methods[1]();
            Console.WriteLine("\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

            var lines = new List<IEnumerable<string>>();
            int[] numbers = { 1, 2, 3 };
            char[] letters = { 'a', 'b', 'c' };

            foreach (var number in numbers)
            {
                var line = from letter in letters
                           select number.ToString() + letter;

                lines.Add(line);
            }

            foreach (var line in lines)
            {
                foreach (var entry in line)
                    Console.Write(entry + " ");
                Console.WriteLine();
            }
            Console.WriteLine("\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

            Publisher publisher = new Publisher();

            publisher.SampleEvent += publisher_SampleEvent;
        }

        private static int WriteLetter(string letter)
        {
            Console.Write(letter + " ");
            return 1;
        }

        private static void ExampleMethod(int a, int b, int c)
        {
        }

        public static void ExampleMethod(string p1 = null, object p2 = null)
        {
            Console.WriteLine("ExampleMethod: p2 is object");
        }

        public static void ExampleMethod(string p2 = null, object p1 = null, params int[] p3)
        {
            Console.WriteLine("ExampleMethod: p2 is string");
        }

        private static void publisher_SampleEvent(object sender, SampleEventArgs e)
        {
            Console.WriteLine("e.Text:" + e.Text);
        }

        #endregion 03-EventDemo

        #region 04-PerformanceCounter

        public static void Demo04()
        {
            var counters = new List<PerformanceCounter>();
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                var counter = new PerformanceCounter("Process", "% Processor Time", process.ProcessName);
                counter.NextValue();
                counters.Add(counter);
            }

            int i = 0;

            Thread.Sleep(1000);

            foreach (var counter in counters)
            {
                Console.WriteLine(processes[i].ProcessName + " | CPU% " + (Math.Round(counter.NextValue(), 1)));
                ++i;
            }
        }

        #endregion 04-PerformanceCounter

        #region 05-GetHostEntryDemo

        public static void GetHostEntryDemo()
        {
            string[] args = { };
            if (args.Length == 0 || args[0].Length == 0)
            {
                Console.WriteLine("You must specify the name of a host computer.");
                return;
            }
            IAsyncResult result = Dns.BeginGetHostEntry(args[0], null, null);
            Console.WriteLine("Processing request for information...");

            while (result.IsCompleted != true)
            {
                Extension.UpdateUserInterface();
            }

            Console.WriteLine();
            try
            {
                IPHostEntry host = Dns.EndGetHostEntry(result);
                string[] aliases = host.Aliases;
                IPAddress[] addresses = host.AddressList;
                if (aliases.Length > 0)
                {
                    Console.WriteLine("Aliases");
                    for (int i = 0; i < aliases.Length; i++)
                    {
                        Console.WriteLine("{0}", aliases[i]);
                    }
                }
                if (addresses.Length > 0)
                {
                    Console.WriteLine("Addresses");
                    for (int i = 0; i < addresses.Length; i++)
                    {
                        Console.WriteLine("{0}", addresses[i].ToString());
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("An exception occurred while processing the request: {0}", e.Message);
            }
        }

        #endregion 05-GetHostEntryDemo

        #region 06-ProcessDemo

        public static void ProcessDemo()
        {
            Process myProcess = new Process();
            try
            {
                string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                myProcess.StartInfo.FileName = myDocumentsPath + "\\MyFile.docx";
                myProcess.StartInfo.Verb = "Print";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
            }
            catch (Win32Exception e)
            {
                if (e.NativeErrorCode == 2)//ErrorFileNotFound
                {
                    Console.WriteLine(e.Message + ". Check the path.");
                }
                else if (e.NativeErrorCode == 5)//ErrorAccessDenied
                {
                    Console.WriteLine(e.Message + ". You do not have permission to print this file.");
                }
            }
        }

        #endregion 06-ProcessDemo

        #region 07-AsyncWaitHandle

        public static void AsyncWaitHandleDemo()
        {
            string[] args = { };
            if (args.Length == 0 || args[0].Length == 0)
            {
                Console.WriteLine("You must specify the name of a host computer.");
                return;
            }
            IAsyncResult result = Dns.BeginGetHostEntry(args[0], null, null);
            Console.WriteLine("Processing request for information...");
            result.AsyncWaitHandle.WaitOne();
            try
            {
                IPHostEntry host = Dns.EndGetHostEntry(result);
                string[] aliases = host.Aliases;
                IPAddress[] addresses = host.AddressList;
                if (aliases.Length > 0)
                {
                    Console.WriteLine("Aliases");
                    foreach (string t in aliases)
                    {
                        Console.WriteLine("{0}", t);
                    }
                }
                if (addresses.Length > 0)
                {
                    Console.WriteLine("Addresses");
                    foreach (IPAddress t in addresses)
                    {
                        Console.WriteLine("{0}", t.ToString());
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("Exception occurred while processing the request: {0}", e.Message);
            }
        }

        #endregion 07-AsyncWaitHandle

        #region 08-AsyncOperationDemo

        public static void AsyncOperationDemo()
        {
            string[] args = { };

            if (args.Length == 0 || args[0].Length == 0)
            {
                Console.WriteLine("You must specify the name of a host computer.");
                return;
            }
            IAsyncResult result = Dns.BeginGetHostEntry(args[0], null, null);
            Console.WriteLine("Processing your request for information...");
            try
            {
                IPHostEntry host = Dns.EndGetHostEntry(result);
                string[] aliases = host.Aliases;
                IPAddress[] addresses = host.AddressList;
                if (aliases.Length > 0)
                {
                    Console.WriteLine("Aliases");
                    foreach (string t in aliases)
                    {
                        Console.WriteLine("{0}", t);
                    }
                }
                if (addresses.Length > 0)
                {
                    Console.WriteLine("Addresses");
                    foreach (IPAddress t in addresses)
                    {
                        Console.WriteLine("{0}", t.ToString());
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("An exception occurred while processing the request: {0}", e.Message);
            }
        }

        #endregion 08-AsyncOperationDemo

        #region 09-AsyncResultDemo

        public static void AsyncResultDemo()
        {
            Func<bool> asncRun = Extension.AutoUpdate;
            asncRun.BeginInvoke(Extension.AutoUpdateSupplierMcScoreAsyncCallback, asncRun);
        }

        #endregion 09-AsyncResultDemo

        #region 10-自定义扩展方法

        public static void CusMethod()
        {
            #region 扩展方法

            //在list上添加一个方法，传一个委托到一个方法，满足当前委托条件的变量都给取出来
            List<string> list = new List<string>()
            {
                "1",
                "2",
                "3",
                "4"
            };
            //自己内部模拟的写法
            var temp1 = list.MyFindStrs(Extension.MyCalc);
            foreach (var item in temp1)
            {
                Console.WriteLine(item);
            }

            //普通写法
            var temp2 = list.FindAll(Extension.MyCalc);

            foreach (var item in temp2)
            {
                Console.WriteLine(item);
            }

            var temp3 = list.FindAll(a => int.Parse(a) >= 2);

            foreach (var item in temp3)
            {
                //Console.WriteLine(item);
            }

            #endregion 扩展方法
        }

        #endregion 10-自定义扩展方法

        #region 11-ExcuteXCopyCmd

        public static void ExcuteXCopyCmdDemo()
        {
            string sCmd = @"copy D:\a.txt D:\b.txt";
            Process proIP = new Process();
            proIP.StartInfo.FileName = "cmd.exe";
            proIP.StartInfo.UseShellExecute = false;
            proIP.StartInfo.RedirectStandardInput = true;
            proIP.StartInfo.RedirectStandardOutput = true;
            proIP.StartInfo.RedirectStandardError = true;
            proIP.StartInfo.CreateNoWindow = true;
            proIP.Start();
            proIP.StandardInput.WriteLine(sCmd);
            proIP.StandardInput.WriteLine("exit");
            string strResult = proIP.StandardOutput.ReadToEnd();
            proIP.Close();

            Console.WriteLine(strResult);
        }

        #endregion 11-ExcuteXCopyCmd

        #region 12-属性相关

        public static void PropertyInfoTest()
        {
            Dictionary<int, string> attrs = new Dictionary<int, string> { { 1, "1" } };
            Person person = new Person
            {
                Name = "huruiyi",
                Salary = 12345,
                Sex = 'N',
                Equips = new List<Equip>
                {
                    new Equip {Name = "N1", AttackValue = 123},
                    new Equip {Name = "N2", AttackValue = 123},
                    new Equip {Name = "N3", AttackValue = 123},
                },
                Hobbys = new string[] { "h1", "h2", "h3", "h4" },
                Attributes = attrs
            };
            Console.WriteLine(typeof(List<>).Name);
            PropertyInfo[] propertyInfos = typeof(Person).GetProperties();
            foreach (PropertyInfo p in propertyInfos)
            {
                string pName = p.Name;
                string name = p.PropertyType.Name;
                Type t = p.PropertyType.GetType();
                bool pg = p.PropertyType.IsGenericType;
                var a = p.GetValue(person, null);
                if (p.PropertyType.Name == "String")
                {
                    p.SetValue(person, "Name", null);
                }
                if (p.PropertyType.Name == "Double")
                {
                    p.SetValue(person, 123.1345, null);
                }
                if (p.PropertyType.Name == "Char")
                {
                    p.SetValue(person, '男', null);
                }

                //if (p.PropertyType.IsGenericType)
                //{
                //    p.SetValue(person, new List<Equip>{
                //    new Equip {Name = "N1111", AttackValue = 123},
                //    new Equip {Name = "N2222", AttackValue = 123},
                //    new Equip {Name = "N3333", AttackValue = 123},
                //});
                //}
            }
        }

        #endregion 12-属性相关

        #region 13-EnumTest

        public static void EnumTest()
        {
            string idField = ((MemberExpression)((Expression<Func<City, int>>)(c => c.CityId)).Body).Member.Name;
            string textField = ((MemberExpression)((Expression<Func<City, string>>)(c => c.CityName)).Body).Member.Name;

            for (int i = 0; i < 5; i++)
            {
                var enumName = Enum.GetName(typeof(SocialTypeEnum), i);
                Console.WriteLine("{0}:{1}", i, enumName);
            }
            SocialTypeEnum result;
            bool result1 = Enum.TryParse("1", out result);
            bool result2 = Enum.TryParse<SocialTypeEnum>("2", out result);
            //string result3 = Enum.Format(typeof(SocialTypeEnum), "3", "X");

            string result4 = Enum.GetName(typeof(SocialTypeEnum), 2);
            string[] result5 = Enum.GetNames(typeof(SocialTypeEnum));
            Type result6 = Enum.GetUnderlyingType(typeof(SocialTypeEnum));
            Array array = Enum.GetValues(typeof(SocialTypeEnum));
            Console.WriteLine("数字{0}对应的枚举Name值:{1}", 3, Enum.GetName(typeof(SocialTypeEnum), 3));

            Type ste = typeof(SocialTypeEnum);
            object[] result7 = ste.GetField(SocialTypeEnum.Facebook.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
        }

        #endregion 13-EnumTest

        #region 14-HashtableTest

        public static void HashtableTest()
        {
            Hashtable hashtable1 = new Hashtable();
            hashtable1.Add("zd", "600719");
            hashtable1.Add("name", "denylau");
            hashtable1.Add("sex", "男");
            Console.WriteLine("hashtable长度为：" + hashtable1.Count);

            ArrayList akeys = new ArrayList(hashtable1.Keys);
            akeys.Sort();
            foreach (string skey in akeys)
            {
                Console.Write(skey + ":");
                Console.WriteLine(hashtable1[skey]);
            }

            // 默认输出是无序的
            foreach (DictionaryEntry item in hashtable1)
            {
                Console.WriteLine("{0}:\t{1}", item.Key, item.Value);
            }

            IDictionaryEnumerator en = hashtable1.GetEnumerator();
            while (en.MoveNext())
            {
                string str = en.Value.ToString();
                Console.WriteLine(str);
            }

            foreach (var item in hashtable1.Keys)
            {
                Console.WriteLine(item);
            }

            foreach (var item in hashtable1.Values)
            {
                Console.WriteLine(item);
            }

            //hashtable1 .Clear();

            Console.WriteLine(hashtable1.Contains("zd"));
            Console.WriteLine($"{ hashtable1["zd"] }");

            //hashtable1.Remove("zd");

            Console.WriteLine("**********************************************************");
            Hashtable hashtableItem = new Hashtable();
            hashtableItem.Add("Name", "小红");
            hashtableItem.Add("Sex", "女");
            hashtableItem.Add("Age", 20);

            Hashtable hashtableItem1 = new Hashtable();
            hashtableItem1.Add("Name", "小王");
            hashtableItem1.Add("Sex", "男");
            hashtableItem1.Add("Age", 21);

            Hashtable hashtableItem2 = new Hashtable();
            hashtableItem2.Add("Name", "小李");
            hashtableItem2.Add("Sex", "男");
            hashtableItem2.Add("Age", 22);

            ArrayList list = new ArrayList(hashtableItem.Keys);
            list.Add(hashtableItem);
            list.Add(hashtableItem1);
            list.Add(hashtableItem2);

            Tom a = new Tom("小王", 20, '男', "篮球", 12345);
            Tom b = new Tom("小李", 21, '女', "排球", 22345);
            Tom c = new Tom("小胡", 22, '男', "足球", 32345);
            ArrayList array = new ArrayList();
            array.Add(a);
            array.Add(b);
            array.Add(c);
            foreach (Tom item in array)
            {
                Tom tom = (Tom)item;
                Console.WriteLine(tom.Name + " " + tom.Age + " " + tom.Sex);
            }
        }

        #endregion 14-HashtableTest

        #region 20-WeakReferenceDemo

        public static void WeakRefenceDemo()
        {
            WeakReference mathReference = new WeakReference(new MathTest());
            MathTest math;
            if (mathReference.IsAlive)
            {
                math = mathReference.Target as MathTest;
                math.Value = 30;
                Console.WriteLine("Value field of math variable contains " + math.Value);
                Console.WriteLine("Square of 30 is " + math.GetSquare());
            }
            else
            {
                Console.WriteLine("Reference is not available.");
            }

            GC.Collect();

            if (mathReference.IsAlive)
            {
                math = mathReference.Target as MathTest;
            }
            else
            {
                Console.WriteLine("Reference is not available.");
            }
        }

        #endregion 20-WeakReferenceDemo

        #region 21-不安全代码

        public unsafe static void ArrPrintDemo()
        {
            const int al = 10;
            byte[] ints = new byte[al];
            //for (int i = 0; i < 50000; i++)
            //{
            //    new object();
            //}

            fixed (byte* ip = ints)
            {
                for (int i = 0; i < al; i++)
                {
                    Console.WriteLine(Guid.NewGuid().GetHashCode());
                    ip[i] = (byte)new Random().Next(0, 256);
                }
            }

            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            Array.ForEach(ints, b => Console.WriteLine(b));
        }

        public static unsafe void SquarePtrParamDemo(int i)
        {
            SquareIntPointer(&i);
            Console.WriteLine(i);
        }

        public static void SafeSwapDemo()
        {
            int i = 10, j = 20;
            SafeSwap(ref i, ref j);
            Console.WriteLine("Values after safe swap: i = {0}, j = {1}", i, j);

            unsafe
            {
                UnsafeSwap(&i, &j);
            }
            Console.WriteLine("Values after safe swap: i = {0}, j = {1}", i, j);
        }

        /// <summary>
        /// 求平方
        /// </summary>
        /// <param name="p"></param>
        private static unsafe void SquareIntPointer(int* p)
        {
            *p *= *p;
        }

        /// <summary>
        /// 交换两个数
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public static void SafeSwap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }

        /// <summary>
        /// 交换两个数
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public static unsafe void UnsafeSwap(int* i, int* j)
        {
            int temp = *i;
            *i = *j;
            *j = temp;
        }

        public static unsafe void UnsafeAddDemo1()
        {
            int[] a = new int[2];
            a[0] = 1;
            a[1] = 2;
            int b = 3;
            int res = UnsafeAdd1(a, b);
            Console.WriteLine(res);

            unsafe
            {
                int num = 5;
                int* intp = &num;

                int result = UnsafeAdd2(num, intp);
                Console.WriteLine(result);
            }
        }

        public static int UnsafeAdd1(int[] a, int b)
        {
            unsafe
            {
                fixed (int* pa = a)//此处将锁住a，使得在fixed操作块内，a不会被CLR移动
                {
                    return *pa + b;
                }
            }
        }

        public unsafe static int UnsafeAdd2(int a, int* b)//此处使用 指针，需要加入非安全代码关键字unsafe
        {
            return a + *b;
        }

        public static unsafe void UsePointerToPoint()
        {
            Point point;
            Point* p = &point;
            p->x = 100;
            p->y = 200;
            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx:::" + p->ToString());

            Point point2;
            Point* p2 = &point2;
            (*p2).x = 100;
            (*p2).y = 200;
            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx:::" + (*p2).ToString());
        }

        public static unsafe void UnsafeStackAlloc()
        {
            char* p = stackalloc char[256];
            for (int k = 0; k < 256; k++)
            {
                p[k] = (char)k;
            }
        }

        public static unsafe void PrintValueAndAddress()
        {
            int myInt;

            int* ptrToMyInt = &myInt;

            *ptrToMyInt = 123;

            Console.WriteLine("Vsalue of myInt {0}", myInt);
            Console.WriteLine("Address of myInt {0:X}", (int)&ptrToMyInt);
        }

        public static unsafe void UseAndPinPoint()
        {
            PointRef pt = new PointRef();
            pt.x = 5;
            pt.y = 6;

            // pin pt in place so it will not be moved or GC-ed.
            fixed (int* p = &pt.x)
            {
                // Use int* variable here!
            }

            // pt is now unpinned, and ready to be GC-ed once the method completes.
            Console.WriteLine("Point is: {0}", pt);
        }

        private static unsafe void UseSizeOfOperator()
        {
            Console.WriteLine("The size of short is {0}.", sizeof(short));
            Console.WriteLine("The size of int is {0}.", sizeof(int));
            Console.WriteLine("The size of long is {0}.", sizeof(long));
            Console.WriteLine("The size of Point is {0}.", sizeof(Point));
        }

        /*
          由于涉及指针类型，因此 stackalloc 要求不安全上下文。 有关更多信息，请参见 不安全代码和指针（C# 编程指南）。
          stackalloc 类似于 C 运行库中的 _alloca。
          以下代码示例计算并演示 Fibonacci 序列中的前 20 个数字。 每个数字是先前两个数字的和。
          在代码中，大小足够容纳 20 个 int 类型元素的内存块是在堆栈上分配的，而不是在堆上分配的。
          该块的地址存储在 fib 指针中。 此内存不受垃圾回收的制约，因此不必将其钉住（通过使用 fixed）。
          内存块的生存期受限于定义它的方法的生存期。 不能在方法返回之前释放内存。
      */

        public static unsafe void Demo28()
        {
            const int arraySize = 20;
            int* fib = stackalloc int[arraySize];
            int* p = fib;
            // The sequence begins with 1, 1.
            *p++ = *p++ = 1;
            for (int i = 2; i < arraySize; ++i, ++p)
            {
                // Sum the previous two numbers.
                *p = p[-1] + p[-2];
            }
            for (int i = 0; i < arraySize; ++i)
            {
                Console.WriteLine(fib[i]);
            }
        }

        #endregion 21-不安全代码

        #region 22-TaskDemo

        public static void TasKdemo()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            token.Register(delegate { Console.WriteLine("cancel........."); });
            Random rnd = new Random();
            Object lockObj = new Object();

            List<Task<int[]>> tasks = new List<Task<int[]>>();
            TaskFactory factory = new TaskFactory(token);
            for (int taskCtr = 0; taskCtr <= 10; taskCtr++)
            {
                int iteration = taskCtr + 1;
                tasks.Add(factory.StartNew(() =>
                {
                    int value;
                    int[] values = new int[10];
                    for (int ctr = 1; ctr <= 10; ctr++)
                    {
                        lock (lockObj)
                        {
                            value = rnd.Next(0, 101);
                        }
                        if (value == 0)
                        {
                            source.Cancel();
                            Console.WriteLine("Cancelling at task {0}", iteration);
                            break;
                        }
                        values[ctr - 1] = value;
                    }
                    return values;
                }, token));
            }
            try
            {
                Task<double> fTask = factory.ContinueWhenAll(tasks.ToArray(),
                                                             (results) =>
                                                             {
                                                                 Console.WriteLine("Calculating overall mean...");
                                                                 long sum = 0;
                                                                 int n = 0;
                                                                 foreach (var t in results)
                                                                 {
                                                                     foreach (var r in t.Result)
                                                                     {
                                                                         sum += r;
                                                                         n++;
                                                                     }
                                                                 }
                                                                 return sum / (double)n;
                                                             }, token);
                Console.WriteLine("The mean is {0}.", fTask.Result);
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                    {
                        Console.WriteLine("Unable to compute mean: {0}", ((TaskCanceledException)e).Message);
                    }
                    else
                    {
                        Console.WriteLine("Exception: " + e.GetType().Name);
                    }
                }
            }
            finally
            {
                source.Dispose();
            }
        }

        #endregion 22-TaskDemo

        #region 23-SpinWaitDemo

        public static void SpinWaitDemo()
        {
            // Demonstrates:
            //      SpinWait construction
            //      SpinWait.SpinOnce()
            //      SpinWait.NextSpinWillYield
            //      SpinWait.Count
            bool someBoolean = false;
            int numYields = 0;

            // First task: SpinWait until someBoolean is set to true
            Task t1 = Task.Factory.StartNew(() =>
            {
                SpinWait sw = new SpinWait();
                while (!someBoolean)
                {
                    // The NextSpinWillYield property returns true if
                    // calling sw.SpinOnce() will result in yielding the
                    // processor instead of simply spinning.
                    if (sw.NextSpinWillYield) numYields++;
                    sw.SpinOnce();
                }

                // As of .NET Framework 4: After some initial spinning, SpinWait.SpinOnce() will yield every time.
                Console.WriteLine("SpinWait called {0} times, yielded {1} times", sw.Count, numYields);
            });

            // Second task: Wait 100ms, then set someBoolean to true
            Task t2 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(100);
                someBoolean = true;
            });

            // Wait for tasks to complete
            Task.WaitAll(t1, t2);
        }

        #endregion 23-SpinWaitDemo

        #region 24进制转换_Bin_Oct_Dec_Hex

        public static void Bin_Oct_Dec_Hex()
        {
            Console.WriteLine(UriPartial.Authority);
            Console.WriteLine(UriPartial.Path);
            Console.WriteLine(UriPartial.Query);
            Console.WriteLine(UriPartial.Scheme);
            Console.WriteLine(sizeof(char));
            Console.WriteLine(sizeof(byte));
            Console.WriteLine(sizeof(Byte));

            Console.WriteLine(sizeof(sbyte));
            Console.WriteLine(sizeof(SByte));

            Console.WriteLine(sizeof(short));
            Console.WriteLine(sizeof(ushort));

            Console.WriteLine(sizeof(int));
            Console.WriteLine(sizeof(uint));

            Console.WriteLine(sizeof(Int16));
            Console.WriteLine(sizeof(UInt16));

            Console.WriteLine(sizeof(Int32));
            Console.WriteLine(sizeof(UInt32));

            Console.WriteLine(sizeof(Int64));
            Console.WriteLine(sizeof(UInt64));

            Console.WriteLine(sizeof(decimal));
            Console.WriteLine(sizeof(Decimal));
            Console.WriteLine(sizeof(float));

            Console.WriteLine(sizeof(long));
            Console.WriteLine(sizeof(ulong));
            Console.WriteLine(sizeof(Single));

            Console.WriteLine(sizeof(UriPartial));

            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine($"{i.ToString()} {i.ToString("x")} {i.ToString("x2")} {Convert.ToString(i, 2)} {Convert.ToString(i, 8)} {Convert.ToString(i, 16)}");
            }
        }

        #endregion 24进制转换_Bin_Oct_Dec_Hex

        #region 25-XMLDemo

        public static void XMLDemo()
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

        #endregion 25-XMLDemo

        #region 26-WebRequestDemo

        public static void WebRequestDemo()
        {
            WebRequest request = WebRequest.Create("http://www.baidu.com");
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();

            Console.WriteLine("响应信息，内容长度：{0}，类型:{1},Uri:{2}", response.ContentLength, response.ContentType, response.ResponseUri);
            using (StreamReader sr = new StreamReader(stream))
            {
                Console.Write(sr.ReadToEnd());
            }
        }

        #endregion 26-WebRequestDemo

        #region 27-DirectorySecurity

        public static void DirectorySecurityDemo()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());

            //IPHostEntry ent0 = Dns.GetHostByAddress("10.101.42.77");
            IPHostEntry ent1 = Dns.GetHostEntry(hostEntry.HostName);
            IPHostEntry name = Dns.GetHostEntry("hry6464");
            string hostName = Dns.GetHostName();
            Console.Write("Provide full directory path: ");
            string mentionedDir = @"D:\";
            try
            {
                DirectoryInfo myDir = new DirectoryInfo(mentionedDir);

                if (myDir.Exists)
                {
                    DirectorySecurity myDirSec = myDir.GetAccessControl();

                    foreach (FileSystemAccessRule fileRule in myDirSec.GetAccessRules(true, true, typeof(NTAccount)))
                    {
                        Console.WriteLine("{0} {1} {2} access for {3}", mentionedDir, fileRule.AccessControlType == AccessControlType.Allow ? "provides" : "denies", fileRule.FileSystemRights, fileRule.IdentityReference);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Incorrect directory provided!");
            }
        }

        #endregion 27-DirectorySecurity

        #region 28-字符串按指定长度分割

        public static void Demo31()
        {
            List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // intList.Find(m => m > 5)

            string longStr = @"标准通用标记语言下的一个应用HTML标准自1999年12月发布的HTML4.01后，后继的HTML5和其它标准被束之高阁，为了推动Web标准化运动的发展，一些公司联合起来，成立了一个叫做 Web Hypertext Application Technology Working Group （Web超文本应用技术工作组 -WHATWG） 的组织。WHATWG 致力于 Web 表单和应用程序，而W3C（World Wide Web Consortium，万维网联盟） 专注于XHTML2.0。在 2006 年，双方决定进行合作，来创建一个新版本的 HTML。";

            int count = (int)Math.Ceiling(longStr.Length / 100.0);
            string[] logStr = new string[count];

            for (int i = 0; i < count; i++)
            {
                if (i + 1 == count)
                {
                    logStr[i] = longStr.Substring(100 * i);
                }
                else
                {
                    logStr[i] = longStr.Substring(100 * i, 100);
                }
            }

            Console.WriteLine("原始");
            Console.WriteLine(longStr);
            Console.WriteLine("+++++++++++++++++++++++++++++++");
            foreach (string item in logStr)
            {
                Console.Write(item);
            }
        }

        #endregion 28-字符串按指定长度分割

        #region 29-AppDomain_AttachDb

        public static void Demo32()
        {
            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            if (dataDir.EndsWith(@"\bin\Debug\") || dataDir.EndsWith(@"\bin\Release\"))
            {
                dataDir = Directory.GetParent(dataDir).Parent.Parent.FullName;
                AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);
            }
            Console.WriteLine("请输入用户名：");
            string username = Console.ReadLine();
            Console.WriteLine("请输入密码：");
            string password = Console.ReadLine();
            // admin 123456
            //  string ConStr = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\T_Test.mdf;Integrated Security=True;User Instance=True";
            string ConStr = @"Data Source=.;AttachDbFilename=|DataDirectory|\T_Test.mdf;uid=sa;pwd=sa";
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = string.Format("select * from T_Test Where UserName='{0}'", username);
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        if (read.Read())
                        {
                            string dbpassword = read.GetString(read.GetOrdinal("Password"));
                            if (password == dbpassword)
                            {
                                Console.WriteLine("登陆成功");
                            }
                            else
                            {
                                Console.WriteLine("密码错误，登录失败");
                            }
                        }
                        else
                        {
                            Console.WriteLine("无此用户名！");
                        }
                    }
                }
            }
        }

        #endregion 29-AppDomain_AttachDb

        #region 30-反射获取方法名

        public static void GetMethodsDemo()
        {
            A a = new A();
            Console.WriteLine(a.M2());

            Type t = Type.GetType("ConApp.A");
            Assembly ass = t.Assembly;
            object obj = ass.CreateInstance("ConApp.A");

            // MemberFilter

            MethodInfo m1 = t.GetMethod("M1");
            m1.Invoke(obj, null);

            MethodInfo[] m231 = t.GetMethods(BindingFlags.CreateInstance);
            MethodInfo[] m232 = t.GetMethods(BindingFlags.DeclaredOnly);
            MethodInfo[] m233 = t.GetMethods(BindingFlags.Default);
            MethodInfo[] m234 = t.GetMethods(BindingFlags.ExactBinding);
            MethodInfo[] m253 = t.GetMethods(BindingFlags.FlattenHierarchy);
            MethodInfo[] m236 = t.GetMethods(BindingFlags.GetField);
            MethodInfo[] m2354 = t.GetMethods(BindingFlags.GetProperty);
            MethodInfo[] m23t = t.GetMethods(BindingFlags.IgnoreCase);
            MethodInfo[] m23y = t.GetMethods(BindingFlags.IgnoreReturn);
            MethodInfo[] m23hg = t.GetMethods(BindingFlags.Instance);
            MethodInfo[] mg23 = t.GetMethods(BindingFlags.InvokeMethod);
            MethodInfo[] m2h3 = t.GetMethods(BindingFlags.NonPublic);
            MethodInfo[] m2j3 = t.GetMethods(BindingFlags.OptionalParamBinding);
            MethodInfo[] m23j = t.GetMethods(BindingFlags.Public);
            MethodInfo[] m23 = t.GetMethods(BindingFlags.PutDispProperty);
            MethodInfo[] mh23 = t.GetMethods(BindingFlags.PutRefDispProperty);
            MethodInfo[] m2f3 = t.GetMethods(BindingFlags.SetField);
            MethodInfo[] m2gh3 = t.GetMethods(BindingFlags.SetProperty);
            MethodInfo[] mk23 = t.GetMethods(BindingFlags.Static);
            MethodInfo[] mgh23 = t.GetMethods(BindingFlags.SuppressChangeType);
            MethodInfo[] mgh23f = t.GetMethods();

            MethodInfo[] mgh23x = t.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public);

            foreach (MethodInfo item in mgh23x)
            {
                Console.WriteLine(item.IsVirtual + "  " + item.Name);
            }
            Console.WriteLine(ass.FullName); ;
        }

        #endregion 30-反射获取方法名

        #region 反射系列

        public static void ReflectionClass1Demo()
        {
            #region Demo1 GetConstructors()

            ConstructorInfo[] p = typeof(ReflectionClass1).GetConstructors();
            Console.WriteLine(p.Length);

            for (int i = 0; i < p.Length; i++)
            {
                Console.WriteLine(p[i].IsStatic + "  " + p[i].DeclaringType);
                MethodBody mb = p[i].GetMethodBody();
            }

            #endregion Demo1 GetConstructors()

            ConstructorInfo[] p1 = typeof(ReflectionClass1).GetConstructors(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(p1.Length);

            for (int i = 0; i < p1.Length; i++)
            {
                Console.WriteLine(p1[i].IsStatic);
            }
        }

        /// <summary>
        /// 使用反射获得类中所支持的方法，还有方法的信息。
        /// </summary>
        public static void ReflectionClass2Demo()
        {
            Type t = typeof(ReflectionClass2);   //获取描述MyClassA类型的Type对象
            Console.WriteLine("Analyzing methods in " + t.Name);  //t.Name="ReflectionClass2"

            MethodInfo[] mi = t.GetMethods();  //MethodInfo对象在System.Reflection命名空间下。
            foreach (MethodInfo m in mi) //遍历mi对象数组
            {
                Console.Write(m.ReturnType.Name); //返回方法的返回类型
                Console.Write(" " + m.Name + "("); //返回方法的名称

                ParameterInfo[] pi = m.GetParameters();  //获取方法参数列表并保存在ParameterInfo对象数组中
                for (int i = 0; i < pi.Length; i++)
                {
                    Console.Write(pi[i].ParameterType.Name); //方法的参数类型名称
                    Console.Write(" " + pi[i].Name);  // 方法的参数名
                    if (i + 1 < pi.Length)
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write(")");
                Console.WriteLine(); //换行
            }
        }

        /// <summary>
        /// GetMethods(BindingFlags bindingAttr)这个方法，参数可以使用or把两个或更多标记连接在一起，
        /// 实际上至少要有Instance（或Static）与Public（或NonPublic）标记。否则将不会获取任何方法。
        /// </summary>
        public static void ReflectionClass3Demo()
        {
            /*
            DeclareOnly:仅获取指定类定义的方法，而不获取所继承的方法；
            Instance：获取实例方法
            NonPublic: 获取非公有方法
            Public： 获取共有方法
            Static：获取静态方法
            */
            Type t = typeof(ReflectionClass3);   //获取描述ConApp3类型的Type对象
            Console.WriteLine("Analyzing methods in " + t.Name);  //t.Name="ReflectionClass3"

            MethodInfo[] mi = t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);  //不获取继承方法，为实例方法，为公开的
            foreach (MethodInfo m in mi) //遍历mi对象数组
            {
                Console.Write(m.ReturnType.Name); //返回方法的返回类型
                Console.Write(" " + m.Name + "("); //返回方法的名称

                ParameterInfo[] pi = m.GetParameters();  //获取方法参数列表并保存在ParameterInfo对象数组中
                for (int i = 0; i < pi.Length; i++)
                {
                    Console.Write(pi[i].ParameterType.Name); //方法的参数类型名称
                    Console.Write(" " + pi[i].Name);  // 方法的参数名
                    if (i + 1 < pi.Length)
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write(")");
                Console.WriteLine(); //换行
            }
        }

        public static void ReflectionClass4Demo()
        {
            Type t = typeof(ReflectionClass4);
            ReflectionClass4 reflectOb = new ReflectionClass4(10, 20);
            reflectOb.Show();  //输出为： x:10, y:20
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi)
            {
                ParameterInfo[] pi = m.GetParameters();

                if (m.Name.Equals("Set", StringComparison.Ordinal) && pi[0].ParameterType == typeof(int))
                {
                    object[] args = new object[2];
                    args[0] = 9;
                    args[1] = 10;
                    //参数reflectOb,为一个对象引用，将调用他所指向的对象上的方法，如果为静态方法这个参数必须设置为null
                    //参数args，为调用方法的参数数组，如果不需要参数为null
                    m.Invoke(reflectOb, args);   //调用MyClass类中的参数类型为int的Set方法，输出为Inside set(int,int).x:9, y:10
                }
            }
        }

        /// <summary>
        /// 反射获取构造函数并实例化
        /// </summary>
        public static void ReflectionClass5Demo()
        {
            /// <summary>
            ///  在这之前的阐述中，由于Class类型的对象是都是显式创建的，
            ///  因此使用反射技术调用Class类中的方法是没有任何优势的，
            ///  还不如以普通方式调用方便简单呢。
            ///  但是，如果对象是在运行时动态创建的，反射功能的优势就会显示出来。
            ///  在这种情况下，要先获取一个构造函数列表，然后调用列表中的某个构造函数，创建一个该类型的实例。
            ///  通过这种机制，可以在运行时实例化任意类型的对象，而不必在声明语句中指定类型。
            /// </summary>
            Type t = typeof(ReflectionClass5);
            int val;
            ConstructorInfo[] ci = t.GetConstructors();  //使用这个方法获取构造函数列表

            int x;
            for (x = 0; x < ci.Length; x++)
            {
                ParameterInfo[] pi = ci[x].GetParameters(); //获取当前构造函数的参数列表
                if (pi.Length == 2) break;    //如果当前构造函数有2个参数，则跳出循环
            }

            if (x == ci.Length)
            {
                return;
            }

            object[] consargs = new object[2];
            consargs[0] = 10;
            consargs[1] = 20;
            object reflectOb = ci[x].Invoke(consargs);  //实例化一个这个构造函数有两个参数的类型对象,如果参数为空，则为null
            ReflectionClass5 ac5 = reflectOb as ReflectionClass5;
            //实例化后，调用ConApp5中的方法
            MethodInfo[] mi = t.GetMethods(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            foreach (MethodInfo m in mi)
            {
                if (m.Name.Equals("sum", StringComparison.Ordinal))
                {
                    val = (int)m.Invoke(reflectOb, null);  //由于实例化类型对象的时候是用的两个参数的构造函数，所以这里返回的结构为30
                    Console.WriteLine(" sum is " + val);  //输出 sum is 30
                }
            }
        }

        #endregion 反射系列
    }
}