using System;

namespace IOCblog
{
    public class Container
    {
        public IPerson GetApplication(String typeName)
        {
            return (IPerson)Activator.CreateInstance(Type.GetType(typeName));
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            //调用son
            Father fa = new Father("IOCblog.Son");
            fa.Operation();

            //调用daughter
            fa = new Father("IOCblog.Daughter");
            fa.Operation();

            Console.ReadKey();
        }
    }
}