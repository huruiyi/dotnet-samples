using System;
using System.Linq;

namespace WCFRESTService
{
    public class RESTAPI : IRESTAPI
    {
        public string GetUserNameByID(string id)
        {
            try
            {
                int userID = int.Parse(id);
                if (userID > 0 && userID < 5)
                {
                    var userDataList = (new UserDataList()).getUserDataList();
                    var query = from data in userDataList
                                where data.ID == id
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
                throw new Exception(string.Format("Can't convert {0} to int", id));
            }
        }

        public UserData GetUserNameByPostID(UserData rData)
        {
            try
            {
                int userID = int.Parse(rData.ID);
                if (userID > 0 && userID < 5)
                {
                    var userDataList = (new UserDataList()).getUserDataList();
                    var query = from data in userDataList
                                where data.ID == rData.ID
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
                throw new Exception(string.Format("Can't convert {0} to int", rData.ID));
            }
        }
    }
}