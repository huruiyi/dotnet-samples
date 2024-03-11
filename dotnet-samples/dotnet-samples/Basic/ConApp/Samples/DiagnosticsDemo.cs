using System;
using System.Diagnostics;
using System.Reflection;

namespace ConApp.Samples
{
    public class DiagnosticsDemo
    {
        public static void Demo1()
        {
            StackTrace stackTrace = new StackTrace();
            int frameCount = stackTrace.FrameCount;
            Console.WriteLine("堆栈跟踪中的帧数:" + frameCount);
            foreach (var item in stackTrace.GetFrames())
            {
                Console.WriteLine(item);
                Console.WriteLine(item.GetFileColumnNumber());
                Console.WriteLine(item.GetFileLineNumber());
                Console.WriteLine("FileName:" + item.GetFileName());
                Console.WriteLine(item.GetHashCode());
                Console.WriteLine(item.GetILOffset());
                Console.WriteLine(item.GetMethod());
                Console.WriteLine(item.GetNativeOffset());
            }
        }

        public static void Demo2()
        {
            string className = MethodBase.GetCurrentMethod().ReflectedType.Name;
            StackTrace trace = new StackTrace();
            MethodBase methodName = trace.GetFrame(1).GetMethod();
            Console.WriteLine(className + "  " + methodName.Name);
        }

        public static string StackTraceDemo2(string author, string sqlDesc)
        {
            StackFrame stackFrame = new StackTrace(true).GetFrame(1);
            int fileColumnNumber = stackFrame.GetFileColumnNumber();
            int fileLineNumber = stackFrame.GetFileLineNumber();
            string fileName = stackFrame.GetFileName();
            int ilOffset = stackFrame.GetILOffset();
            MethodBase mb = stackFrame.GetMethod();
            int no = stackFrame.GetNativeOffset();
            return string.Format("/*Author:{0}/For:{1}/File:///{2}/Fun:{3}*/", author, sqlDesc, stackFrame.GetFileName(), stackFrame.GetMethod().Name);
        }

        public static void Demo3()
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;
            Trace.Indent();
            Trace.WriteLine("Entering Main");
            Console.WriteLine("Hello World.");
            Trace.WriteLine("Exiting Main");
            Trace.Unindent();
            Trace.Assert(123 > 100);
        }
    }
}