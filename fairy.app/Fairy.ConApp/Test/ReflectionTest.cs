using Fairy.ConApp.Model;
using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.Remoting;

namespace Fairy.ConApp.Test
{
    public class ReflectionTest
    {
        public static string DllPath = @"E:\huruiyi\vs\ConsoleApp1\Fairy.Reflection\bin\Debug\Fairy.Reflection.dll";

        public static void Test1()
        {
            object obj = Assembly.LoadFrom(DllPath).CreateInstance("Fairy.Reflection.Person");

            Type type = obj?.GetType();

            type?.GetProperty("Name")?.SetValue(obj, "Gates", BindingFlags.SetProperty, null, null, CultureInfo.GetCultureInfo("zh-CN"));
            type?.GetProperty("Sex")?.SetValue(obj, "Male", BindingFlags.SetProperty, null, null, CultureInfo.GetCultureInfo("zh-CN"));
            type?.GetProperty("Hobby")?.SetValue(obj, "Play Computer", BindingFlags.SetProperty, null, null, CultureInfo.GetCultureInfo("zh-CN"));
            type?.InvokeMember("ShowInfo", BindingFlags.InvokeMethod, null, obj, null);

            //执行了一个静态方法
            object val1 = type?.InvokeMember("SayHi", BindingFlags.InvokeMethod, null, null, new object[] { "da ye" });
            Console.WriteLine(val1);

            //执行了一个非静态方法
            object val2 = type?.InvokeMember("SayHello", BindingFlags.InvokeMethod, null, obj, new object[] { "de de" });
            Console.WriteLine(val2);
            if (type != null)
            {
                object person = Activator.CreateInstance(type);
                Console.WriteLine(person.ToString());
                Console.Read();
            }
        }

        public static void Test2()
        {
            Assembly assembly = Assembly.LoadFrom(DllPath);
            Type type = assembly.GetType("Fairy.Reflection.Person", true, true);
            object obj = Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance, null, null, null, null);
        }

        public static void Test3()
        {
            ObjectHandle objectHandle = Activator.CreateInstanceFrom(DllPath, "Fairy.Reflection.Person");
            var obj = objectHandle.Unwrap();
            Type type = obj.GetType();
            MethodInfo method = type.GetMethod("SayHi");
            var val = method?.Invoke(obj, new object[] { "fuck" });
            Console.WriteLine(val);
        }

        public static void Test4()
        {
            var obj = Assembly.LoadFile(DllPath).CreateInstance("Fairy.Reflection.Person");
            Type type = obj?.GetType();
            if (type != null)
            {
                type.GetProperty("Name")?.SetValue(obj, "胡睿毅");
                type.GetProperty("Age")?.SetValue(obj, 23);
                type.GetProperty("Sex")?.SetValue(obj, "男");
            }

            MethodInfo m1 = type?.GetMethod("SayHi");
            if (m1 != null)
            {
                var val1 = m1.Invoke(obj, new object[] { "fuck" });
                Console.WriteLine(val1);
            }

            MethodInfo m2 = type?.GetMethod("ShowInfo");
            if (m2 != null)
            {
                var val2 = m2.Invoke(obj, new object[] { });
                Console.WriteLine(val2);
            }

            MethodInfo m3 = type?.GetMethod("SayHi");
            if (m3 != null)
            {
                var val3 = m3.Invoke(obj, new object[] { "da ye" });
                Console.WriteLine(val3);
            }
        }

        public static void Test5()
        {
            try
            {
                Binder defaultBinder = Type.DefaultBinder;
                MyClass myClass = new MyClass();
                // Invoke the HelloWorld method of MyClass.
                myClass.GetType().InvokeMember("HelloWorld", BindingFlags.InvokeMethod, defaultBinder, myClass, new object[] { });
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception :" + e.Message);
            }
        }
    }
}