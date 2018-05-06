using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [EnableCors(origins: "http://localhost:815/", headers: "*", methods: "*")]
    public class ApiCorsController : ApiController
    {
        public string Get(int id)
        {
            return "value";
        }
    }
}
