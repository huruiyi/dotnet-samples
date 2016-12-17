using System;

namespace 接口实现1
{
    public class ColorPrinter : PrinterFace
    {
        public void Print(string content)
        {
            Console.WriteLine("彩色打印：");
            Console.WriteLine(content);
        }
    }
}