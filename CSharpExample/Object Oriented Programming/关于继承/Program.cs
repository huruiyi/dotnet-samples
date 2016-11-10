using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Studnet s1 = new Studnet("柯南", "男", 19,"英语");
            s1.ShowInfo();
            s1.ShowStuInfo();
            s1.Speak();
            s1.Study();
            Console.WriteLine("++++++++++++++++++++++++++++++");
            Teacher t1 = new Teacher("李四","男",30,"20000");
            t1.ShowInfo();
            t1.Speak();
            t1.Study();
            Console.WriteLine("++++++++++++++++++++++++++++++");
            Person p1 = new Studnet("柯南", "男", 19, "英语");
            p1.Speak();
            Person p2 = new Teacher("柯南", "男", 19, "英语");
            p2.Speak();
            Console.ReadKey();
        }
    }
}
