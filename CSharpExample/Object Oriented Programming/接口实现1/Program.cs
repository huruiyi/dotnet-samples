using System;

namespace 接口实现1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            School school = new School("开元");
            Teacher teacher = new Teacher("张三", "C#程序设计");
            school.SetPrinter(new ColorPrinter());
            school.print(school);
            school.print(teacher);

            Console.Read();
        }
    }
}