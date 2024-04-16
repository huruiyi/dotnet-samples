using System;
using System.Collections.Generic;

namespace ConApp.Samples
{
    public static class ListExt
    {
        //扩展方法三要素：  静态类型，静态方法，this关键字。
        public delegate bool MyPreDel<T>(T text);

        public static void ToConsole(this string toWrite)
        {
            Console.WriteLine(toWrite);
        }

        //扩展方法要求第一个参数必须使用this标识，this后面的类型就是要扩展的类型。this后面类型实例就是咱们扩展方法调用者。
        public static List<T> MyFindAll<T>(this List<T> list, MyPreDel<T> del)
        {
            List<T> result = new List<T>();
            foreach (var item in list)
            {
                if (del(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
