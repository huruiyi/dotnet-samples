using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fairy.Reflection
{
    public class Person
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Hobby { get; set; }
        public Person()
        {
        }
        public Person(string name, string sex, string hobby)
        {
            Name = name;
            Sex = sex;
            Hobby = hobby;
        }

        public override string ToString()
        {
            return $"姓名:{Name}\n性别:{Sex}\n爱好:{Hobby}";
        }

        public void ShowInfo()
        {
            Console.WriteLine("姓名:{0}\n性别:{1}\n爱好:{2}", Name, Sex, Hobby);
        }
        public static string SayHi(string name)
        {
            return $"{"SayHi",10}:{name},你好啊！！";
        }
        public string SayHello(string name)
        {
            return $"{"SayHello",10}:{name},你好啊！！";
        }
    }
}
