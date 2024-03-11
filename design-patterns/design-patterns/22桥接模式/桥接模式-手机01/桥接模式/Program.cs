using System;

namespace 桥接模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HandsetBrand ab;
            ab = new HandsetBrandMAddressList();
            ab.Run();

            ab = new HandsetBrandMGame();
            ab.Run();

            ab = new HandsetBrandNAddressList();
            ab.Run();

            ab = new HandsetBrandNGame();
            ab.Run();

            Console.Read();
        }
    }

    //手机品牌
    internal class HandsetBrand
    {
        public virtual void Run()
        {
        }
    }

    //手机品牌M
    internal class HandsetBrandM : HandsetBrand
    {
    }

    //手机品牌N
    internal class HandsetBrandN : HandsetBrand
    {
    }

    //手机品牌M的游戏
    internal class HandsetBrandMGame : HandsetBrandM
    {
        public override void Run()
        {
            Console.WriteLine("运行M品牌手机游戏");
        }
    }

    //手机品牌N的游戏
    internal class HandsetBrandNGame : HandsetBrandN
    {
        public override void Run()
        {
            Console.WriteLine("运行N品牌手机游戏");
        }
    }

    //手机品牌M的通讯录
    internal class HandsetBrandMAddressList : HandsetBrandM
    {
        public override void Run()
        {
            Console.WriteLine("运行M品牌手机通讯录");
        }
    }

    //手机品牌N的通讯录
    internal class HandsetBrandNAddressList : HandsetBrandN
    {
        public override void Run()
        {
            Console.WriteLine("运行N品牌手机通讯录");
        }
    }
}