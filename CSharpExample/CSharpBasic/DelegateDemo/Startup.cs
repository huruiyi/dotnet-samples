using System;
using System.Collections.Generic;
using System.Reflection;

namespace DelegateDemo
{
    public static class Startup
    {
        public static int ConvertToInt(this object val, int defaultValue)
        {
            int result;
            int num;
            if (val == null || val == DBNull.Value)
            {
                result = defaultValue;
            }
            else if (val is int)
            {
                result = (int)val;
            }
            else if (!int.TryParse(val.ToString(), out num))
            {
                double value;
                if (double.TryParse(val.ToString(), out value))
                {
                    result = (int)Math.Round(value, 0, MidpointRounding.AwayFromZero);
                }
                else
                {
                    result = defaultValue;
                }
            }
            else
            {
                result = num;
            }
            return result;
        }

        private static void Main(string[] args)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Type[] types = asm.GetTypes();

            IDictionary<int, Type> typeMap = new Dictionary<int, Type>();
            int counter = 1;

            foreach (Type t in types)
            {
                if (new List<Type>(t.GetInterfaces()).Contains(typeof(IDelegateDemo)))
                {
                    typeMap.Add(counter++, t);
                }
            }

            foreach (KeyValuePair<int, Type> keyValuePair in typeMap)
            {
                Console.WriteLine("{0}:{1}", keyValuePair.Key.ToString().PadLeft(2, '0'), keyValuePair.Value.Name);
            }
            Console.WriteLine("请输入编号执行");
            string strNum = Console.ReadLine();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            IDelegateDemo demo = Activator.CreateInstance(typeMap[strNum.ConvertToInt(1)]) as IDelegateDemo;
            demo.Invoke();

            //foreach (Type s in typeList)
            //{
            //    Console.WriteLine(s.FullName);
            //    IDelegateDemo item = Activator.CreateInstance(s) as IDelegateDemo;
            //    item.Invoke();
            //    Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            //}
            Console.ReadKey();
        }
    }
}