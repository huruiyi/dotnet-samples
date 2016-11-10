using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp.Class
{
    internal class Tom : Student
    {
        public string Hobby { get; set; }
        public int Popularity { get; set; }

        public Tom()
        {
        }

        public Tom(string name, int age, char sex, string hobby, int popularity)
            : base(name, age, sex)
        {
            Hobby = hobby;
            Popularity = popularity;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Hello ,My name is {0},I am {1} years old,I am a {2},My hobby is {3},My pupularity is {4} ", Name, Age, Sex, Hobby, Popularity);
        }
    }
}
