using System;
using System.Collections.Generic;

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
    }
}