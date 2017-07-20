using System;

namespace 多态.Storage
{
    internal class FlashDish : MobileStorage
    {
        public override void Read()
        {
            Console.WriteLine(" U盘 Read");
        }

        public override void Write()
        {
            Console.WriteLine("U盘 Write");
        }
    }
}