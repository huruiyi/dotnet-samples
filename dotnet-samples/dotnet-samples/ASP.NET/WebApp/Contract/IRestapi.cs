using System.ServiceModel;
using System.ServiceModel.Web;
using WebApp.Model;

namespace WebApp.Contract
{
    [ServiceContract]
    public interface IRestapi
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "json/{id}")]
        string GetUserNameById(string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Xml,
            UriTemplate = "json")]
        UserData GetUserNameByPostId(UserData data);
    }
}