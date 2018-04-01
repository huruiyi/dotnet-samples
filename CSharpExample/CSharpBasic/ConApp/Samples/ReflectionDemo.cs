using ConApp.Model;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace ConApp
{
    public class ReflectionDemo
    {
        public class ValidateAgeAttribute : Attribute
        {
            public ValidateAgeAttribute()
            {
            }

            public ValidateAgeAttribute(int maxAge, string validateResult)
            {
                MaxAge = maxAge;
                ValidateResult = validateResult;
            }

            /// <summary>
            /// 允许的最大年龄
            /// </summary>
            public int MaxAge { get; set; }

            /// <summary>
            /// 验证结果
            /// </summary>
            public string ValidateResult { get; set; }

            public void Validate(int age)
            {
                if (age > MaxAge)
                {
                    ValidateResult = $"无法通过验证：age({age})>MaxAge({MaxAge})";
                }
                else if (age <= MaxAge)
                {
                    ValidateResult = $"验证通过：age({age})<=MaxAge({MaxAge})";
                }
            }
        }

        public class ClassDemo
        {
            public string P1 { get; set; }

            public int P2 { get; set; }

            public void M1()
            {
                Console.WriteLine("MI1....");
            }

            public string M2()
            {
                return $"{this.P1}:{this.P2}";
            }

            public static void M2(string s)
            {
                Console.WriteLine(s);
            }

            protected string M2(string s, string s1)
            {
                return s + s1;
            }
        }

        public static void Demo1()
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
        public static void Demo2()
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
        public static void Demo3()
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

        public static void Demo4()
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
        public static void Demo5()
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

        public static void Demo6()
        {
            Type t = typeof(ClassDemo);

            MethodInfo[] m01 = t.GetMethods(BindingFlags.CreateInstance);
            MethodInfo[] m02 = t.GetMethods(BindingFlags.DeclaredOnly);
            MethodInfo[] m03 = t.GetMethods(BindingFlags.Default);
            MethodInfo[] m04 = t.GetMethods(BindingFlags.ExactBinding);
            MethodInfo[] m05 = t.GetMethods(BindingFlags.FlattenHierarchy);
            MethodInfo[] m06 = t.GetMethods(BindingFlags.GetField);
            MethodInfo[] m07 = t.GetMethods(BindingFlags.GetProperty);
            MethodInfo[] m08 = t.GetMethods(BindingFlags.IgnoreCase);
            MethodInfo[] m09 = t.GetMethods(BindingFlags.IgnoreReturn);
            MethodInfo[] m10 = t.GetMethods(BindingFlags.Instance);
            MethodInfo[] m11 = t.GetMethods(BindingFlags.InvokeMethod);
            MethodInfo[] m12 = t.GetMethods(BindingFlags.NonPublic);
            MethodInfo[] m13 = t.GetMethods(BindingFlags.OptionalParamBinding);
            MethodInfo[] m14 = t.GetMethods(BindingFlags.Public);
            MethodInfo[] m15 = t.GetMethods(BindingFlags.PutDispProperty);
            MethodInfo[] m16 = t.GetMethods(BindingFlags.PutRefDispProperty);
            MethodInfo[] m17 = t.GetMethods(BindingFlags.SetField);
            MethodInfo[] m18 = t.GetMethods(BindingFlags.SetProperty);
            MethodInfo[] m19 = t.GetMethods(BindingFlags.Static);
            MethodInfo[] m20 = t.GetMethods(BindingFlags.SuppressChangeType);
            MethodInfo[] m21 = t.GetMethods();

            MethodInfo[] m22 = t.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (MethodInfo item in m22)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            MethodInfo[] m23 = t.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (MethodInfo item in m23)
            {
                Console.WriteLine(item.Name);
            }
            string methodName1 = MethodInfo.GetCurrentMethod().Name;
            string methodName2 = MethodBase.GetCurrentMethod().Name;
        }

        public static void Demo7()
        {
            Person person = new Person { Name = "TT", Age = 20 };
            Type type = person.GetType();
            PropertyInfo propertyInfo = type.GetProperty("Age");
            ValidateAgeAttribute validateAgeAttribute = (ValidateAgeAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(ValidateAgeAttribute));
            Console.WriteLine("允许的最大年龄：" + validateAgeAttribute.MaxAge);
            validateAgeAttribute.Validate(person.Age);
            Console.WriteLine(validateAgeAttribute.ValidateResult);
        }

        public void BulidMethod()
        {
            //得到当前的应用程序域
            AppDomain appDm = AppDomain.CurrentDomain;
            //初始化AssemblyName的一个实例
            AssemblyName an = new AssemblyName();
            //设置程序集的名称
            an.Name = "EmitLind";
            //动态的在当前应用程序域创建一个应用程序集
            AssemblyBuilder ab = appDm.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
            //动态在程序集内创建一个模块
            ModuleBuilder mb = ab.DefineDynamicModule("EmitLind");
            //动态的在模块内创建一个类
            TypeBuilder tb = mb.DefineType("HelloEmit", TypeAttributes.Public | TypeAttributes.Class);
            //动态的为类里创建一个方法
            MethodBuilder mdb = tb.DefineMethod("HelloWord", MethodAttributes.Public, null, new Type[] { typeof(string) });

            //得到该方法的ILGenerator
            ILGenerator ilG = mdb.GetILGenerator();
            ilG.Emit(OpCodes.Ldstr, "Hello：{0}");
            //加载传入方法的参数到堆栈
            ilG.Emit(OpCodes.Ldarg_1);
            //调用Console.WriteLine方法，输出传入的字符
            ilG.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string), typeof(string) }));

            ilG.Emit(OpCodes.Ret);
            //创建类的Type对象
            Type tp = tb.CreateType();
            //实例化一个类
            object ob = Activator.CreateInstance(tp);
            //得到类中的方法，通过Invoke来触发方法的调用..
            MethodInfo mdi = tp.GetMethod("HelloWord");
            mdi.Invoke(ob, new object[] { "Hello Lind" });
        }

        public void BulidMethodRet()
        {
            //得到当前的应用程序域
            AppDomain appDm = AppDomain.CurrentDomain;
            //初始化AssemblyName的一个实例
            AssemblyName an = new AssemblyName();
            //设置程序集的名称
            an.Name = "EmitLind";
            //动态的在当前应用程序域创建一个应用程序集
            AssemblyBuilder ab = appDm.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
            //动态在程序集内创建一个模块
            ModuleBuilder mb = ab.DefineDynamicModule("EmitLind");
            //动态的在模块内创建一个类
            TypeBuilder tb = mb.DefineType("HelloEmit", TypeAttributes.Public | TypeAttributes.Class);

            //动态的为类里创建一个方法
            MethodBuilder mdb = tb.DefineMethod("HelloWorldReturn", MethodAttributes.Public, typeof(string), new Type[] { typeof(string), typeof(string) });

            //得到该方法的ILGenerator
            ILGenerator ilG = mdb.GetILGenerator();
            ilG.Emit(OpCodes.Ldstr, "你好：{0}-{1}");
            //加载传入方法的参数到堆栈
            ilG.Emit(OpCodes.Ldarg_1);
            ilG.Emit(OpCodes.Ldarg_2);
            //调用Console.WriteLine方法，输出传入的字符
            ilG.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string), typeof(string), typeof(string) }));

            // ilG.Emit(OpCodes.Pop);//加这个就有问题了
            //返回值部分
            LocalBuilder local = ilG.DeclareLocal(typeof(string));
            ilG.Emit(OpCodes.Ldstr, "Return Value：{0}");
            ilG.Emit(OpCodes.Ldarg_1);
            ilG.Emit(OpCodes.Call, typeof(string).GetMethod("Format", new Type[] { typeof(string), typeof(string) }));
            ilG.Emit(OpCodes.Stloc_0, local);
            ilG.Emit(OpCodes.Ldloc_0, local);
            ilG.Emit(OpCodes.Ret);
            //创建类的Type对象
            Type tp = tb.CreateType();
            //实例化一个类
            object ob = Activator.CreateInstance(tp);
            //得到类中的方法，通过Invoke来触发方法的调用..
            MethodInfo mdi = tp.GetMethod("HelloWorldReturn");
            mdi.Invoke(ob, new object[] { "Hello Lind", "OK" });
        }
    }
}