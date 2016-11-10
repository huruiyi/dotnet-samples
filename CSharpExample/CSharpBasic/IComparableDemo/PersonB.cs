using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparableDemo
{
    public class PersonB
    {
        public String Name { get; set; }
        public int Age { get; set; }

        public void Show()
        {
            Console.WriteLine("姓名:" + Name + "年龄:" + Age);
        }
    }
}
