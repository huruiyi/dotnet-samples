using System;
using T4Demo.继承模式_基体中的文本;
using T4Demo.继承模式_基方法中的片段;

namespace T4Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*

                基类 SharedFragments 在类功能块 <#+ ... #> 中定义方法。
                该基类不包含任何自由文本，  相反，其所有文本块都出现在类功能方法内。
                派生类可调用 SharedFragments 中定义的方法。
                应用程序调用派生类的 TextTransform() 方法，但不转换基类 SharedFragments。
                基类和派生类的运行时文本模板： 即， 自定义工具 属性设置为 TextTemplatingFilePreprocessor。

                SharedFragments.tt,MyTextTemplate1.tt  自定义工具 属性设置为 TextTemplatingFilePreprocessor。
             */
            MyTextTemplate1 t1 = new MyTextTemplate1();
            string result = t1.TransformText();
            Console.WriteLine(result);

            DerivedTemplate1 t2 = new DerivedTemplate1();
            string result2 = t2.TransformText();
            Console.WriteLine(result2);
            Console.WriteLine();
        }
    }
}