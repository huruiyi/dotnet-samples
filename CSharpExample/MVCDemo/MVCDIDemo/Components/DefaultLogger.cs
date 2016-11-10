namespace MVCDIDemo.Components
{
    public class DefaultLogger : ILogger
    {
        public void Log(string logData)
        {
            System.Diagnostics.Debug.WriteLine(logData, "default");
        }
    }
}