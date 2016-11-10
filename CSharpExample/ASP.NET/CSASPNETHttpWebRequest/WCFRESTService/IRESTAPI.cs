using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCFRESTService
{
    [ServiceContract]
    public interface IRESTAPI
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        string GetUserNameByID(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Xml, UriTemplate = "json")]
        UserData GetUserNameByPostID(UserData data);
    }
}