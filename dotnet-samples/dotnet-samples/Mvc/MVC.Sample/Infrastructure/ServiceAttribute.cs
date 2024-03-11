using System;

namespace MVC.Sample.Infrastructure
{
    public class ServiceAttribute : Attribute
    {
        public string ServiceName { get; }

        public string ServiceNameSpace { get; }

        public ServiceAttribute(string serviceName, string serviceNamespace)
        {
            ServiceName = serviceName;
            ServiceNameSpace = serviceNamespace;
        }
    }
}