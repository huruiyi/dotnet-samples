using System;

namespace 多态.SamplePet
{
    internal abstract class Penguin : Pet
    {
        public string Sex { get; set; }

        protected Penguin(string name, int heath, int love, string sex)
        {
            Name = name;
            Health = heath;
            Love = love;
            Sex = sex;
        }

        public override void Print()
        {
            Console.WriteLine("名字：{0}，体力值{1}，爱心指数{2}，品种{3}", Name, Health, Love, Sex);
        }

        public override void ToHospital()
        {
            Health = 300;
        }
    }
}