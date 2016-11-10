using System.ComponentModel.Composition;

namespace MVCDIDemo.Components
{
    [InheritedExport]
    public interface ILogger
    {
        void Log(string logData);
    }
}