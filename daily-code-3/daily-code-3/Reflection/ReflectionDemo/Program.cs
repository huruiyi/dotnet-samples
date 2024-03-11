using ReflectionDemo.Inter;
using ReflectionDemo.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ReflectionDemo
{
    internal class Program
    {
        private void ValidDemo()
        {
            Student zhangSan = new Student();
            zhangSan.Name = "张三";
            zhangSan.ReName = "张三";
            zhangSan.Age = "12";
            zhangSan.Email = "xxx.@123.com";
            string errorMessage = Valid(zhangSan);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                Console.WriteLine(errorMessage);
            }
            else
            {
                Console.WriteLine("学生没出错");
            }
        }

        //验证一个对象是否符合要求
        private static string Valid(object obj)
        {
            // 1. 找出obj 里面里面的所有的属性
            Type t = obj.GetType();
            PropertyInfo[] properties = t.GetProperties();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < properties.Length; i++)
            {
                // 2. 获取对象相对于此属性的值
                object value = t.InvokeMember(properties[i].Name, BindingFlags.GetProperty, null, obj, null);
                // 3. 看看属性上面有没有验证标示（特性）
                object[] attributes = properties[i].GetCustomAttributes(true);
                if (attributes.Length > 0)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        // 4. 判断这个特性是否为验证特性
                        if (attributes[j] is IValidate)
                        {
                            IValidate validate = attributes[j] as IValidate;
                            // 5. 验证当前属性是否符合要求
                            string msg = validate.Validate(value);
                            if (!string.IsNullOrEmpty(msg))
                            {
                                sb.AppendLine(msg);
                            }
                        }
                        else if (attributes[j] is IValidationSuper)
                        {
                            IValidationSuper validate = attributes[j] as IValidationSuper;
                            // 5. 验证当前属性是否符合要求
                            string msg = validate.Validate(obj, properties[i].Name);
                            if (!string.IsNullOrEmpty(msg))
                            {
                                sb.AppendLine(msg);
                            }
                        }
                    }
                }
            }

            return sb.ToString();
        }

        private static void Main(string[] args)
        {
            Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Type type = assembly.GetType("反射实例1.S0002.StudentDict");     //命名空间名 + 类名
            object obj = Activator.CreateInstance(type, true);

            FieldInfo classField = type.GetField("ClassName");
            Console.WriteLine("班级名称：" + classField.GetValue(obj).ToString());
            classField.SetValue(obj, "班级名赋值");

            PropertyInfo TeaNameProperty = type.GetProperty("TeacherName");
            Console.WriteLine("\t教师姓名：" + TeaNameProperty.GetValue(obj, null).ToString());

            PropertyInfo[] pros = type.GetProperties();
            foreach (PropertyInfo item in pros)
            {
                Console.WriteLine(item.PropertyType.GetType());
            }
            foreach (FieldInfo field in type.GetFields())
            {
                if (field.Name == "AttributeDict")
                {
                    Dictionary<string, string> dict = field.GetValue(obj) as Dictionary<string, string>;

                    foreach (string key in dict.Keys)
                    {
                        Console.WriteLine("\t\t学号：{0} -> 姓名：{1}", key, dict[key]);
                    }
                }
            }

            Dictionary<string, string> dictVal = type.GetField("AttributeDict").GetValue(obj) as Dictionary<string, string>;

            Dictionary<string, string> dic1 = new Dictionary<string, string>();
            dic1.Add("A", "AA");
            dic1.Add("B", "BB");
            type.GetField("AttributeDict").SetValue(obj, dic1);

            MethodInfo method = type.GetMethod("GetStuNameByCode");
            string strStuName = (string)method.Invoke(obj, new string[] { "02" });
            Console.WriteLine("\t\t学号【{0}】 的学生姓名为：{1}", "02", strStuName);
            Console.ReadLine();
        }
    }
}