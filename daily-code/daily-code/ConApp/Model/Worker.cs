using System;

namespace ConApp.Model
{
    /*
          volatile 关键字指示一个字段可以由多个同时执行的线程修改。 声明为 volatile 的字段不受编译器优化（假定由单个线程访问）的限制。 这样可以确保该字段在任何时间呈现的都是最新的值。
          volatile 修饰符通常用于由多个线程访问但不使用 lock 语句对访问进行序列化的字段。
          volatile 关键字可应用于以下类型的字段：
          引用类型。
          指针类型（在不安全的上下文中）。 请注意，虽然指针本身可以是可变的，但是它指向的对象不能是可变的。 换句话说，您无法声明“指向可变对象的指针”。
          类型，如 sbyte、byte、short、ushort、int、uint、char、float 和 bool。
          具有以下基类型之一的枚举类型：byte、sbyte、short、ushort、int 或 uint。
          已知为引用类型的泛型类型参数。
          IntPtr 和 UIntPtr。
          可变关键字仅可应用于类或结构字段。 不能将局部变量声明为 volatile。
       */

    public class Worker
    {
        // This method is called when the thread is started.
        public void DoWork()
        {
            while (!_shouldStop)
            {
                Console.WriteLine("Worker thread: working...");
            }
            Console.WriteLine("Worker thread: terminating gracefully.");
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

        // Keyword volatile is used as a hint to the compiler that this data
        // member is accessed by multiple threads.
        private volatile bool _shouldStop;
    }
}