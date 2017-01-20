using System;
using System.ComponentModel;

namespace ConApp.Model
{
    [Flags]
    public enum SocialTypeEnum : int
    {
        [Description("脸书")]
        Facebook = 10,

        [Description("推特")]
        Twitter,

        [Description("谷歌+")]
        GooglePlus = 16,

        [Description("其他")]
        Other = 4
    }
}