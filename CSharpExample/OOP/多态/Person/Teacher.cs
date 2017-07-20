using System;

namespace 多态.Person
{
    internal class Teacher : Person, ISpeak
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

        public void Speak()
        {
            Console.WriteLine("老师会说话");
        }

        public string Id { get; set; }
    }
}