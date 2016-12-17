using System;
using 多态.SamplePet;
using 多态.SampleStorage;

namespace 多态
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Demo0();
            Console.ReadKey();
        }

        private static void Demo0()
        {
            //Pet pet = new Dog("dd", 20, 10, "gg");
            //pet.print();

            Dog dog = new Dog("aa", 120, 100, "aa");
            Master master = new Master();
            master.Cure(dog);
            dog.Print();
        }

        private static void Demo1()
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

        private static void Demo2()
        {
            ISpeak istu = new Studnet();
            istu.Speak();
            Studnet stu = new Studnet("Tom", "male", 18, "English");
            stu._AA = "123456789";
            Console.WriteLine(stu._AA);
        }
    }
}