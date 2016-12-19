using System;

namespace InheritSample1
{
    public abstract class Person
    {
        public string Name { get; set; }

        public string Sex { get; set; }

        public int Age { get; set; }

        public abstract void SayHi();
    }

    public class Student : Person
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

    public class Demo1
    {
        private static void Main1(string[] args)
        {
            Student stu = new Student("tom", "nan", 21, "Apple", "2100");
            stu.SayHi();
            Console.ReadLine();
        }
    }
}