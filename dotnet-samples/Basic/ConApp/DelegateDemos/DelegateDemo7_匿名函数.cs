using System;

namespace ConApp.DelegateDemos
{
    internal class DelegateDemo7_匿名函数 : IDelegateDemo
    {
        private delegate string DelString(string str);

        private delegate int DelMath(int a, int b);

        private static int Test(DelMath del)
        {
            return del(5, 6);
        }

        private static int Add(int a, int b)
        {
            return a + b;
        }

        private static int Sub(int a, int b)
        {
            return a - b;
        }

        private static string ToUpper(string str)
        {
            return str.ToUpper();
        }

        private static string ToLower(string str)
        {
            return str.ToLower();
        }

        private static void StringProcess(string[] arr, DelString del)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = del(arr[i]);
            }
            foreach (string item in arr)
            {
                Console.WriteLine(item);
            }
        }

        public void Invoke()
        {
            ////定义委托，让委托指向方法
            DelMath del0 = new DelMath(Add);
            DelMath del = Add;
            Console.WriteLine(Test(del));

            //一个匿名委托的定义如下:
            DelMath m1 = new DelMath(delegate (int a, int b) { return a * b; });

            DelMath m2 = delegate (int a, int b) { return a + b; };

            DelMath m3 = (int i1, int i2) => (i1 + i2);

            DelMath m4 = (a, b) => a + b;

            string[] arr = { "DsDSd", "DSfdsdaDA", "dsaDSDSA", "FDFsdfsg" };
            DelString delTrans = ToLower;
            StringProcess(arr, delTrans);

            string[] arr1 = { "sas", "sasfff", "hfgh" };
            delTrans = ToUpper;
            StringProcess(arr1, delTrans);
        }
    }
}