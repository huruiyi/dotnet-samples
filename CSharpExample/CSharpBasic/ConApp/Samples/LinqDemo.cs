using System;
using System.Collections.Generic;
using System.Linq;

namespace System.Collections.Generic
{
    public delegate bool IsOkDel<in T>(T ojb);

    // 扩展方法：静态类、静态方法、this
    public static class MyListExt
    {
        //this后面紧跟的类型，就是将当前扩展方法凭空加到类型上去
        //方法名字后面紧跟的泛型约束是最主要的。
        public static List<T> MyFindStrs<T>(this List<T> list, IsOkDel<T> del)
        {
            List<T> result = new List<T>();

            foreach (var item in list)
            {
                //调用传过来的委托，执行  过滤
                if (del(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}

namespace ConApp.Samples
{
    public class LinqDemo
    {
        public static bool MyCalc(string str)
        {
            if (int.Parse(str) >= 2)
            {
                return true;
            }
            return false;
        }

        public static void CusMethod()
        {
            #region 扩展方法

            //在list上添加一个方法，传一个委托到一个方法，满足当前委托条件的变量都给取出来
            List<string> list = new List<string>()
            {
                "1",
                "2",
                "3",
                "4"
            };
            //自己内部模拟的写法
            var temp1 = list.MyFindStrs(MyCalc);
            foreach (var item in temp1)
            {
                Console.WriteLine(item);
            }

            //普通写法
            var temp2 = list.FindAll(MyCalc);

            foreach (var item in temp2)
            {
                Console.WriteLine(item);
            }

            var temp3 = list.FindAll(a => int.Parse(a) >= 2);

            foreach (var item in temp3)
            {
                Console.WriteLine(item);
            }

            #endregion 扩展方法
        }

        public static void LambaExpressions()
        {
            string[] names = { "John", "Paul", "George", "Ringo" };
            var name = names.Select(s => s.StartsWith("P"));

            int[] numbers = { 1, 20, 15, 35, 42, 18, 99 };
            var nums = numbers.OrderBy(x => x);
            var numsReverse = numbers.OrderBy(x => x).Reverse();
        }

        public static void CurrentCamp()
        {
            string[] camps = { "Code Camp 2007", "Code Camp 2008", "Code Camp 2009" };
            var currentCamp = from camp in camps
                              where camp.EndsWith(DateTime.Now.Year.ToString())
                              select camp;

            // These are all equivalent
            string currentCamp2 = camps.Where(c => c.EndsWith(DateTime.Now.Year.ToString())).Single();
            string currentCamp3 = camps.Single(c => c.EndsWith(DateTime.Now.Year.ToString()));
            string currentCamp4 = camps.Select(c => c).Where(c => c.EndsWith(DateTime.Now.Year.ToString())).Single();
        }

        public static void LambaExpressionsWithDelegates()
        {
            Func<string, bool> pOnly = delegate (string s)
            {
                return s.StartsWith("P");
            };
            string[] names = { "John", "Paul", "George", "Ringo" };

            var name1 = names.Select(pOnly);

            string name2 = names.Single(s => s.StartsWith("P"));
            string name3 = names.Single(pOnly);
        }
    }
}