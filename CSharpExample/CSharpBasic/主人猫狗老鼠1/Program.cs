using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 主人猫狗老鼠1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Human master = new Human("John");
            Dog dog = new Dog(master, "旺财");
            Cat cat = new Cat(master, "Tom");
            Dog dog2 = new Dog(master, "二狗");
            master.Speak("hello kitty");
            Console.ReadLine();
            master.Speak("Bye Bye");
            Console.Read();
        }
    }
}