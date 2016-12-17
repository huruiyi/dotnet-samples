using System;

namespace ConsoleApplication1
{
    internal class Studnet : Person
    {
        public Studnet()
        {
        }

        public string Course { get; set; }

        public Studnet(string name, string sex, int age, string course)
            : base(name, sex, age)
        {
            Course = course;
        }

        public void ShowStuInfo()
        {
            Console.WriteLine("(student)我叫：" + Name + "性别：" + Sex + "，爱好学科：" + Course);
        }

        //实现抽象类
        public override void Study()
        {
            Console.WriteLine("学生会学习");
        }

        //对父类中的虚方法进行重写(非必须)
        public override void Speak()
        {
            Console.WriteLine("对Person类中abstract方法进行重写");
        }
    }
}