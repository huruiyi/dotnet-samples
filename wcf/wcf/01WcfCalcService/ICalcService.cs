using System.ServiceModel;
using System.ServiceModel.Web;

namespace _01WcfCalcService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ICalcService”。
    [ServiceContract]
    public interface ICalcService
    {
        [OperationContract]
        string DoWork();

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        int Add(int a, int b);

        [OperationContract]
        int Sub(int a, int b);

        [OperationContract]
        int Mult(int a, int b);

        [OperationContract]
        int Div(int a, int b);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        decimal Add_decimal(string Number1, string Number2, out string error);
    }
}