using System;

namespace ConApp.Comparer
{
    public class App
    {
        public static void Run()
        {
            //https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.iequalitycomparer-1?view=netframework-4.8.1
            Data01 data1 = new Data01 { Id = 1, Name = "UserName" };
            Data02 data2 = new Data02 { Id = 1, Name = "UserName" };
            Console.WriteLine(data1.Equals(data2));
            Console.WriteLine(data1 == data2);

            EqualityComparer comparer = new EqualityComparer();
            User user1 = new User(1, "ni di");
            User user2 = new User(1, "ni di");
            Console.WriteLine(comparer.Equals(user1, user2));
        }
    }
}