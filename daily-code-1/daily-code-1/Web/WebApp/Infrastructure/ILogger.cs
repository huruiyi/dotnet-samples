using System.ComponentModel.Composition;

namespace WebApp.Infrastructure
{
    public interface ILogger
    {
        void Write(string text);
    }

    [Export("myTraceLogger", typeof(ILogger))]
    public class TraceLogger : ILogger
    {
        public void Write(string text)
        {
            System.Diagnostics.Trace.WriteLine(text);
        }
    }
}