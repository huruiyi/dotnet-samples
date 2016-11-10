using System;

namespace 索引器
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Teacher teacher = new Teacher();
            teacher[0] = new Student("小明", 19, "男");
            teacher[0].Say();
            teacher[1] = new Student("小红", 20, "女");
            teacher[0].Say();
            teacher[2] = new Student("小德", 21, "男");
            teacher[0].Say();

            Console.ReadKey();
        }
    }
}