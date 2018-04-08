using System;

namespace ConApp.EventSample.EventDemo5
{
    public class Human
    {
        public event Action<string> OnSpeak;

        public void Speak(string content)
        {
            Console.WriteLine("{0}说了句：{1}", Name, content);
            if (OnSpeak != null)
            {
                OnSpeak(content);
            }
        }

        public string Name { get; set; }

        public Human(string name)
        {
            Name = name;
        }
    }
}