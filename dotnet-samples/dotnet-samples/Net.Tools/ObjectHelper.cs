using System;
using System.Reflection;

namespace Net.Tools
{
    public static class ObjectHelper
    {
        public static T NullablePatch<T>(this T obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo item in props)
            {
                if (item.PropertyType.FullName == "System.String")
                {
                    if (item.CanWrite)
                    {
                        Object val = item.GetValue(obj, null);
                        if (val == null)
                        {
                            item.SetValue(obj, "", null);
                        }
                    }
                }
            }
            return obj;
        }
    }
}