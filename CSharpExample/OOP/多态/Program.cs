using System;
using 多态.Person;
using 多态.Pet;
using 多态.Storage;

namespace 多态
{
    public class Program
    {
        public static void Demo0()
        {
            //Pet pet = new Dog("dd", 20, 10, "gg");
            //pet.print();

            Dog dog = new Dog("aa", 120, 100, "aa");
            Master master = new Master();
            master.Cure(dog);
            dog.Print();
        }

        public static void Demo1()
        {
            #region 继承

            MobileStorage mp3 = new Mp3();
            mp3.Read();
            mp3.Write();
            Mp3 m = mp3 as Mp3;
            m.Playmusic();

            MobileStorage fd = new FlashDish();
            fd.Read();
            fd.Write();

            #endregion 继承

            Console.WriteLine();

            Computer cm = new Computer(new Mp3());
            cm.cRead();
            cm.cWrite();
            Mp3 m3 = cm.Storage as Mp3;
            if (m3 != null)
            {
                m3.Playmusic();
            }

            Computer cf = new Computer(new FlashDish());
            cf.cRead();
            cf.cWrite();

            Console.WriteLine();
            MobileStorage[] cs = { new Mp3(), new FlashDish() };
            foreach (MobileStorage item in cs)
            {
                item.Write();
                item.Read();
            }
        }

        public static void Demo2()
        {
            ISpeak istu = new Studnet();
            istu.Speak();
            Studnet stu = new Studnet("Tom", "male", 18, "English");
            stu.Id = "123456789";
            Console.WriteLine(stu.Id);
        }
    }
}

namespace NDemo3
{
    #region Introduceable

    public interface IIntroduceable
    {
        string ShowDetail();
    }

    public class Teacher : IIntroduceable
    {
        public string Name { get; set; }
        public string Course { get; set; }

        public Teacher(string name, string course)
        {
            Name = name;
            Course = course;
        }

        public string ShowDetail()
        {
            return string.Format("本人是{0}教员,教授课程为{1}", Name, Course);
        }
    }

    public class Headmasters : IIntroduceable
    {
        public string Name { get; set; }

        public Headmasters(string name)
        {
            Name = name;
        }

        private IPrintable printer;

        public void SetPrinter(IPrintable p)
        {
            printer = p;
        }

        public string ShowDetail()
        {
            return string.Format("我是{0}", Name);
        }

        public void print(IIntroduceable intro)
        {
            printer.Print(intro.ShowDetail());
        }
    }

    #endregion Introduceable

    #region IPrintable

    public interface IPrintable
    {
        void Print(string content);
    }

    public class BlackPrinter : IPrintable
    {
        public void Print(string content)
        {
            Console.WriteLine("黑白打印：");
            Console.WriteLine(content);
        }
    }

    public class ColorPrinter : IPrintable
    {
        public void Print(string content)
        {
            Console.WriteLine("彩色打印：");
            Console.WriteLine(content);
        }
    }

    #endregion IPrintable

    public class Program
    {
        private static void Main(string[] args)
        {
            Headmasters school = new Headmasters("校长");
            Teacher teacher = new Teacher("张三", "C#程序设计");
            school.SetPrinter(new ColorPrinter());
            school.print(school);
            school.print(teacher);

            Console.Read();
        }
    }
}