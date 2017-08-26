using ConApp.Model;
using System;
using System.Reflection;

namespace ConApp
{
    public class ReflectionDemo
    {
        public static void ReflectionClass1Demo()
        {
            ConstructorInfo[] p = typeof(ReflectionClass1).GetConstructors();
            Console.WriteLine(p.Length);

            foreach (ConstructorInfo t in p)
            {
                Console.WriteLine(t.IsStatic + "_" + t.DeclaringType);
                MethodBody mb = t.GetMethodBody();
            }

            ConstructorInfo[] p1 = typeof(ReflectionClass1).GetConstructors(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(p1.Length);

            foreach (ConstructorInfo t in p1)
            {
                Console.WriteLine(t.IsStatic);
            }
        }

        /// <summary>
        /// 使用反射获得类中所支持的方法，还有方法的信息。
        /// </summary>
        public static void ReflectionClass2Demo()
        {
            Type t = typeof(ReflectionClass2);   //获取描述MyClassA类型的Type对象
            Console.WriteLine("Analyzing methods in " + t.Name);  //t.Name="ReflectionClass2"

            MethodInfo[] mi = t.GetMethods();  //MethodInfo对象在System.Reflection命名空间下。
            foreach (MethodInfo m in mi) //遍历mi对象数组
            {
                Console.Write(m.ReturnType.Name); //返回方法的返回类型
                Console.Write(" " + m.Name + "("); //返回方法的名称

                ParameterInfo[] pi = m.GetParameters();  //获取方法参数列表并保存在ParameterInfo对象数组中
                for (int i = 0; i < pi.Length; i++)
                {
                    Console.Write(pi[i].ParameterType.Name); //方法的参数类型名称
                    Console.Write(" " + pi[i].Name);  // 方法的参数名
                    if (i + 1 < pi.Length)
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write(")");
                Console.WriteLine(); //换行
            }
        }

        /// <summary>
        /// GetMethods(BindingFlags bindingAttr)这个方法，参数可以使用or把两个或更多标记连接在一起，
        /// 实际上至少要有Instance（或Static）与Public（或NonPublic）标记。否则将不会获取任何方法。
        /// </summary>
        public static void ReflectionClass3Demo()
        {
            /*
            DeclareOnly:仅获取指定类定义的方法，而不获取所继承的方法；
            Instance：获取实例方法
            NonPublic: 获取非公有方法
            Public： 获取共有方法
            Static：获取静态方法
            */
            Type t = typeof(ReflectionClass3);   //获取描述ConApp3类型的Type对象
            Console.WriteLine("Analyzing methods in " + t.Name);  //t.Name="ReflectionClass3"

            MethodInfo[] mi = t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);  //不获取继承方法，为实例方法，为公开的
            foreach (MethodInfo m in mi) //遍历mi对象数组
            {
                Console.Write(m.ReturnType.Name); //返回方法的返回类型
                Console.Write(" " + m.Name + "("); //返回方法的名称

                ParameterInfo[] pi = m.GetParameters();  //获取方法参数列表并保存在ParameterInfo对象数组中
                for (int i = 0; i < pi.Length; i++)
                {
                    Console.Write(pi[i].ParameterType.Name); //方法的参数类型名称
                    Console.Write(" " + pi[i].Name);  // 方法的参数名
                    if (i + 1 < pi.Length)
                    {
                        Console.Write(",");
                    }
                }
                Console.Write(")");
                Console.WriteLine(); //换行
            }
        }

        public static void ReflectionClass4Demo()
        {
            Type t = typeof(ReflectionClass4);
            ReflectionClass4 reflectOb = new ReflectionClass4(10, 20);
            reflectOb.Show();  //输出为： x:10, y:20
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi)
            {
                ParameterInfo[] pi = m.GetParameters();

                if (m.Name.Equals("Set", StringComparison.Ordinal) && pi[0].ParameterType == typeof(int))
                {
                    object[] args = new object[2];
                    args[0] = 9;
                    args[1] = 10;
                    //参数reflectOb,为一个对象引用，将调用他所指向的对象上的方法，如果为静态方法这个参数必须设置为null
                    //参数args，为调用方法的参数数组，如果不需要参数为null
                    m.Invoke(reflectOb, args);   //调用MyClass类中的参数类型为int的Set方法，输出为Inside set(int,int).x:9, y:10
                }
            }
        }

        /// <summary>
        /// 反射获取构造函数并实例化
        /// </summary>
        public static void ReflectionClass5Demo()
        {
            /*
            在这之前的阐述中，由于Class类型的对象是都是显式创建的，
            因此使用反射技术调用Class类中的方法是没有任何优势的，
            还不如以普通方式调用方便简单呢。
            但是，如果对象是在运行时动态创建的，反射功能的优势就会显示出来。
            在这种情况下，要先获取一个构造函数列表，然后调用列表中的某个构造函数，创建一个该类型的实例。
            通过这种机制，可以在运行时实例化任意类型的对象，而不必在声明语句中指定类型。
            */
            Type t = typeof(ReflectionClass5);
            ConstructorInfo[] ci = t.GetConstructors(); //使用这个方法获取构造函数列表

            int x;
            for (x = 0; x < ci.Length; x++)
            {
                ParameterInfo[] pi = ci[x].GetParameters(); //获取当前构造函数的参数列表
                if (pi.Length == 2) break; //如果当前构造函数有2个参数，则跳出循环
            }

            if (x == ci.Length)
            {
                return;
            }

            object[] consargs = new object[2];
            consargs[0] = 10;
            consargs[1] = 20;
            object reflectOb = ci[x].Invoke(consargs); //实例化一个这个构造函数有两个参数的类型对象,如果参数为空，则为null
            ReflectionClass5 ac5 = reflectOb as ReflectionClass5;
            //实例化后，调用ConApp5中的方法
            MethodInfo[] mi = t.GetMethods(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            foreach (MethodInfo m in mi)
            {
                if (m.Name.Equals("sum", StringComparison.Ordinal))
                {
                    int val = (int)m.Invoke(reflectOb, null);
                    Console.WriteLine(@" sum is " + val); //输出 sum is 30
                }
            }
        }
    }
}