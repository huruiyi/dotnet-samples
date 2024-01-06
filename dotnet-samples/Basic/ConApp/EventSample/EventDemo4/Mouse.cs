using System;

namespace ConApp.EventSample.EventDemo4
{
    public class Mouse
    {
        public void CatlikeEat(string place, string food)
        {
            Console.WriteLine(@"老鼠正在{0}偷吃{1}", place, food);
        }

        public void RunAway(string content)
        {
            Console.WriteLine(@"猫叫了声：{0}，老鼠被吓跑了", content);
        }
    }
}