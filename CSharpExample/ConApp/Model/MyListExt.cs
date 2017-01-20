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