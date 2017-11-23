using System.ComponentModel;

namespace MVC.Sample.Common
{
    public enum DelEnum
    {
        /// <summary>
        /// 未删除
        /// </summary>
        [Description("未删除")]
        No = 0,

        /// <summary>
        /// 已删除
        /// </summary>
        [Description("已删除")]
        Yes = 1
    }

    public enum ValidEnum
    {
        /// <summary>
        /// 有效
        /// </summary>
        [Description("有效")]
        Yes = 0,

        /// <summary>
        /// 无效
        /// </summary>
        [Description("无效")]
        No = 1
    }
}