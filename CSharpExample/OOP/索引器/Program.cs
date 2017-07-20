using System;

namespace 索引器
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.ReadKey();
        }

        private static void Demo0()
        {
            Teachers teacher = new Teachers();
            teacher[0] = new Student("小明", 19, "男");
            teacher[0].Say();
            teacher[1] = new Student("小红", 20, "女");
            teacher[0].Say();
            teacher[2] = new Student("小德", 21, "男");
            teacher[0].Say();
        }

        private static void Demo1()
        {
            SampleCollection<string> stringCollection = new SampleCollection<string>();

            stringCollection[0] = "Hello, World";
            System.Console.WriteLine(stringCollection[0]);
        }

        private static void Demo2()
        {
            IndexerClass test = new IndexerClass();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                test[i] = rand.Next();
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Element #{0} = {1}", i, test[i]);
            }
        }
    }
}