using System;

namespace SelfLinqDemo.Model
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
            BasicInfo = new UserBasicInfo();
        }

        public Guid Id { get; set; }

        public UserBasicInfo BasicInfo { get; set; }
    }
}
