using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Studnet:Person
    {
        public Studnet()
        { 
        
        }
        private string _Course;
        public string Course
        {
            get { return _Course; }
            set { _Course = value; }
        }
        public Studnet(string name, string sex, int age,string course)
            : base(name, sex, age)
        {
            Course = course;
        }

        public void ShowStuInfo()
        {
            Console.WriteLine("(student)我叫："+Name+"性别："+Sex+"，爱好学科："+Course);
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
