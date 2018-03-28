using System;
using System.Net;
using System.Net.Http.Headers;
using System.Web.Mvc;
using WebApiRestService.Authentication;

namespace MVC.Sample.Fliters._4Other
{
    public class Cus_IAuthentication_API : FilterAttribute, IAuthentication
    {
        public ICredentials Credentials
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public AuthenticationHeaderValue Authenticate()
        {
            throw new NotImplementedException();
        }
    }
}