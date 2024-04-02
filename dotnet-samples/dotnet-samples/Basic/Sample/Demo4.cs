using BasicSample.Model;
using System;
using System.Threading;

namespace BasicSample
{
    internal class Demo4 : IExample
    {
        public void Invoke()
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

            Person per = new Person
            {
                Name = "小明",
                Age = 19,
                Sex = "nan"
            };

            ParameterizedThreadStart pt1 = new ParameterizedThreadStart(DoWork);
            pt1(per);

            ParameterizedThreadStart pt2 = new ParameterizedThreadStart(DoWork);
            pt2(per);

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Thread t4 = new Thread(pt2);
            t4.Start(per);
        }

        public static void DoWork(object objPer)
        {
            Person per = objPer as Person;
            if (per != null)
            {
                Console.WriteLine($"Helo I am {per.Name},{per.Sex},{per.Age} years old");
            }
        }
    }
}