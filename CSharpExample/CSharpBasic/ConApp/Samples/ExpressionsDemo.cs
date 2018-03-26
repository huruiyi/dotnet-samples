using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ConApp
{
    internal class ExpressionsDemo
    {
        public class Foobar
        {
            public int IntVal { get; set; }

            public string StringVal { get; set; }

            public void Invoke()
            {
                Console.WriteLine("public void Invoke().............");
            }
        }

        public static Foobar Target { get; private set; }

        public static MethodInfo Method { get; private set; }

        public static Action<Foobar> Executor { get; private set; }

        private static Action<Foobar> CreateExecutor(MethodInfo method)
        {
            ParameterExpression target = Expression.Parameter(typeof(Foobar), "target");
            Expression expression = Expression.Call(target, method);
            return Expression.Lambda<Action<Foobar>>(expression, target).Compile();
        }

        static ExpressionsDemo()
        {
            Target = new Foobar();
            Method = typeof(Foobar).GetMethod("Invoke");
            Executor = CreateExecutor(Method);
        }

        private static void ExpressionDemo1(int times)
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

        public static void ExpressionDemo2()
        {
            string idField = ((MemberExpression)((Expression<Func<Foobar, int>>)(c => c.IntVal)).Body).Member.Name;
            string textField = ((MemberExpression)((Expression<Func<Foobar, string>>)(c => c.StringVal)).Body).Member.Name;
        }
    }
}