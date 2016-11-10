using System;

namespace 多态
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Pet pet = new Dog("dd", 20, 10, "gg");
            //pet.print();

            Dog dog = new Dog("aa", 120, 100, "aa");
            Master master = new Master();
            master.Cure(dog);
            dog.Print();

            Console.ReadKey();
        }
    }
}