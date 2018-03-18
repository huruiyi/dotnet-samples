using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Threading;

namespace ConApp
{
    public partial class Program
    {
        #region ArrayListDemo1

        private static ArrayList list2 = ArrayList.Synchronized(new ArrayList(1000000));

        public static void ArrayListDemo1()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Task1));
            ThreadPool.QueueUserWorkItem(new WaitCallback(Task2));
        }

        public static void Task1(object obj)
        {
            for (int i = 0; i < 500000; i++)
            {
                list2.Add(i);
            }

            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Task1 list2 count {0}", list2.Count);
        }

        public static void Task2(object obj)
        {
            for (int i = 0; i < 500000; i++)
            {
                list2.Add(i);
            }

            Console.WriteLine("Task2 list2 count {0}", list2.Count);
        }

        #endregion ArrayListDemo1

        #region ArrayListDemo2

        private static ArrayList list1 = new ArrayList(1000000);

        public static void ArrayListDemo2()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Task3));
            ThreadPool.QueueUserWorkItem(new WaitCallback(Task4));
        }

        public static void Task3(object obj)
        {
            lock (list1.SyncRoot)
            {
                for (int i = 0; i < 500000; i++)
                {
                    list1.Add(i);
                }
            }

            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Task1 count {0}", list1.Count);
        }

        public static void Task4(object obj)
        {
            lock (list1.SyncRoot)
            {
                for (int i = 0; i < 500000; i++)
                {
                    list1.Add(i);
                }
            }
            Console.WriteLine("Task2 count {0}", list1.Count);
        }

        #endregion ArrayListDemo2


        #region ArrayListDemo3_ConcurrentBag

        public static ConcurrentBag<ArrayList> list3 = new ConcurrentBag<ArrayList>();

        public static void ArrayListDemo3()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Task5));
            ThreadPool.QueueUserWorkItem(new WaitCallback(Task6));
        }

        public static void Task5(object obj)
        {
            for (int i = 0; i < 500000; i++)
            {
                list2.Add(i);
            }

            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Task1 list2 count {0}", list2.Count);
        }

        public static void Task6(object obj)
        {
            for (int i = 0; i < 500000; i++)
            {
                list2.Add(i);
            }

            Console.WriteLine("Task2 list2 count {0}", list2.Count);
        }

        #endregion ArrayListDemo1
    }

}