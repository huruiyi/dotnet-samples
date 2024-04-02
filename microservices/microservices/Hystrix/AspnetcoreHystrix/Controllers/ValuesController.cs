using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetcorehystrix.Controllers
{
    [Produces("application/json")]
    [Route("api/Values")]
    public class ValuesController : Controller
    {
        private Person p;

        public ValuesController(Person p)
        {
            this.p = p;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            string s = await p.HelloAsync("yzk");
            return new string[] { "value1", "value2", s };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}