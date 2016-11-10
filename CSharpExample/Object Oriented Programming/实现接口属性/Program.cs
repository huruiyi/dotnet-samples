using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 实现接口属性
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("实行属性的接口");
            Student stu = new Student();
            stu.ID = "1234567891234567";
            Console.WriteLine(stu.ID);
            Console.WriteLine("++++++++++++++++++++++++++++++++=");
            Console.WriteLine("实现属性");
            stu.Sex = "男";
            Console.WriteLine(stu.Sex);
            Console.ReadKey();
        }
    }
}
