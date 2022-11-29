using System;

namespace ConApp.EventSample.EventDemo5
{
    public class Test
    {
        public static void Demo()
        {
            Human master = new Human("John");
            Dog dog = new Dog(master, "旺财");
            Cat cat = new Cat(master, "Tom");
            Dog dog2 = new Dog(master, "二狗");
            master.Speak("hello kitty");
            Console.ReadLine();
            master.Speak("Bye Bye");
        }
    }
}