using System;
using System.Collections;

namespace InheritSample2
{
    public class Person
    {
        static Person()
        {
            //静态方法只有第一次实例化函数时被调用
            Console.WriteLine("伟大的人类诞生了");
        }

        public int Age { get; set; } = 20;

        public string Sex { get; set; }

        public string Name { get; set; }

        public Person()
        {
        }

        public Person(int age, string name, string sex)
        {
            this.Age = age;
            Name = name;
            Sex = sex;
        }
    }

    public class Student : Person
    {
        public string Hobby { get; set; }

        public int Popularity { get; set; } = 90;

        public void SayHi()
        {
            Console.WriteLine("大家好，我是{0}，性别为：{1}，年龄是：{2}，我的爱好是：{3}，我受欢迎程度为：{4}", Name, Sex, Age, Hobby, Popularity);
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
            this.Popularity = popularity;
        }
    }

    public class Demo2
    {
        private static void test1()
        {
            Student stu = new Student("张三", "female", 20, "逛街", 98);
            stu.SayHi();
            Console.WriteLine(stu.Name);

            Person p = new Person();
            Student stu1 = p as Student;
            if (stu1 == null)
            {
                Console.WriteLine("转换失败！");
            }
            else
            {
                stu1.SayHi();
            }
        }

        private static void Main2(string[] args)
        {
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
          

            Student stu3 = new Student("张三", "男", 20, "打篮球", 95);
            students.Remove(stu3);

            foreach (Student stu0 in students)
            {
                Console.WriteLine((int)stu.Age);
            }

            Console.ReadLine();
        }
    }
}