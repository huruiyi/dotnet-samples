using System;

namespace PredicateDelegate
{
    public class Student : PersonA, IComparable<PersonA>
    {
        public string Hobby { get; set; }
        public int Popularity { get; set; }

        public Student(string name, string sex, int age, string hobby, int popularity)
        {
            Name = name;
            Sex = sex;
            Age = age;
            Hobby = hobby;
            Popularity = popularity;
        }

        public override void SayHi()
        {
            Console.WriteLine("姓名：{0}，性别：{1}，年龄：{2}，爱好：{3}，受欢迎程度：{4}", Name, Sex, Age, Hobby, Popularity);
        }

        //按照年龄排序
        public int CompareTo(PersonA other)
        {
            return other.Age.CompareTo(this.Age);
        }
    }
}