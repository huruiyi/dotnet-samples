using MVC.Sample.Infrastructure;

namespace MVC.Sample.Models
{
    [Service(serviceName: "MVC.Sample.Models.MathService", serviceNamespace: "MVC.Sample.Models")]
    public interface IMathService
    {
        int Add(int a, int b);
    }
}