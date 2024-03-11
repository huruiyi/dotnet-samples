using StackExchange.Redis;
using System;
using System.Threading;

namespace ConApp.Samples.NoSql
{
    public class RPerson
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Hobby { get; set; }

        public RPerson(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public RPerson(string name, int age, string hobby)
        {
            this.Name = name;
            this.Age = age;
            this.Hobby = hobby;
        }

        public override string ToString()
        {
            return string.Format("Name={0},Age={1}", this.Name, this.Age);
        }

        public void ShowInfo()
        {
            Console.WriteLine(this.ToString());
        }
    }

    public class RedisDemo
    {
        public static ConnectionMultiplexer connection { get; set; }

        public static IDatabase client { get; protected set; }

        static RedisDemo()
        {
            connection = ConnectionMultiplexer.Connect("localhost");
            client = connection.GetDatabase();
        }




        #region String

        public static void StringDemo1_Get_Set_Append()
        {
            string value = "abcdefg";
            client.StringSet("a", value);
            Console.WriteLine(client.StringGet("a"));

            client.StringAppend("a", "hijklmn");
            Console.WriteLine(client.StringGet("a"));

            client.StringAppendAsync("a", "opqrst");
            Console.WriteLine(client.StringGet("a"));

            client.StringAppendAsync("a", "uvwxyz");

            Console.WriteLine(client.StringBitCount("a"));
        }

        public static void String_Inccre_Decre()
        {
            RedisValue oldValue = client.StringGetSet("a", "1234567890");
            Console.WriteLine(oldValue);
            Console.WriteLine(client.StringGet("a"));
        }

