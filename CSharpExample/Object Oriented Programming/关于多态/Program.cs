using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 关于多态
{
    class Program
    {
        static void Main(string[] args)
        {
            ISpeak istu = new Studnet();
            istu.Speak();
            Studnet stu = new Studnet("Tom","male",18,"English");
            stu._AA = "123456789";
            Console.WriteLine(stu._AA);
            Console.ReadKey();
        }
    }
}
