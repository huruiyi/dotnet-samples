using ServiceStack.Redis;

namespace Fairy.Redis
{
    internal class Program
    {
        static void Main()
        {
            var manager = new RedisManagerPool("localhost:6379");

            using (var redis = manager.GetClient())
            {
                for (int i = 0; i < 100000; i++)
                {
                    redis.Set("count", i.ToString().PadLeft(6, '0'));
                }
            }
            Console.WriteLine("Hello, World!");
        }
    }
}
