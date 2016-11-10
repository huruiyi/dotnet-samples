using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegateDemo
{
    internal class Common
    {
        public delegate bool IntFilter(int i);

        public static List<int> FilterListOfInt(int[] ints, IntFilter filter)
        {
            List<int> alist = new List<int>();
            foreach (int i in ints)
            {
                if (filter(i))
                {
                    alist.Add(i);
                }
            }
            return alist;
        }
    }

    internal class OddEven
    {
        //是奇数
        public static bool IsOdd(int i)
        {
            return (i & 1) == 1;
        }

        //是偶数
        public static bool IsEven(int i)
        {
            return (i & 1) == 0;
        }
    }

    internal class DelegateDemo4 : IDelegateDemo
    {
        internal delegate bool D1();

        internal delegate bool D2(int i);

        internal delegate string Mul(int a);

        private D1 _del1;
        private D2 _del2;

        public void TestMethod(int input)
        {
            int j = 0;
            _del1 = () => { j = 10; return j > input; };
            _del2 = x => x == j;
            Console.WriteLine("j = {0}", j);
            bool boolResult = _del1();
            Console.WriteLine("j = {0}. b = {1}", j, boolResult);
        }

        private static string MulMethod(int i)
        {
            return "你输入的是:" + i;
        }

        private static bool M1(int a)
        {
            if (a >= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Invoke()
        {
            //委托就是方法的容器
            //委托的参数类型与返回值类型(即委托的签名)应该与其所对应方法的签名一致
            //Lambda表达式中"=>"左边应该包含委托所对应参数类型,右边包含委托的返回值类型

            Mul mul0 = b => (string.Format("{0}的平方是{1}", b, b * b));
            // Mul mul0 = (int b) => (string.Format("{0}的平方是{1}", b, b * b));
            Console.WriteLine(mul0(8));
            Console.WriteLine();

            Mul mul1 = a => ("你输入的是一个整数");
            //Mul mul1 =(int a) => ("你输入的是一个整数");
            Console.WriteLine(mul1(12));
            Console.WriteLine();

            Mul mul2 = MulMethod;
            Console.WriteLine(mul2(12));
            Console.WriteLine();

            DelegateDemo4 test = new DelegateDemo4();
            test.TestMethod(5);
            bool result = test._del2(10);
            Console.WriteLine(result);

            Func<int, bool> myFunc = x => x == 5;
            bool r = myFunc(4); // returns false of course

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 4, 5, 6, 7 };

            //int oddNumbers = numbers.Count(n => n % 2 == 1);
            //Console.WriteLine("奇数个数为:" + oddNumbers);
            int eveNumbers = numbers.Count(n => n % 2 == 0);
            Console.WriteLine("偶数个数为:" + eveNumbers);

            //Func<int, bool> pre = M1;
            //int result5 = numbers.Count(pre);
            //Console.WriteLine("大于等于5的个数:" + result5);

            //IEnumerable<int> arr = numbers.Distinct();
            //foreach (int i in arr)
            //{
            //    Console.Write(i + " ");
            //}

            int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> evenOdd = Common.FilterListOfInt(ints, OddEven.IsOdd);

            List<int> evenInt = Common.FilterListOfInt(ints, OddEven.IsEven);

            //>5
            List<int> intgt5 = Common.FilterListOfInt(ints, i => i > 5);

            //=3
            List<int> intequal3 = Common.FilterListOfInt(ints, i => i == 3);
        }
    }
}