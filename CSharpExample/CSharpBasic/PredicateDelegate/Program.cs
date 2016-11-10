using System;
using System.Collections.Generic;

namespace PredicateDelegate
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Student> list = new List<Student>
            {
                new Student("张32三", "男", 20, "打篮球", 95),
                new Student("李y6四", "女", 21, "逛街", 97),
                new Student("王tr五", "女", 18, "足球", 80),
                new Student("张sa三", "男", 36, "打篮球", 95),
                new Student("李sd四", "女", 16, "逛街", 97),
                new Student("王dw五", "女", 31, "足球", 80)
            };

            foreach (Student student in list)
            {
                student.SayHi();
            }
            Console.WriteLine();
            list.Sort();

            Predicate<PersonA> pre = Match;
            list.RemoveAll(pre);
            foreach (Student t in list)
            {
                t.SayHi();
            }

            Console.Read();
        }

        private static bool Match(PersonA p)
        {
            if (p.Age <= 18)
            {
                return true;
            }
            return false;
        }
    }
}