using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 关于多态
{
   abstract class Person
    {
       
        public Person() { }
        public Person(string name,string sex,int age)
        {
            Name = name;
            Sex = sex;
            Age = age;
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Sex;
        public string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }
        private int _Age;
        public int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
     
       
        public void ShowInfo()
        {
            Console.WriteLine("(person)姓名："+Name+",性别："+Sex+"年龄："+Age+"\n");
        }
    }
}
