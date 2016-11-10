using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp.Class
{
    public class Person
    {
        public string Name { get; set; }

        public double Salary { get; set; }

        public char Sex { get; set; }

        public List<Equip> Equips { get; set; }

        public string[] Hobbys { get; set; }

        public Dictionary<int, string> Attributes { get; set; }
    }

    public class Equip
    {
        public string Name { get; set; }

        public double AttackValue { get; set; }
    }
}
