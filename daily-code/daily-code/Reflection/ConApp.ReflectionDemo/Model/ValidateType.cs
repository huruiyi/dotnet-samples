using System;

namespace ConApp.ReflectionDemo.Model
{
    /// <summary>
    /// 验证类型
    /// </summary>
    [Flags]
    public enum ValidateType
    {
        /// <summary>
        /// 字段或属性是否为空字串
        /// </summary>
        IsEmpty = 0x0001,

        /// <summary>
        /// 字段或属性的最小长度
        /// </summary>
        MinLength = 0x0002,

        /// <summary>
        /// 字段或属性的最大长度

        /// </summary>

        MaxLength = 0x0004,

        /// <summary>

        /// 字段或属性的值是否为数值型

        /// </summary>

        IsNumber = 0x0008,

        /// <summary>

        /// 字段或属性的值是否为时间类型

        /// </summary>

        IsDateTime = 0x0010,

        /// <summary>

        /// 字段或属性的值是否为正确的浮点类型

        /// </summary>

        IsDecimal = 0x0020,

        /// <summary>

        /// 字段或属性的值是否包含在指定的数据源数组中

        /// </summary>

        IsInCustomArray = 0x0040,

        /// <summary>

        /// 字段或属性的值是否为固定电话号码格式

        /// </summary>

        IsTelphone = 0x0080,

        /// <summary>

        /// 字段或属性的值是否为手机号码格式

        /// </summary>

        IsMobile = 0x0100
    }
}