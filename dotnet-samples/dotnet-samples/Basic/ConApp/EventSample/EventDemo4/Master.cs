﻿using System;

namespace ConApp.EventSample.EventDemo4
{
    public class Master
    {
        public void Sleep(string place)
        {
            Console.WriteLine(@"主人正在{0}睡觉！", place);
        }

        public void Wakeup(string content)
        {
            Console.WriteLine(@"猫叫了声：{0},主人惊醒了！", content);
        }
    }
}