using System;
using System.Collections.Generic;

namespace 集合与接口
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            Student student1 = new Student("a", '女', 20);
            Student student2 = new Student("x", '男', 19);
            Student student3 = new Student("g", '女', 20);
            Student student4 = new Student("e", '男', 19);
            Student student5 = new Student("j", '女', 20);
            Student student6 = new Student("k", '男', 19);
            Student student7 = new Student("s", '女', 20);
            Student student8 = new Student("c", '男', 19);
            list.Add(student1);
            list.Add(student2);
            list.Add(student3);
            list.Add(student4);
            list.Add(student5);
            list.Add(student6);
            list.Add(student7);
            list.Add(student8);
            Console.WriteLine("。。。。。。。。。。。排序前。。。。。。。。。。。");
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Show();
            }
            Console.WriteLine("。。。。。。。。。。。排序后。。。。。。。。。。。");
            list.Sort();
            list.Reverse();
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Show();
            }
            Console.ReadKey();
        }
    }
}