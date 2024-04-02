using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fairy.ConApp.Test
{
    public class RedisTest
    {
        public static void Test()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            IDatabase database = redis.GetDatabase();
            for (int a = 0; a < 10000; a++)
            {
                database.StringSet("name" + a, "huruiyi：" + a);
            }
            Console.WriteLine("Hello, World!");
        }
    }
}
