using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparableDemo
{
    internal class PersonA : IComparable<PersonA>
    {
        public String Name { get; set; }
        public int Age { get; set; }

        public void Show()
        {
            Console.WriteLine("姓名:" + Name + "年龄:" + Age);
        }

        public int CompareTo(PersonA other)
        {
            //return this.Age - other.Age;

            //int result = this.Age.CompareTo(other.Age);
            //return result;

            if (Age > other.Age)
            {
                return -1;
            }
            if (Age == other.Age)
            {
                return 0;
            }
            return 1;
        }
    }
}
