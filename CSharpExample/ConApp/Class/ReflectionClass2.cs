using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp.Class
{
    /*
    Type类定义的方法,功能

    ConstructorInfo[]  GetConstructors() 获取指定类型的构造函数列表

    EventInfo[] GetEvents(); 获取指定类型的时间列

    FieldInfo[] GetFields(); 获取指定类型的字段列

    Type[]   GetGenericArguments();
    获取与已构造的泛型类型绑定的类型参数列表，如果指定类型的泛型类型定义，则获得类型形参。
    对于正早构造的类型，该列表就可能同时包含类型实参和类型形参
    MemberInfo[]   GetMembers();    获取指定类型的成员列表

    MethodInfo[]   GetMethods();   获取指定类型的方法列表

    PropertyInfo[]   GetProperties();   获取指定类型的属性列表

    下面列出Type类定义的常用的只读属性

    Assembly   Assembly 获取指定类型的程序集

    TypeAttributes   Attributes 获取制定类型的特性

    Type   BaseType 获取指定类型的直接基类型

    String  FullName 获取指定类型的全名

    bool   IsAbstract 如果指定类型是抽象类型，返回true

    bool   IsClass 如果指定类型是类，返回true

    string   Namespace 获取指定类型的命名空间
    */

    public class ReflectionClass2
    {
        private int x;
        private int y;

        public ReflectionClass2(int i, int j)
        {
            x = i;
            y = j;
        }

        public int sum()
        {
            return x + y;
        }

        public bool IsBetween(int i)
        {
            if (x < i && i < y) return true;
            else return false;
        }

        public void Set(int a, int b)
        {
            x = a;
            y = b;
        }

        public void Set(double a, double b)
        {
            x = (int)a;
            y = (int)b;
        }

        public void Show()
        {
            Console.WriteLine("x:{0},y:{1}", x, y);
        }
    }
}