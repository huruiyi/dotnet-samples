using System;
using System.Linq;
using WebApp.Contract;
using WebApp.Model;

namespace WebApp.Api
{
    public class Restapi : IRestapi
    {
        public string GetUserNameById(string id)
        {
            try
            {
                int userId = int.Parse(id);
                if (userId > 0 && userId < 5)
                {
                    var userDataList = (new UserDataList()).GetUserDataList();
                    var query = from data in userDataList
                                where data.Id == id
                                select data.UserName;
                    return query.FirstOrDefault();
                }
                else
                {
                    return "Can't find the user with id: " + id;
                }
            }
            catch
            {
                throw new Exception($"Can't convert {id} to int");
            }
        }

        public UserData GetUserNameByPostId(UserData rData)
        {
            try
            {
                int userId = int.Parse(rData.Id);
                if (userId > 0 && userId < 5)
                {
                    var userDataList = (new UserDataList()).GetUserDataList();
                    var query = from data in userDataList
                                where data.Id == rData.Id
                                select data;
                    return new UserData
                    {
                        UserName = query.FirstOrDefault().UserName
                    };
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw new Exception($"Can't convert {rData.Id} to int");
            }
        }
    }
}