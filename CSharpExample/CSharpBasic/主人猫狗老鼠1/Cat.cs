using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 主人猫狗老鼠1
{
    internal class Cat
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
}