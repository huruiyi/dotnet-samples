using System;

namespace ConApp.DesignPattern
{
    public abstract class CoffeeinBeverage
    {
        public void BoilWater()
        {
            Console.WriteLine("烧水");
        }

        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            if (WantCondiments())
            {
                AddCondiments();
            }
        }

        /// <summary>
        /// 加入一个方法，用来判断是否需要加调料
        /// </summary>
        /// <returns></returns>
        public virtual bool WantCondiments()
        {
            return true;
        }

        public void PourInCup()
        {
            Console.WriteLine("倒入杯子中");
        }

        public abstract void Brew();

        public abstract void AddCondiments();
    }

    public class Coffee : CoffeeinBeverage
    {
        public override void Brew()
        {
            Console.WriteLine("冲咖啡");
        }

        public override void AddCondiments()
        {
            Console.WriteLine("加糖和牛奶");
        }

        public override bool WantCondiments()
        {
            return false;
        }
    }

    public class Tea : CoffeeinBeverage
    {
        public override void Brew()
        {
            Console.WriteLine("泡茶");
        }

        public override void AddCondiments()
        {
            Console.WriteLine("加柠檬");
        }
    }

    public class 模版方法
    {
        private void Test()
        {
            CoffeeinBeverage beverage = new Coffee();
            beverage.PrepareRecipe();

            CoffeeinBeverage teaBeverage = new Tea();
            teaBeverage.PrepareRecipe();
        }
    }
}