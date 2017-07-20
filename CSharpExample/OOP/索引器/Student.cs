using System;

namespace 索引器
{
    internal class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }

        public Student(string n, int a, string s)
        {
            Name = n;
            Age = a;
            Sex = s;
        }

        public void Say()
        {
            Console.WriteLine("大家好，我叫{0}，今年{2}岁，性别{2}", Name, Age, Sex);
        }
    }
}