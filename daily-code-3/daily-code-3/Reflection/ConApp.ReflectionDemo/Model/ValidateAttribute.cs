using System;

namespace ConApp.ReflectionDemo.Model
{
    /// <summary>
    /// 为元素添加验证信息的特性类
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class ValidateAttribute : Attribute
    {
        /// <summary>
        /// 验证类型
        /// </summary>
        private readonly ValidateType _validateType;

        /// <summary>
        /// 验证类型
        /// </summary>
        public ValidateType ValidateType
        {
            get { return _validateType; }
        }

        /// <summary>
        /// 最小长度
        /// </summary>
        public int MinLength { get; set; }

        /// <summary>
        /// 最大长度
        /// </summary>
        public int MaxLength { get; set; }

        /// <summary>
        /// 自定义数据源
        /// </summary>
        public string[] CustomArray { get; set; }

        /// <summary>
        /// 指定采取何种验证方式来验证元素的有效性
        /// </summary>
        /// <param name="validateType"></param>
        public ValidateAttribute(ValidateType validateType)
        {
            _validateType = validateType;
        }
    }
}