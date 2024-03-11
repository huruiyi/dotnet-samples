using System;

namespace 抽象工厂模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            User user = new User();

            SqlserverUser su = new SqlserverUser();
            su.Insert(user);
            su.GetUser(1);

            Console.Read();
        }
    }

    internal class User
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }

    internal class SqlserverUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("在Sqlserver中给User表增加一条记录");
        }

        public User GetUser(int id)
        {
            Console.WriteLine("在Sqlserver中根据ID得到User表一条记录");
            return null;
        }
    }
}