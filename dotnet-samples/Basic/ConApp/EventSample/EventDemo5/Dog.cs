using System;

namespace ConApp.EventSample.EventDemo5
{
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
}