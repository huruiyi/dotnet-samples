using System.Collections.Generic;

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

        public string Hobby { get; set; }

        public List<Order> Orders { get; set; }

        [ValidateAge(50, "")]
        public int Age { get; set; }
    }

    public class Equip
    {
        public string Name { get; set; }

        public double AttackValue { get; set; }
    }
}