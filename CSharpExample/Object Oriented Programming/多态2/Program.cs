using System;

namespace 多态2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region 继承

            MobileStorage mp3 = new Mp3();
            mp3.Read();
            mp3.Write();
            Mp3 m = mp3 as Mp3;
            m.Playmusic();

            MobileStorage fd = new FlashDish();
            fd.Read();
            fd.Write();

            #endregion 继承

            Console.WriteLine();

            Computer cm = new Computer(new Mp3());
            cm.cRead();
            cm.cWrite();
            Mp3 m3 = cm.Storage as Mp3;
            if (m3 != null)
            {
                m3.Playmusic();
            }

            Computer cf = new Computer(new FlashDish());
            cf.cRead();
            cf.cWrite();

            Console.WriteLine();
            MobileStorage[] cs = { new Mp3(), new FlashDish() };
            foreach (MobileStorage item in cs)
            {
                item.Write();
                item.Read();
            }

            Console.ReadKey();
        }
    }
}