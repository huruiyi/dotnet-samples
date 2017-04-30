using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiDemo.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            List<object> obj = new List<object>();

            for (int i = 0; i < 500; i++)
            {
                obj.Add(new
                {
                    a = i,
                    b = i.ToString("x"),
                    c = i.ToString("x2"),
                    d = Convert.ToString(i, 2),
                    e = Convert.ToString(i, 8),
                    f = Convert.ToString(i, 16)
                });
                Console.WriteLine($"{i.ToString()} {i.ToString("x")} {i.ToString("x2")} {Convert.ToString(i, 2)} {Convert.ToString(i, 8)} {Convert.ToString(i, 16)}");
            }

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
