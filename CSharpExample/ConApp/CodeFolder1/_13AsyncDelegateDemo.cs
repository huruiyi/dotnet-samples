using System;

namespace ConApp.CodeFolder1
{
    internal class Program
    {
        private static void Main13()
        {
            MethodA();
            Console.ReadKey();
        }

        private static void MethodA()
        {
            Console.WriteLine("Method A Execution Started");
            DemoAsyncMethodCall.Capture("Call from Method A");
            MethodB();
            Console.WriteLine("Method A completed");
        }

        private static void MethodB()
        {
            Console.WriteLine("Inside Method B");
        }
    }

    public class DemoAsyncMethodCall
    {
        private delegate void MethodDelegate(string message);

        public static void Capture(string message)
        {
            var dlgt = new MethodDelegate(SaveData);
            IAsyncResult ar = dlgt.BeginInvoke(message, null, null);
        }

        private static void SaveData(string message)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i.ToString().PadLeft(3, '0') + "" + ":Aync method call saveData with message: " + message);
            }
        }
    }
}