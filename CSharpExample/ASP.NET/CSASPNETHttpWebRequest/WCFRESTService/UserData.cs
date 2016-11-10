using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WCFRESTService
{
    [DataContract(Namespace = "http://msdn.microsoft.com")]
    public class UserData
    {
        [DataMember]
        public string ID { get; set; }

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
                new UserData {ID = "1", UserName = "Sam"},
                new UserData {ID = "2", UserName = "Lucy"},
                new UserData {ID = "3", UserName = "Dandy"},
                new UserData {ID = "4", UserName = "Alex"}
            };
        }

        public List<UserData> getUserDataList()
        {
            return userDataList;
        }
    }
}