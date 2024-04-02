using System;

namespace 抽象工厂模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            User user = new User();
            //AbstractFactory factory = new SqlServerFactory();
            IFactory factory = new AccessFactory();

            IUser iu = factory.CreateUser();

            iu.Insert(user);
            iu.GetUser(1);

            Console.Read();
        }
    }

    internal class User
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }

    internal interface IUser
    {
        void Insert(User user);

        User GetUser(int id);
    }

    internal class SqlserverUser : IUser
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

    internal class AccessUser : IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("在Access中给User表增加一条记录");
        }

        public User GetUser(int id)
        {
            Console.WriteLine("在Access中根据ID得到User表一条记录");
            return null;
        }
    }

    internal interface IFactory
    {
        IUser CreateUser();
    }

    internal class SqlServerFactory : IFactory
    {
        public IUser CreateUser()
        {
            return new SqlserverUser();
        }
    }

    internal class AccessFactory : IFactory
    {
        public IUser CreateUser()
        {
            return new AccessUser();
        }
    }
}