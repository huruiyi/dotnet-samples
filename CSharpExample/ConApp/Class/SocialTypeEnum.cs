using System.ComponentModel;

namespace ConApp.Class
{
    internal enum SocialTypeEnum : int
    {
        [Description("脸书")]
        Facebook = 1,

        [Description("推特")]
        Twitter = 2,

        [Description("谷歌+")]
        GooglePlus = 3,

        [Description("其他")]
        Other = 4
    }
}