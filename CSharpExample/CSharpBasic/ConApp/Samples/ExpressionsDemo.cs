using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace ConApp
{
    internal class ExpressionsDemo
    {
        public class Foobar
        {
            public int IntVal { get; set; }

            public string StringVal { get; set; }

            public void Invoke()
            {
                Console.WriteLine("public void Invoke().............");
            }
        }

        public class EmitData
        {
            public int Name { get; set; }
        }

        public static Foobar Target { get; }

        public static MethodInfo Method { get; }

        public static Action<Foobar> Executor { get; }

        private static Action<Foobar> CreateExecutor(MethodInfo method)
        {
            ParameterExpression target = Expression.Parameter(typeof(Foobar), "target");
            Expression expression = Expression.Call(target, method);
            return Expression.Lambda<Action<Foobar>>(expression, target).Compile();
        }

        static ExpressionsDemo()
        {
            Target = new Foobar();
            Method = typeof(Foobar).GetMethod("Invoke");
            Executor = CreateExecutor(Method);
        }

        private static void ExpressionDemo1(int times)
        {
            Console.WriteLine("{0,-10}{1,-12}{2}", times, 123, 456);

            for (int i = 0; i < times; i++)
            {
                Method.Invoke(Target, new object[0] { });
            }

            Console.WriteLine();
            for (int i = 0; i < times; i++)
            {
                Executor(Target);
            }
        }

        public static void ExpressionDemo2()
        {
            string idField = ((MemberExpression)((Expression<Func<Foobar, int>>)(c => c.IntVal)).Body).Member.Name;
            string textField = ((MemberExpression)((Expression<Func<Foobar, string>>)(c => c.StringVal)).Body).Member.Name;
        }

        private static Func<object, int> _lmdGetProp; //Func<EmitData, int>

        public static void LmdGet(Type entityType, string propName)
        {
            #region 通过方法取值

            var property = entityType.GetProperty(propName);
            //对象实例
            var paramObj = Expression.Parameter(typeof(object), "obj");
            //值
            //var param_val = Expression.Parameter(typeof(object), "val");
            //转换参数为真实类型
            var bodyObj = Expression.Convert(paramObj, entityType);

            //调用获取属性的方法
            if (property != null)
            {
                var body = Expression.Call(bodyObj, property.GetGetMethod());
                _lmdGetProp = Expression.Lambda<Func<object, int>>(body, paramObj).Compile();
            }

            #endregion 通过方法取值

            #region 表达式取值

            //var p = entityType.GetProperty(propName);
            ////lambda的参数u
            //var param_u = Expression.Parameter(entityType, "u");
            ////lambda的方法体 u.Age
            //var pGetter = Expression.Property(param_u, p);
            ////编译lambda
            //LmdGetProp = Expression.Lambda<Func<EmitData, int>>(pGetter, param_u).Compile();

            #endregion 表达式取值
        }

        private static Action<object, object> _lmdSetProp;

        public static void LmdSet(Type entityType, string propName)
        {
            var property = entityType.GetProperty(propName);
            var paramObj = Expression.Parameter(typeof(object), "obj");//对象实例
            var paramVal = Expression.Parameter(typeof(object), "val");//值
            var bodyObj = Expression.Convert(paramObj, entityType);//转换参数为真实类型
            if (property != null)
            {
                var bodyVal = Expression.Convert(paramVal, property.PropertyType);
                var body = Expression.Call(bodyObj, property.GetSetMethod(), bodyVal);//调用给属性赋值的方法
                _lmdSetProp = Expression.Lambda<Action<object, object>>(body, paramObj, paramVal).Compile();
            }
        }

        public delegate void SetValueDelegateHandler(EmitData entity, object value);

        public static SetValueDelegateHandler EmitSetValue;

        public static void BuildEmitMethod(Type entityType, string propertyName)
        {
            //Type entityType = entity.GetType();
            Type parmType = typeof(object);
            // 指定函数名
            string methodName = "set_" + propertyName;
            // 搜索函数，不区分大小写 IgnoreCase
            var callMethod = entityType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic);
            // 获取参数
            var para = callMethod.GetParameters()[0];
            // 创建动态函数
            DynamicMethod method = new DynamicMethod("EmitCallable", null, new[] { entityType, parmType }, entityType.Module);
            // 获取动态函数的 IL 生成器
            var il = method.GetILGenerator();
            // 创建一个本地变量，主要用于 Object Type to Propety Type
            var local = il.DeclareLocal(para.ParameterType, true);
            // 加载第 2 个参数【(T owner, object value)】的 value
            il.Emit(OpCodes.Ldarg_1);
            if (para.ParameterType.IsValueType)
            {
                il.Emit(OpCodes.Unbox_Any, para.ParameterType);// 如果是值类型，拆箱 string = (string)object;
            }
            else
            {
                il.Emit(OpCodes.Castclass, para.ParameterType);// 如果是引用类型，转换 Class = object as Class
            }
            il.Emit(OpCodes.Stloc, local);// 将上面的拆箱或转换，赋值到本地变量，现在这个本地变量是一个与目标函数相同数据类型的字段了。
            il.Emit(OpCodes.Ldarg_0); // 加载第一个参数 owner
            il.Emit(OpCodes.Ldloc, local);// 加载本地参数
            il.EmitCall(OpCodes.Callvirt, callMethod, null);//调用函数
            il.Emit(OpCodes.Ret); // 返回
                                  /* 生成的动态函数类似：
                                  * void EmitCallable(T owner, object value)
                                  * {
                                  * T local = (T)value;
                                  * owner.Method(local);
                                  * }
                                  */

            EmitSetValue = method.CreateDelegate(typeof(SetValueDelegateHandler)) as SetValueDelegateHandler;
        }

        public delegate T PropertyGetter<T>();

        public delegate void PropertySetter<T>(T value);

        public static PropertyGetter<int> PropGet;

        public static PropertySetter<int> PropSet;

        public static void BuildSetMethod(EmitData td)
        {
            Type t = td.GetType();
            PropertyInfo pi = t.GetProperty("Name");
            if (pi != null)
            {
                MethodInfo setter = pi.GetSetMethod();
                PropSet = (PropertySetter<int>)Delegate.CreateDelegate(typeof(PropertySetter<int>), td, setter);
            }
        }

        public static void BuildGetMethod(EmitData td)
        {
            Type t = td.GetType();
            PropertyInfo pi = t.GetProperty("Name");
            if (pi != null)
            {
                MethodInfo getter = pi.GetGetMethod();
                PropGet = (PropertyGetter<int>)Delegate.CreateDelegate(typeof(PropertyGetter<int>), td, getter);
            }
        }

        public static void EmitDemo()
        {
            Console.Write("当前framework版本：" + Environment.Version.Major + "<br/>");
            int max = 1000000;
            Console.Write("循环次数：" + max + "<br/>");

            //基本方法
            DateTime time = DateTime.Now;
            EmitData d = new EmitData();
            for (int i = 0; i < max; i++)
            {
                d.Name = i;
            }
            TimeSpan ts = DateTime.Now - time;
            Console.Write("基本方法:" + ts.TotalMilliseconds + "<br/>");

            //反射方法
            Type type = d.GetType();
            PropertyInfo pi = type.GetProperty("Name");
            time = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                pi.SetValue(d, i, null);
            }
            ts = DateTime.Now - time;
            Console.Write("反射方法:" + ts.TotalMilliseconds + "<br/>");

            //dynamic动态类型方法
            dynamic dobj = Activator.CreateInstance<EmitData>();
            time = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                dobj.Name = i;
            }
            ts = DateTime.Now - time;
            Console.Write("dynamic动态类型方法:" + ts.TotalMilliseconds + "<br/>");

            //泛型委托赋值方法
            d.Name = -1;
            BuildSetMethod(d);
            time = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                PropSet(i);
            }
            ts = DateTime.Now - time;
            Console.Write("泛型委托赋值方法:" + ts.TotalMilliseconds + "<br/>");
            Console.Write("v:" + d.Name + "<br/>");

            //泛型委托取值方法
            d.Name = -1;
            BuildGetMethod(d);
            time = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                PropGet();
            }
            ts = DateTime.Now - time;
            Console.Write("泛型委托取值方法:" + ts.TotalMilliseconds + "<br/>");
            Console.Write("v:" + d.Name + "<br/>");

            //表达式树赋值方法
            d.Name = -1;
            LmdSet(typeof(EmitData), "Name");
            time = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                _lmdSetProp(d, i);
            }
            ts = DateTime.Now - time;
            Console.Write("表达式树赋值方法:" + ts.TotalMilliseconds + "<br/>");
            Console.Write("v:" + d.Name + "<br/>");

            //表达式树取值方法
            d.Name = -132;
            LmdGet(typeof(EmitData), "Name");
            time = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                _lmdGetProp(d);
            }
            ts = DateTime.Now - time;
            Console.Write("表达式树取值方法:" + ts.TotalMilliseconds + "<br/>");
            Console.Write("v:" + _lmdGetProp(d) + "<br/>");

            //EMIT动态方法赋值
            d.Name = -1;
            BuildEmitMethod(d.GetType(), "Name");
            time = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                EmitSetValue(d, i);
            }
            ts = DateTime.Now - time;
            Console.Write("EMIT动态方法:" + ts.TotalMilliseconds + "<br/>");
            Console.Write("v:" + d.Name + "<br/>");
        }
    }
}