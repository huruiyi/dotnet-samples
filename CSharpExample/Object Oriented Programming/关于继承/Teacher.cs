using System;

namespace ConsoleApplication1
{
    internal class Teacher : Person
    {
        public Teacher()
        {
        }

        public Teacher(string name, string sex, int age, string salary)
            : base(name, sex, age)
        {
            Salary = salary;
        }

        public string Salary { get; set; }

        //实现抽象类
        public override void Study()
        {
            Console.WriteLine("老师会学习");
        }
    }
}