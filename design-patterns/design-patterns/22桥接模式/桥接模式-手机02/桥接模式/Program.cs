using System;

namespace 桥接模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HandsetSoft ab;
            ab = new HandsetBrandMGame();
            ab.Run();

            ab = new HandsetBrandNGame();
            ab.Run();

            ab = new HandsetBrandMAddressList();
            ab.Run();

            ab = new HandsetBrandNAddressList();
            ab.Run();

            Console.Read();
        }
    }

    //手机软件
    internal class HandsetSoft
    {
        public virtual void Run()
        {
        }
    }

    //通讯录
    internal class HandsetAddressList : HandsetSoft
    {
    }

    //游戏
    internal class HandsetGame : HandsetSoft
    {
    }

    //手机品牌M的游戏
    internal class HandsetBrandMGame : HandsetGame
    {
        public override void Run()
        {
            Console.WriteLine("运行M品牌手机游戏");
        }
    }

    //手机品牌N的游戏
    internal class HandsetBrandNGame : HandsetGame
    {
        public override void Run()
        {
            Console.WriteLine("运行N品牌手机游戏");
        }
    }

    //手机品牌M的通讯录
    internal class HandsetBrandMAddressList : HandsetAddressList
    {
        public override void Run()
        {
            Console.WriteLine("运行M品牌手机通讯录");
        }
    }

    //手机品牌N的通讯录
    internal class HandsetBrandNAddressList : HandsetAddressList
    {
        public override void Run()
        {
            Console.WriteLine("运行N品牌手机通讯录");
        }
    }
}