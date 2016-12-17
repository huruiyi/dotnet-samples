using System;

namespace 多态.SamplePerson
{
    internal abstract class Person
    {
        public Person()
        {
        }

        public Person(string name, string sex, int age)
        {
            Name = name;
            Sex = sex;
            Age = age;
        }

        public string Name { get; set; }

        public string Sex { get; set; }

        public int Age { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine("(person)姓名：" + Name + ",性别：" + Sex + "年龄：" + Age + "\n");
        }
    }
}