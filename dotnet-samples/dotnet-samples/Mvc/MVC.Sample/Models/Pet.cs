using System;

namespace MVC.Sample.Models
{
    public class Pet
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime Brithday { get; set; }

        public decimal Price { get; set; }

        public uint LegCount { get; set; }
    }
}