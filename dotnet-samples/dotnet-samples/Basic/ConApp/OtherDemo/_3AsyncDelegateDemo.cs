using System;

namespace ConApp.OtherDemo
{
    internal class _3AsyncDelegateDemo
    {
        private static void Main03(string[] args)
        {
            MethodA();
            Console.ReadKey();
        }

        private static void MethodA()
        {
            Console.WriteLine("Method A Execution Started");
            Call("Call from Method A");
            MethodB();
            Console.WriteLine("Method A completed");
        }

        private static void MethodB()
        {
            Console.WriteLine("Inside Method B");
        }

        private delegate void MethodDelegate(string message);

        public static void Call(string message)
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