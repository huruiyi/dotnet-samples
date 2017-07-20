using System;

namespace 多态.Person
{
    internal class Studnet : Person, ISpeak
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

        public void Speak()
        {
            Console.WriteLine("学生会说话");
        }

        public string Id { get; set; }
    }
}