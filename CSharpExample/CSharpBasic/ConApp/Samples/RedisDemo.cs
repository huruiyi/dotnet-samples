using ServiceStack.Redis;
using System;
using System.Collections.Generic;

namespace ConApp
{
    public class RPerson
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public RPerson(string name, int age)
        {
            this.Name = name;
            this.Age = age;
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

    internal class RedisDemo
    {
        public const string IP = "127.0.0.1";
        public const int Port = 6379;
        public static RedisClient client { get; set; }

        static RedisDemo()
        {
            client = new RedisClient("127.0.0.1", 6379);
        }

        public static void SetDemo()
        {
            client.AddItemToSet("setid", "4");
            client.AddItemToSet("setid", "5");
            client.AddItemToSet("setid", "1");
            client.AddItemToSet("setid", "2");
            client.AddItemToSet("setid", "4");
            client.AddItemToSet("setid", "3");
            client.AddItemToSet("setid", "4");
            client.AddItemToSet("setid", "5");
            HashSet<string> hashSet = client.GetAllItemsFromSet("setid");
            Console.WriteLine(client.GetSetCount("setid"));
        }

        public static void ListDequeueDemo()
        {
            //队列，先进先出
            //client.DequeueItemFromList()
            //client.EnqueueItemOnList();
            client.EnqueueItemOnList("q1", "北京3");
            client.EnqueueItemOnList("q1", "北京4");
            client.EnqueueItemOnList("q1", "北京1");
            client.EnqueueItemOnList("q1", "北京2");
            for (int i = 0; i < client.GetListCount("q1"); i++)
            {
                Console.WriteLine(client.DequeueItemFromList("q1"));
            }
        }

        public static void ListPopDemo()
        {
            //   栈，先进后出
            //client.PopItemFromList();
            //client.PushItemToList();
            client.PushItemToList("z1", "北1");
            client.PushItemToList("z1", "北2");
            client.PushItemToList("z1", "北3");
            client.PushItemToList("z1", "北4");
            client.PushItemToList("z1", "北5");
            client.PushItemToList("z1", "北6");

            for (int i = 0; i < client.GetListCount("z1"); i++)
            {
                Console.WriteLine(client.PopItemFromList("z1"));
            }
        }

        public static void ListDeomo()
        {
            client.AddItemToList("shopId", "123");
            client.AddItemToList("shopId", "456");
            client.AddItemToList("shopId", "789");
            client.AddItemToList("shopId", "147");
            client.AddItemToList("shopId", "258");
            client.AddItemToList("shopId", "369");

            Console.WriteLine(client.GetListCount("shopId"));
            client.AddRangeToList("rangeID", new List<string> { "6", "7", "8", "9", "10" });
            client.AddRangeToList("rangeID", new List<string> { "1", "2", "3", "4", "5" });
            List<string> listRangeList = client.GetRangeFromList("rangeID", 1, 6);
            List<string> allItems = client.GetAllItemsFromList("rangeID");
            Console.WriteLine(client.GetListCount("rangeID"));
        }

        public static void SortedSetDemo()
        {
            //最后一个参数为我们排序的依据
            client.AddItemToSortedSet("12", "百度", 400);
            client.AddItemToSortedSet("12", "谷歌", 300);
            client.AddItemToSortedSet("12", "阿里", 200);
            client.AddItemToSortedSet("12", "新浪", 100);
            client.AddItemToSortedSet("12", "人人", 500);

            //升序获取最一个值:"新浪"
            var list = client.GetRangeFromSortedSet("12", 0, 4);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            //降序获取最一个值:"人人"
            list = client.GetRangeFromSortedSetDesc("12", 0, 4);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public static void GetSetDemo()
        {
            client.Set("a", "123");
            client.Set("b", "456");
            client.Set("c", "789", DateTime.Now.AddSeconds(10));//设置超时时间

            Console.WriteLine(client.Get<string>("a"));
            Console.WriteLine(client.Get<string>("b"));
            Console.WriteLine(client.Get<string>("c"));

            RPerson p1 = new RPerson("P1", 25);
            RPerson p2 = new RPerson("P2", 25);
            RPerson p3 = new RPerson("P3", 25);

            client.Set<RPerson>("p1", p1);
            client.Set<RPerson>("p2", p2);
            client.Set<RPerson>("p3", p3);

            RPerson gp1 = client.Get<RPerson>("p1");
            gp1.ShowInfo();

            RPerson gp2 = client.Get<RPerson>("p2");
            gp2.ShowInfo();

            RPerson gp3 = client.Get<RPerson>("p3");
            gp3.ShowInfo();
        }
    }
}