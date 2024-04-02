using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebApp.Model
{
    [DataContract(Namespace = "http://msdn.microsoft.com")]
    public class UserData
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }

    public class UserDataList
    {
        private readonly List<UserData> userDataList;

        public UserDataList()
        {
            userDataList = new List<UserData>
            {
                new UserData {Id = "1", UserName = "Sam"},
                new UserData {Id = "2", UserName = "Lucy"},
                new UserData {Id = "3", UserName = "Dandy"},
                new UserData {Id = "4", UserName = "Alex"}
            };
        }

        public List<UserData> GetUserDataList()
        {
            return userDataList;
        }
    }
}