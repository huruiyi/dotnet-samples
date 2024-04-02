using System;

namespace 装饰模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Person xc = new Person("小菜");

            Console.WriteLine("\n第一种装扮：");

            Finery dtx = new TShirts();
            Finery kk = new BigTrouser();
            Finery pqx = new Sneakers();

            dtx.Show();
            kk.Show();
            pqx.Show();
            xc.Show();

            Console.WriteLine("\n第二种装扮：");

            Finery xz = new Suit();
            Finery ld = new Tie();
            Finery px = new LeatherShoes();

            xz.Show();
            ld.Show();
            px.Show();
            xc.Show();

            Console.Read();
        }
    }

    internal class Person
    {
        private string name;

        public Person(string name)
        {
            this.name = name;
        }

        public void Show()
        {
            Console.WriteLine("装扮的{0}", name);
        }
    }

    //服饰
    internal abstract class Finery
    {
        public abstract void Show();
    }

    //大T恤
    internal class TShirts : Finery
    {
        public override void Show()
        {
            Console.Write("大T恤 ");
        }
    }

    //垮裤
    internal class BigTrouser : Finery
    {
        public override void Show()
        {
            Console.Write("垮裤 ");
        }
    }

    //破球鞋
    internal class Sneakers : Finery
    {
        public override void Show()
        {
            Console.Write("破球鞋 ");
        }
    }

    //西装
    internal class Suit : Finery
    {
        public override void Show()
        {
            Console.Write("西装 ");
        }
    }

    //领带
    internal class Tie : Finery
    {
        public override void Show()
        {
            Console.Write("领带 ");
        }
    }

    //皮鞋
    internal class LeatherShoes : Finery
    {
        public override void Show()
        {
            Console.Write("皮鞋 ");
        }
    }
}