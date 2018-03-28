using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace MVC.Sample.Fliters._1Authentication_Authorization
{
    public class Cus_IAuthenticationFilter : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }
    }
}