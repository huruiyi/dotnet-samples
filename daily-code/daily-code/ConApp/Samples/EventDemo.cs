using System;

namespace ConApp.Samples
{
    public class Cat
    {
        public Human Master { get; set; }

        public string Name { get; set; }

        public Cat(Human master, string name)
        {
            Name = name;
            Master = master;
            master.OnSpeak += OnMasterSpeak;
        }

        public void OnMasterSpeak(string content)
        {
            if (content == "Bye Bye")
            {
                Console.WriteLine("{0}猫叫了声：喵喵", Name);
            }
        }
    }

    public class Dog
    {
        public Human Master { get; set; }

        public string Name { get; set; }

        public Dog(Human master, string name)
        {
            Name = name;
            Master = master;
            master.OnSpeak += OnMasterSpeak;
        }

        public void OnMasterSpeak(string content)
        {
            if (content == "Bye Bye")
            {
                Console.WriteLine("{0}狗叫了声：汪汪", Name);
            }
        }
    }

    public class Human
    {
        public event Action<string> OnSpeak;

        public void Speak(string content)
        {
            Console.WriteLine("{0}说了句：{1}", Name, content);
            OnSpeak?.Invoke(content);
        }

        public string Name { get; set; }

        public Human(string name)
        {
            Name = name;
        }
    }

    internal class EventDemo
    {
    }
}
