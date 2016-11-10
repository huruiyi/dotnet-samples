using System;

namespace 继承1
{
    internal abstract class Person
    {
        public string Name { get; set; }

        public string Sex { get; set; }

        public int Age { get; set; }

        public abstract void SayHi();
    }

    internal class Student : Person
    {
        public string Hobby { get; set; }

        public string Popularity { get; set; }

        public Student(string name, string sex, int age, string hobby, string popularity)
        {
            Name = name;
            Sex = sex;
            Age = age;
            this.Hobby = hobby;
            this.Popularity = popularity;
        }

        public override void SayHi()
        {
            Console.WriteLine("name={0},sex={1},age={2},hobby={3},populary={4}", Name, Sex, Age, Hobby, Popularity);
        }
    }

    internal class 继承1
    {
        private static void Main(string[] args)
        {
            Student stu = new Student("tom", "nan", 21, "Apple", "2100");
            stu.SayHi();
            Console.ReadLine();
        }
    }
}