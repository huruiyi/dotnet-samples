using System;
using System.Collections;

namespace 继承2
{
    internal class Student : Person
    {
        public string Hobby { get; set; }

        private int _popularity = 90;

        public int Popularity
        {
            get { return _popularity; }
            set { _popularity = value; }
        }

        public void SayHi()
        {
            Console.WriteLine("大家好，我是{0}，性别为：{1}，年龄是：{2}，我的爱好是：{3}，我受欢迎程度为：{4}", Name, Sex, Age, Hobby, _popularity);
        }

        public Student()
        {
        }

        public Student(string name, string sex, int age)
            : base(age, name, sex)
        {
        }

        public Student(string name, string sex, int age, string hobby, int popularity)
            : this(name, sex, age)
        {
            this.Hobby = hobby;
            this._popularity = popularity;
        }
    }

    internal class Person
    {
        private int age = 20;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Sex { get; set; }

        public string Name { get; set; }

        public Person()
        {
        }

        public Person(int age, string name, string sex)
        {
            this.age = age;
            Name = name;
            Sex = sex;
        }
    }

    internal class 继承
    {
        private static void Main4(string[] args)
        {
            //Student stu = new Student("张三", "female", 20, "逛街", 98);
            //stu.SayHi();
            //Console.WriteLine(stu.Name);

            //Person p = new Person();
            //Student stu1 = p as Student;
            //if (stu1 == null)
            //{
            //    Console.WriteLine("转换失败！");
            //}
            //else
            //{
            //    stu1.SayHi();
            //}

            ArrayList students = new ArrayList();
            Student stu = new Student("张三", "男", 20, "打篮球", 95);
            Student stu1 = new Student("李四", "女", 22, "逛街", 98);
            Student stu2 = new Student("王五", "男", 21, "踢足球", 96);

            students.Add(stu);
            students.Add(stu1);
            students.Add(stu2);

            foreach (Student stu0 in students)
            {
                Student myStudent = stu;
                myStudent.Age = 60;
            }
            foreach (Student stu0 in students)
            {
                Console.WriteLine((int)stu.Age);
            }

            Student stu3 = new Student("张三", "男", 20, "打篮球", 95);
            students.Remove(stu3);

            //Student stuobj = students[0] as Student;
            //stuobj.SayHi();

            //students.Remove(stu);
            //students.RemoveAt(0);
            //students.RemoveRange(0, 2);
            //students.Clear();

            //Student stuobj = students[0] as Student;
            //stuobj.SayHi();

            //for (int i = 0; i < students.Count; i++)
            //{
            //    Student stu0 = students[i] as Student;
            //    stu0.SayHi();
            //}

            Console.ReadLine();
        }
    }
}