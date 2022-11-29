using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NetCore.Sample.Models;
using Newtonsoft.Json;

namespace MVC.Core.Sample.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        // GET: api/user
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return Model.GetAll();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return Model.GetUser(id);
        }

        // POST api/user
        [HttpPost]
        public void Post([FromForm]string value)
        {
            var user = JsonConvert.DeserializeObject<User>(value); // Convert JSON to Users
            Model.CreateUser(user); // Create a new User
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public void Put([FromForm]int id, [FromForm]string value)
        {
            var user = JsonConvert.DeserializeObject<User>(value);
            Model.UpdateUser(id, user);
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Model.DeleteUser(id);
        }
    }
}