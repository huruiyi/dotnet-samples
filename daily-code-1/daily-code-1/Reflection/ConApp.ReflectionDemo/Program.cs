using ConApp.Lib;
using ConApp.ReflectionDemo.Model;
using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ConApp.ReflectionDemo
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.Read();
        }

        public static void ReflectionDemo1()
        {
            object player = Activator.CreateInstance(Type.GetType("MyLibs.Player"));
            Player p = player as Player;
            p.Play();
        }

        public static void ReflectionDemo2()
        {
            //从文件中导入一个程序集
            Assembly ass = Assembly.LoadFrom(@"MyLibs.dll");
            //动态创建一个对象
            object obj = ass.CreateInstance("MyLibs.Person");
            Type t = obj.GetType();
            t.InvokeMember("Name", BindingFlags.SetProperty, null, obj, new object[] { "张三" });
            t.InvokeMember("Work", BindingFlags.InvokeMethod, null, obj, null);

            Console.WriteLine(ass.FullName);

            Type[] types = ass.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine("\t" + types[i].FullName);
                MethodInfo[] members = types[i].GetMethods();
                foreach (var t1 in members)
                {
                    ParameterInfo[] parameterInfos = t1.GetParameters();
                    Console.WriteLine("\t\t" + t1.Name);
                }
            }
        }

        public static void ReflectionDemo3()
        {
            Type t = typeof(MyTester5);
            MemberInfo[] mems = t.GetMembers();
            foreach (MemberInfo item in mems)
            {
                MethodInfo itemMethod = item as MethodInfo;
                Console.WriteLine(item.Name.PadRight(20, ' ') + item.DeclaringType.Name + "  " + item.ReflectedType.Name + "  " + item.MemberType + " " + itemMethod?.ReturnType.Name);
            }

            object obj = Activator.CreateInstance(typeof(MyTester5));
            MethodInfo method = t.GetMethod("Method", new Type[] { typeof(string), typeof(string) });
            if (method != null)
            {
                var declaringType = method.GetBaseDefinition().DeclaringType;
                if (declaringType != null)
                    Console.WriteLine($"Method方法的声明类:{declaringType.Name}");
                object result = method.Invoke(obj, new object[] { "A", "B" });
                Console.WriteLine(result);
            }
        }

        public static void ReflectionDemo4()
        {   //获取参数列表
            Type t = typeof(MyTester5);
            MethodInfo method = t.GetMethod("Method", new[] { typeof(string), typeof(string) });
            ParameterInfo[] parms = method.GetParameters();
            foreach (ParameterInfo item in parms)
            {
                Console.WriteLine($"是否有默认值:{item.HasDefaultValue}");
                Console.WriteLine($"默认值:{item.DefaultValue}");
                Console.WriteLine($"参数类型{item.ParameterType}");
                Console.WriteLine($"参数名:{item.Name}");
                Console.WriteLine();
            }
        }

        public static void ReflectionDemo5()
        {
            //调用无参构造函数,实例化MyTester5类
            Type t = typeof(MyTester5);
            ConstructorInfo con0 = t.GetConstructor(Type.EmptyTypes);
            if (con0 != null)
            {
                object obj0 = con0.Invoke(null);
                if (obj0 != null && obj0 is MyTester5 tc0)
                {
                    tc0.TestMethod0();
                }
            }
        }

        public static void ReflectionDemo6()
        {
            //调用有参构造函数初始化MyTester5
            Type t = typeof(MyTester5);
            ConstructorInfo con1 = t.GetConstructor(new Type[] { typeof(int) });
            if (con1 != null)
            {
                //object obj1 = con1.Invoke(new object[] { 123 });
                //MyTester5 tc1 = obj1 as MyTester5;
                //if (obj1 != null && tc1 != null)
                //{
                //    tc1.TestMethod0();
                //}

                object obj1 = con1.Invoke(new object[] { 123 });
                if (obj1 != null && obj1 is MyTester5 tc1)
                {
                    tc1.TestMethod0();
                }
            }
        }

        public static void ReflectionDemo7()
        {
            //调用有参构造函数初始化MyTester5
            Type t = typeof(MyTester5);
            ConstructorInfo con2 = t.GetConstructor(new[] { typeof(string) });
            if (con2 != null)
            {
                object obj2 = con2.Invoke(new object[] { "123" });
                if (obj2 != null && obj2 is MyTester5 tc2)
                {
                    tc2.TestMethod0();
                }
            }
        }

        public static void AttributeDemo1()
        {
            //如何以反射确定特性信息
            Type tp = typeof(MyTest);
            MemberInfo info = tp;
            var myAttribute = (MyselfAttribute)Attribute.GetCustomAttribute(info, typeof(MyselfAttribute));
            if (myAttribute != null)
            {
                //嘿嘿，在运行时查看注释内容，是不是很爽
                Console.WriteLine("Name: " + myAttribute.Name);
                Console.WriteLine("Age: " + myAttribute.Age);
                Console.WriteLine("Memo of  is " + myAttribute.Name, myAttribute.Memo);
                myAttribute.ShowName();
            }

            //多点反射
            object obj = Activator.CreateInstance(typeof(MyTest));

            MethodInfo mi = tp.GetMethod("SayHello");
            mi.Invoke(obj, null);
        }

        /// <summary>
        /// 验证实体对象的所有带验证特性的元素  并返回验证结果  如果返回结果为String.Empty 则说明元素符合验证要求
        /// </summary>
        /// <param name="entityObject">实体对象</param>
        /// <returns></returns>
        public static string GetValidateResult(object entityObject)
        {
            if (entityObject == null)
                throw new ArgumentNullException("entityObject");

            Type type = entityObject.GetType();
            PropertyInfo[] properties = type.GetProperties();

            string validateResult = string.Empty;

            foreach (PropertyInfo property in properties)
            {
                //获取验证特性
                object[] validateContent = property.GetCustomAttributes(typeof(ValidateAttribute), true);

                if (validateContent != null)
                {
                    //获取属性的值
                    object value = property.GetValue(entityObject, null);

                    foreach (ValidateAttribute validateAttribute in validateContent)
                    {
                        switch (validateAttribute.ValidateType)
                        {
                            //验证元素是否为空字串
                            case ValidateType.IsEmpty:
                                if (null == value || value.ToString().Length < 1)
                                    validateResult = string.Format("元素 {0} 不能为空", property.Name);
                                break;
                            //验证元素的长度是否小于指定最小长度
                            case ValidateType.MinLength:
                                if (null == value || value.ToString().Length < 1) break;
                                if (value.ToString().Length < validateAttribute.MinLength)
                                    validateResult = string.Format("元素 {0} 的长度不能小于 {1}", property.Name, validateAttribute.MinLength);
                                break;
                            //验证元素的长度是否大于指定最大长度
                            case ValidateType.MaxLength:
                                if (null == value || value.ToString().Length < 1) break;
                                if (value.ToString().Length > validateAttribute.MaxLength)
                                    validateResult = string.Format("元素 {0} 的长度不能大于{1}", property.Name, validateAttribute.MaxLength);
                                break;
                            //验证元素的长度是否符合指定的最大长度和最小长度的范围
                            case ValidateType.MinLength | ValidateType.MaxLength:
                                if (null == value || value.ToString().Length < 1) break;
                                if (value.ToString().Length > validateAttribute.MaxLength || value.ToString().Length < validateAttribute.MinLength)
                                    validateResult = string.Format("元素 {0} 不符合指定的最小长度和最大长度的范围,应该在 {1} 与 {2} 之间", property.Name, validateAttribute.MinLength, validateAttribute.MaxLength);
                                break;
                            //验证元素的值是否为值类型
                            case ValidateType.IsNumber:
                                if (null == value || value.ToString().Length < 1) break;
                                if (!Regex.IsMatch(value.ToString(), @"^\d+$"))
                                    validateResult = string.Format("元素 {0} 的值不是值类型", property.Name);
                                break;
                            //验证元素的值是否为正确的时间格式
                            case ValidateType.IsDateTime:
                                if (null == value || value.ToString().Length < 1) break;
                                if (!Regex.IsMatch(value.ToString(), @"(\d{2,4})[-/]?([0]?[1-9]|[1][12])[-/]?([0][1-9]|[12]\d|[3][01])\s*([01]\d|[2][0-4])?[:]?([012345]?\d)?[:]?([012345]?\d)?"))
                                    validateResult = string.Format("元素 {0} 不是正确的时间格式", property.Name);
                                break;
                            //验证元素的值是否为正确的浮点格式
                            case ValidateType.IsDecimal:
                                if (null == value || value.ToString().Length < 1) break;
                                if (!Regex.IsMatch(value.ToString(), @"^\d+[.]?\d+$"))
                                    validateResult = string.Format("元素 {0} 不是正确的金额格式", property.Name);
                                break;
                            //验证元素的值是否在指定的数据源中
                            case ValidateType.IsInCustomArray:
                                if (null == value || value.ToString().Length < 1) break;
                                if (null == validateAttribute.CustomArray || validateAttribute.CustomArray.Length < 1)
                                    validateResult = string.Format("系统内部错误：元素 {0} 指定的数据源为空或没有数据", property.Name);

                                bool isHas = Array.Exists(validateAttribute.CustomArray, delegate (string str)
                                {
                                    return str == value.ToString();
                                }
                                );

                                if (!isHas)
                                    validateResult = string.Format("元素 {0} 的值设定不正确 , 应该为 {1} 中的一种", property.Name, string.Join(",", validateAttribute.CustomArray));
                                break;
                            //验证元素的值是否为固定电话号码格式
                            case ValidateType.IsTelphone:
                                if (null == value || value.ToString().Length < 1) break;
                                if (!Regex.IsMatch(value.ToString(), @"^(\d{3,4}-)?\d{6,8}$"))
                                    validateResult = string.Format("元素 {0} 不是正确的固定电话号码格式", property.Name);
                                break;
                            //验证元素的值是否为手机号码格式
                            case ValidateType.IsMobile:
                                if (null == value || value.ToString().Length < 1) break;
                                if (!Regex.IsMatch(value.ToString(), @"^[1]+[3,5]+\d{9}$"))
                                    validateResult = string.Format("元素 {0} 不是正确的手机号码格式", property.Name);
                                break;
                            //验证元素是否为空且符合指定的最小长度
                            case ValidateType.IsEmpty | ValidateType.MinLength:
                                if (null == value || value.ToString().Length < 1) goto case ValidateType.IsEmpty;
                                goto case ValidateType.MinLength;
                            //验证元素是否为空且符合指定的最大长度
                            case ValidateType.IsEmpty | ValidateType.MaxLength:
                                if (null == value || value.ToString().Length < 1)
                                    goto case ValidateType.IsEmpty;
                                goto case ValidateType.MaxLength;
                            //验证元素是否为空且符合指定的长度范围
                            case ValidateType.IsEmpty | ValidateType.MinLength | ValidateType.MaxLength:
                                if (null == value || value.ToString().Length < 1)
                                    goto case ValidateType.IsEmpty;
                                goto case ValidateType.MinLength | ValidateType.MaxLength;
                            //验证元素是否为空且值为数值型
                            case ValidateType.IsEmpty | ValidateType.IsNumber:
                                if (null == value || value.ToString().Length < 1)
                                    goto case ValidateType.IsEmpty;
                                goto case ValidateType.IsNumber;
                            //验证元素是否为空且值为浮点型
                            case ValidateType.IsEmpty | ValidateType.IsDecimal:
                                if (null == value || value.ToString().Length < 1)
                                    goto case ValidateType.IsEmpty;
                                goto case ValidateType.IsDecimal;
                            //验证元素是否为空且值为时间类型
                            case ValidateType.IsEmpty | ValidateType.IsDateTime:
                                if (null == value || value.ToString().Length < 1)
                                    goto case ValidateType.IsEmpty;
                                goto case ValidateType.IsDateTime;
                            //验证元素是否为空且值在指定的数据源中
                            case ValidateType.IsEmpty | ValidateType.IsInCustomArray:
                                if (null == value || value.ToString().Length < 1) goto case ValidateType.IsEmpty;
                                goto case ValidateType.IsInCustomArray;
                            //验证元素是否为空且值为固定电话号码格式
                            case ValidateType.IsEmpty | ValidateType.IsTelphone:
                                if (null == value || value.ToString().Length < 1) goto case ValidateType.IsEmpty;
                                goto case ValidateType.IsTelphone;
                            //验证元素是否为空且值为手机号码格式
                            case ValidateType.IsEmpty | ValidateType.IsMobile:
                                if (null == value || value.ToString().Length < 1) goto case ValidateType.IsEmpty;
                                goto case ValidateType.IsMobile;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(validateResult))
                    break;
            }

            return validateResult;
        }

        public static void AttributeDemo2()
        {
            var orderRequest = new OrderRequest
            {
                CommodityAmount = "1050",
                CommodityName = "Name",
                CommodityValue = "Value",
                CommodityWeight = "123",
                HopeArriveTime = "2014-06-10",
                OrderNo = "123456798",
                PayMent = "XX",
                Remark = "dadsad"
            };
            string checkMessage = GetValidateResult(orderRequest);

            if (!string.IsNullOrEmpty(checkMessage))
            {
                Console.WriteLine(checkMessage);
            }
        }

        public static void AttributeDemo3()
        {
            Type tp = typeof(MyTester);
            MemberInfo memberInfo = tp.GetMethod("CannotRun");
            var myAtt = (TestAttribute)Attribute.GetCustomAttribute(memberInfo, typeof(TestAttribute));
            myAtt.RunTest();

            MyTester tester = new MyTester { Age = 10 };
            Type type = tester.GetType();
            PropertyInfo propertyInfo = type.GetProperty("Age");
            ValidateAgeAttribute validateAgeAttribute = (ValidateAgeAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(ValidateAgeAttribute));
            Console.WriteLine(validateAgeAttribute.MaxAge);
            validateAgeAttribute.IsRight(tester.Age);
        }

        public static void AttributeDemo4()
        {
            Type type = typeof(MyTester3);
            MemberInfo memberInfo1 = type.GetMethod("Method1");
            bool isDef1 = Attribute.IsDefined(memberInfo1, typeof(ObsoleteAttribute));
            var objObsolete = (ObsoleteAttribute)Attribute.GetCustomAttribute(memberInfo1, typeof(ObsoleteAttribute));
            Console.WriteLine(objObsolete.Message);
            Console.WriteLine(isDef1);

            MemberInfo memberInfo2 = type.GetMethod("Method2");
            bool isDef2 = Attribute.IsDefined(memberInfo2, typeof(ObsoleteAttribute));
            Console.WriteLine(isDef2);
        }

        public static void AttributeDemo5()
        {
            var person = new MyTester4 { Name = "TT", Age = 20 };
            Type type = person.GetType();
            PropertyInfo propertyInfo = type.GetProperty("Age");
            var attr = (ValidateAgeComplexAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(ValidateAgeComplexAttribute));
            Console.WriteLine("允许的最大年龄：" + attr.MaxAge);
            attr.Validate(person.Age);
            Console.WriteLine(attr.ValidateResult);
        }

        public static void AttributeDemo6()
        {
            Type myType = typeof(MyTester);
            MemberInfo[] myMembers = myType.GetMembers();

            for (int i = 0; i < myMembers.Length; i++)
            {
                object[] myAttributes = myMembers[i].GetCustomAttributes(true);
                if (myAttributes.Length > 0)
                {
                    Console.WriteLine(myMembers[i]);
                    for (int j = 0; j < myAttributes.Length; j++)
                        Console.WriteLine("\t" + myAttributes[j]);
                }
            }
        }
    }
}