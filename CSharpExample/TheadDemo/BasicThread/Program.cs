using System;
using System.Threading;

namespace BasicThread
{
    internal class Work
    {
        public static void DoWork()
        {
            Console.WriteLine("Static thread procedure.");
        }

        public int Data;

        public void DoMoreWork()
        {
            Console.WriteLine("Instance thread procedure. Data={0}", Data);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
        }

        public static void DoWork(object objPer)
        {
            Person per = objPer as Person;
            if (per != null)
            {
                Console.WriteLine($"Helo I am {per.Name},{per.Sex},{per.Age} years old");
            }
        }

        private static void Demo1()
        {
            Thread t1 = new Thread(Work.DoWork);
            t1.Start();

            ThreadStart ts = new ThreadStart(Work.DoWork);
            Thread t2 = new Thread(ts);
            t2.Start();

            Work w = new Work();
            w.Data = 30;
            ThreadStart tss = new ThreadStart(w.DoMoreWork);
            Thread t3 = new Thread(tss);
            t3.Start();

            Person per = new Person { Name = "小明", Age = 19, Sex = "nan" };

            ParameterizedThreadStart pt1 = new ParameterizedThreadStart(DoWork);
            pt1(per);

            ParameterizedThreadStart pt2 = new ParameterizedThreadStart(DoWork);
            pt2(per);

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Thread t4 = new Thread(pt2);
            t4.Start(per);
            Console.Read();
        }

        private static void Demo2()
        {
            Person person = new Person { Name = "Ruin", Sex = "nam" };
            Thread t2 = new Thread(p => SayHi(person));
            t2.Start();

            Thread t1 = new Thread(() => Say("sas"));
            t1.Start();
            Thread t3 = new Thread(delegate () { Console.WriteLine("dsadasd"); Say("sas"); });
            t3.Start();

            Thread t7 = new Thread(delegate () { SayHi(person); });
            t7.Start();

            var t4 = new Thread(delegate (object objPerson)
            {
                var per = objPerson as Person;
                if (per != null)
                    Console.WriteLine("姓名：" + per.Name);
            });
            t4.Start(person);

            var t5 = new Thread(Start);
            t5.Start();
            //new Thread(new ParameterizedThreadStart(PrintMessage));
            var t6 = new Thread(PrintMessage);
            t6.Start("打印信息如下......");
        }

        private static void Start()
        {
            Console.WriteLine("Start.......");
        }

        private static void Say(string s)
        {
            Console.WriteLine("Say........" + s);
        }

        private static void SayHi(Person p)
        {
            Console.WriteLine(p.Name + "" + p.Sex);
        }

        private static void PrintMessage(object msg)
        {
            var sMsg = (string)msg;
            Console.WriteLine(sMsg);
            Thread.Sleep(500);
        }
    }
}