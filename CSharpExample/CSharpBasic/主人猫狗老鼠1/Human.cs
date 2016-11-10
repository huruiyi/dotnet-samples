using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 主人猫狗老鼠1
{
    internal class Human
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