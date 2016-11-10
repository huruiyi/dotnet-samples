using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Teacher : Person
    {
        public Teacher() { }
        public Teacher(string name, string sex, int age, string salary)
            : base(name, sex, age)
        {
            Salary = salary;
        }
        string _Salary;
        public string Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }


        //实现抽象类
        public override void Study()
        {
            Console.WriteLine("老师会学习");
        }
    }
}
