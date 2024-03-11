using System.Web.Http;

namespace Api.Server.Controllers
{
    public class DemoController : ApiController
    {
        public string Get()
        {
            return "Get";
        }

        public string Post()
        {
            return "Post";
        }

        public string Put()
        {
            return "Put";
        }

        public string Delete()
        {
            return "Delete";
        }
    }
}