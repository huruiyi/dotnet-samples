using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;

namespace ExpressionTest
{
    public class ExpressionTest
    {
        public static Foobar Target { get; private set; }

        public static MethodInfo Method { get; private set; }

        public static Action<Foobar> Executor { get; private set; }

        private static Action<Foobar> CreateExecutor(MethodInfo method)
        {
            ParameterExpression target = Expression.Parameter(typeof(Foobar), "target");
            Expression expression = Expression.Call(target, method);
            return Expression.Lambda<Action<Foobar>>(expression, target).Compile();
        }

        static ExpressionTest()
        {
            Target = new Foobar();
            Method = typeof(Foobar).GetMethod("Invoke");
            Executor = CreateExecutor(Method);
        }

        public static void Main()
        {
            // 取得本机名称
            string strHostName = Dns.GetHostName();
            // 取得本机的IpHostEntry类别实体，用这个会提示已过时
            //IPHostEntry iphostentry = Dns.GetHostByName(strHostName);

            // 取得本机的IpHostEntry类别实体，MSDN建议新的用法 www.it165.net
            IPHostEntry iphostentry = Dns.GetHostEntry(strHostName);

            // 取得所有 IP 地址
            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                // 只取得IP V4的Address
                if (ipaddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    Console.WriteLine("Local IP: " + ipaddress.ToString());
                }
            }

            Console.WriteLine("ExpressionTest");
            Console.ReadKey();
        }

        private static void Test(int times)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i < times; i++)
            {
                Method.Invoke(Target, new object[0]);
            }
            long elapsed1 = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            for (int i = 0; i < times; i++)
            {
                Executor(Target);
            }
            long elapsed2 = stopwatch.ElapsedMilliseconds;

            Console.WriteLine("{0,-10}{1,-12}{2}", times, elapsed1, elapsed2);
        }
    }
}