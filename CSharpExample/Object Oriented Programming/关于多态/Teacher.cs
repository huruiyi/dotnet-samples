using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 关于多态
{
    class Teacher : Person,ISpeak
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
        public void Speak()
        {
            Console.WriteLine("老师会说话");
        }




        private string AA;
        public string _AA
        {
            get
            {
                return AA;
            }
            set
            {
                AA = value;
            }
        }




      
    }
}