        public static void String_Incre_Decre()
        {
            client.StringSet("number", 1);
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                client.StringDecrement("number");
            }
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(1000);
                client.StringIncrement("number");
            }
        }

        #endregion String

        #region List

        public static int ListCount = 20;

        //队列
        public static void ListDemo_LPush_RPop()
        {
            Console.WriteLine("ListDemo_LPush_RPop");
            for (int i = 0; i < ListCount; i++)
            {
                client.ListLeftPush("list", i);
            }
            for (int i = 0; i < ListCount; i++)
            {
                RedisValue val = client.ListRightPop("list");
                Console.Write(val + " ");
            }
            Console.WriteLine();
        }

        //队列
        public static void ListDemo_RPush_LPop()
        {
            Console.WriteLine("ListDemo_RPush_LPop");
            for (int i = 0; i < ListCount; i++)
            {
                client.ListRightPush("rlist", i);
            }
            for (int i = 0; i < ListCount; i++)
            {
                RedisValue val = client.ListLeftPop("rlist");
                Console.Write(val + " ");
            }
            Console.WriteLine();
        }

        //栈
        public static void ListDemo_LPush_LPop()
        {
            Console.WriteLine("ListDemo_LPush_LPop");
            for (int i = 0; i < ListCount; i++)
            {
                client.ListLeftPush("list", i);
            }
            for (int i = 0; i < ListCount; i++)
            {
                RedisValue val = client.ListLeftPop("list");
                Console.Write(val + " ");
            }
            Console.WriteLine();
        }

        //栈
        public static void ListDemo_RPush_RPop()
        {
            Console.WriteLine("ListDemo_RPush_RPop");
            for (int i = 0; i < ListCount; i++)
            {
                client.ListRightPush("rlist", i);
            }
            for (int i = 0; i < ListCount; i++)
            {
                RedisValue val = client.ListRightPop("rlist");
                Console.Write(val + " ");
            }
            Console.WriteLine();
        }

        public static void ListDemo_()
        {
            for (int i = 1; i <= 20; i++)
            {
                client.ListLeftPush("list", i);
                //rDb.ListRightPush("list", i);
                client.ListLeftPushAsync("list", i);
            }
            Console.WriteLine(client.ListGetByIndex("list", 6));
        }

        #endregion List




        public static void Queen1()
        {
            client.ListLeftPush("list", System.Text.Encoding.UTF8.GetBytes("AAA"));
            client.ListLeftPush("list", System.Text.Encoding.UTF8.GetBytes("BBBB"));
            client.ListLeftPush("list", System.Text.Encoding.UTF8.GetBytes("CCCCC"));
            client.ListLeftPush("list", System.Text.Encoding.UTF8.GetBytes("DDDDDD"));

            while (client.ListLength("list") > 0)
            {
                byte[] value = client.ListRightPop("list");
                Console.WriteLine(System.Text.Encoding.UTF8.GetString(value));
            }
        }

        public static void Queen2()
        {
            client.ListRightPush("list", System.Text.Encoding.UTF8.GetBytes("AAA"));
            client.ListRightPush("list", System.Text.Encoding.UTF8.GetBytes("BBBB"));
            client.ListRightPush("list", System.Text.Encoding.UTF8.GetBytes("CCCCC"));
            client.ListRightPush("list", System.Text.Encoding.UTF8.GetBytes("DDDDDD"));

            while (client.ListLength("list") > 0)
            {
                byte[] value = client.ListLeftPop("list");
                Console.WriteLine(System.Text.Encoding.UTF8.GetString(value));
            }
        }

        public static void SetDemo()
        {
            client.SetAdd("setid", "4");
            client.SetAdd("setid", "5");
            client.SetAdd("setid", "1");
            client.SetAdd("setid", "2");
            client.SetAdd("setid", "4");
            client.SetAdd("setid", "3");
            client.SetAdd("setid", "4");
            client.SetAdd("setid", "5");
            RedisValue[] redisValue = client.SetMembers("setid");
            for (int i = 0; i < redisValue.Length; i++)
            {
                Console.WriteLine(redisValue.GetValue(i).ToString());
            }
        }

        public static void ZAddDemo()
        {
            SortedSetEntry[] sortedSet = new SortedSetEntry[]
            {
                new SortedSetEntry("小红", 20),
                new SortedSetEntry("小黑", 20),
                new SortedSetEntry("小白", 20),
                new SortedSetEntry("小青", 20)
            };
            //成绩排名:
            client.SortedSetAdd("score", sortedSet);
        }

        public static void HSetGetDemo()
        {
            RPerson p1 = new RPerson("小明", 25, "足球");
            RPerson p2 = new RPerson("小南", 35, "保龄球");
            RPerson p3 = new RPerson("小明", 30, "棒球");

            client.HashSet("p1", System.Text.Encoding.UTF8.GetBytes("姓名"), System.Text.Encoding.UTF8.GetBytes(p1.Name));
            client.HashSet("p1", System.Text.Encoding.UTF8.GetBytes("年龄"), System.Text.Encoding.UTF8.GetBytes(p1.Age.ToString()));
            client.HashSet("p1", System.Text.Encoding.UTF8.GetBytes("爱好"), System.Text.Encoding.UTF8.GetBytes(p1.Hobby));

            client.HashSet("p2", System.Text.Encoding.UTF8.GetBytes("姓名"), System.Text.Encoding.UTF8.GetBytes(p2.Name));
            client.HashSet("p2", System.Text.Encoding.UTF8.GetBytes("年龄"), System.Text.Encoding.UTF8.GetBytes(p2.Age.ToString()));
            client.HashSet("p2", System.Text.Encoding.UTF8.GetBytes("爱好"), System.Text.Encoding.UTF8.GetBytes(p2.Hobby));

            client.HashSet("p3", System.Text.Encoding.UTF8.GetBytes("姓名"), System.Text.Encoding.UTF8.GetBytes(p3.Name));
            client.HashSet("p3", System.Text.Encoding.UTF8.GetBytes("年龄"), System.Text.Encoding.UTF8.GetBytes(p3.Age.ToString()));
            client.HashSet("p3", System.Text.Encoding.UTF8.GetBytes("爱好"), System.Text.Encoding.UTF8.GetBytes(p3.Hobby));

            client.HashSet("p4", System.Text.Encoding.UTF8.GetBytes("姓名"), System.Text.Encoding.UTF8.GetBytes(p3.Name));
            client.HashSet("p4", System.Text.Encoding.UTF8.GetBytes("年龄"), System.Text.Encoding.UTF8.GetBytes(p3.Age.ToString()));
            client.HashSet("p4", System.Text.Encoding.UTF8.GetBytes("爱好"), System.Text.Encoding.UTF8.GetBytes(p3.Hobby));

            long length1 = client.HashLength("p1");

            RedisValue[] pList = client.HashKeys("p1");

            Console.WriteLine();

            byte[] name = client.HashGet("p2", System.Text.Encoding.UTF8.GetBytes("姓名"));
            Console.Write(System.Text.Encoding.UTF8.GetString(name));

            byte[] age = client.HashGet("p2", System.Text.Encoding.UTF8.GetBytes("年龄"));
            Console.Write(System.Text.Encoding.UTF8.GetString(age));

            byte[] hobby = client.HashGet("p2", System.Text.Encoding.UTF8.GetBytes("爱好"));
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(hobby));
        }

        public static void SortedSetDemo()
        {
            client.SortedSetAdd("12", "百度", 400);
            client.SortedSetAdd("12", "谷歌", 300);
            client.SortedSetAdd("12", "阿里", 200);
            client.SortedSetAdd("12", "新浪", 100);
            client.SortedSetAdd("12", "人人", 500);

            long length = client.SortedSetLength("12");
            for (int i = 0; i < length; i++)
            {
            }
        }
    }
}