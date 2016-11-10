using System;

namespace 接口实现1
{
    public class BlackPrinter : PrinterFace
    {
        public void print(string content)
        {
            Console.WriteLine("黑白打印：");
            Console.WriteLine(content);
        }
    }
}