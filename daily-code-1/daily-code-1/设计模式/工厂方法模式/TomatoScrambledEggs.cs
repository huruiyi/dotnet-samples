using System;

namespace 工厂方法模式
{
    /// <summary>
    /// 西红柿炒鸡蛋这道菜
    /// </summary>
    public class TomatoScrambledEggs : AbstractFood
    {
        public override void Print()
        {
            Console.WriteLine("西红柿炒蛋好了！");
        }
    }
}