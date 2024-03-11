using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Net.Tools
{
    public static class Extensions
    {
        public static int ToInt(this string number)
        {
            return Int32.Parse(number);
        }

        public static string DoubleToDollars(this double number)
        {
            return $"{number:c}";
        }

        public static string IntToDollars(this int number)
        {
            return $"{number:c}";
        }
    }

    public static class ConvertHelper
    {
        public static T ToObject<T>(this DataRow row) where T : class, new()
        {
            T obj = new T();
            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                try
                {
                    if (prop.PropertyType.IsGenericType && prop.PropertyType.Name.Contains("Nullable"))
                    {
                        if (!string.IsNullOrEmpty(row[prop.Name].ToString()))
                        {
                            prop.SetValue(obj, Convert.ChangeType(row[prop.Name], Nullable.GetUnderlyingType(prop.PropertyType), null));
                        }
                    }
                    else
                    {
                        prop.SetValue(obj, Convert.ChangeType(row[prop.Name], prop.PropertyType), null);
                    }
                }
                catch
                {
                    continue;
                }
            }
            return obj;
        }

        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();
                foreach (var row in table.AsEnumerable())
                {
                    var obj = row.ToObject<T>();
                    list.Add(obj);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}