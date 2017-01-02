using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp.Class
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public char Sex { get; set; }

        public Student()
        {
        }

        public Student(string name, int age, char sex)
        {
            Name = name;
            Age = age;
            Sex = sex;
        }
    }
}
