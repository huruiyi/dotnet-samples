using System;

namespace 接口实现1
{
    public class ColorPrinter : PrinterFace
    {
        public void print(string content)
        {
            Console.WriteLine("彩色打印：");
            Console.WriteLine(content);
        }
    }
}