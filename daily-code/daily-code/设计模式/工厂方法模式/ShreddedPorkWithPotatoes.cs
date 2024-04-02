using System;

namespace 工厂方法模式
{
    /// <summary>
    /// 土豆肉丝这道菜
    /// </summary>
    public class ShreddedPorkWithPotatoes : AbstractFood
    {
        public override void Print()
        {
            Console.WriteLine("土豆肉丝好了");
        }
    }
}