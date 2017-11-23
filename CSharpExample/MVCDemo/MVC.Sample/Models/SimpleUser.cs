using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Sample.Models
{
    public class SimpleUser : IUser
    {
        public List<Student> GetUsers()
        {
            var list = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Student() { ID = i, Name = "Uer" + i, Age = i });
            }

            return list;
        }
    }
}