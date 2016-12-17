using System;

namespace 多态.SampleStorage
{
    internal class Mp3 : MobileStorage
    {
        public override void Read()
        {
            Console.WriteLine("Mp3 Read");
        }

        public override void Write()
        {
            Console.WriteLine("Mp3 Write");
        }

        public void Playmusic()
        {
            Console.WriteLine("播放音乐");
        }
    }
}