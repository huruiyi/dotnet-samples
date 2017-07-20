using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
    class Program
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

        static Program()
        {
            Target = new Foobar();
            Method = typeof(Foobar).GetMethod("Invoke");
            Executor = CreateExecutor(Method);
        }
        static void Main(string[] args)
        {
            Test(10);
            Console.ReadKey();
        }

        private static void Test(int times)
        {
            Console.WriteLine("{0,-10}{1,-12}{2}", times, 123, 456);

            for (int i = 0; i < times; i++)
            {
                Method.Invoke(Target, new object[0] { });
            }

            Console.WriteLine();
            for (int i = 0; i < times; i++)
            {
                Executor(Target);
            }
        }
    }
}
