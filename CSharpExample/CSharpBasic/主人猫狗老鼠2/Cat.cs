using System;

namespace 主人猫狗老鼠2
{
    internal class Cat
    {
        public void Sleep(string place)
        {
            Console.WriteLine("猫在{0}地方睡觉", place);
        }

        public void Shout()
        {
            Console.WriteLine("喵喵");
            OnShout("喵喵");
        }

        public event Action<string> OnShout;
    }
}