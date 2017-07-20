using System;

namespace 多态.Pet
{
    internal class Dog : Pet
    {
        public string Strain { get; set; }

        public Dog(string name, int heath, int love, string strain)
        {
            Name = name;
            Health = heath;
            Love = love;
            Strain = strain;
        }

        public override void Print()
        {
            Console.WriteLine("名字：{0}，体力值{1}，爱心指数{2}，品种{3}", Name, Health, Love, Strain);
        }

        public override void ToHospital()
        {
            Health = 350;
        }
    }
}