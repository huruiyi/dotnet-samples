using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Sample.Models
{
    public class SimpleUser : IUser
    {
        public List<UserInfo> GetUsers()
        {
            var list = new List<UserInfo>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new UserInfo() { ID = i, UserName = "Uer" + i, Age = i });
            }

            return list;
        }
    }
}