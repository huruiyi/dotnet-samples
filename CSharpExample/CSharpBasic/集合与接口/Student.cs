using System;

namespace 集合与接口
{
    internal class Student : Person, IComparable
    {
        public int Age { get; set; }

        public Student()
        {
        }

        public Student(string name, char sex, int age)
            : base(name, sex)
        {
            Age = age;
        }

        public void Show()
        {
            Console.WriteLine("我叫{0}，性别{1}，今年{2}岁", Name, Sex, Age);
        }

        //public int CompareTo(Object obj)
        //{
        //    Student stu = obj as Student;
        //    if (this.Age < stu.Age)
        //    {
        //        return -1;
        //    }
        //    else if (this.Age == stu.Age)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return 1;
        //    }
        //}
        //public int CompareTo(Object obj)
        //{
        //    Student stu = obj as Student;
        //    return this.Name.CompareTo(stu.Name);
        //}
        public int CompareTo(Object obj)
        {
            Student stu = obj as Student;
            return stu.Name.CompareTo(this.Name);
            // return this.Age.CompareTo(stu.Age);
            //对姓名进行排序
        }
    }
}