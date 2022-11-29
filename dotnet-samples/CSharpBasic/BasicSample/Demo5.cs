using BasicSample.Model;
using System;
using System.Threading;

namespace BasicSample
{
    public class Demo5 : IExample
    {
        public void Invoke()
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