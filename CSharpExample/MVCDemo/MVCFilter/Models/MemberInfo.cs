using System;
using System.Collections.Generic;

namespace MVCFilter.Models
{
    [Serializable]
    public class MemberInfo
    {
        public long MemberId { get; set; }

        public string MemberName { get; set; }

        public string MemberEmail { get; set; }

        public string MemberMobile { get; set; }

        public string MemberTrueName { get; set; }

        public List<string> AllRoles { get; set; }
        public string Role { get; set; }
    }
}