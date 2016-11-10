using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Sample.Models
{
    public interface IUser
    {
        List<UserInfo> GetUsers();
    }
}