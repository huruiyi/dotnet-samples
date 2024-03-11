using ReflectionDemo.Inter;
using System;
using System.Text.RegularExpressions;

namespace ReflectionDemo.Attr
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RegexExpressionAttribute : Attribute, IValidate
    {
        //正则表达式文本
        public string Pattern { get; set; }

        public string ErrorMessage { get; set; }

        public RegexExpressionAttribute(string pattern)
        {
            Pattern = pattern;
        }

        #region IValidate 成员

        public string Validate(object value)
        {
            if (value != null && value.ToString().Length > 0)
            {
                Regex regex = new Regex(Pattern);
                //用正则表达式进行验证
                if (!regex.IsMatch(value.ToString()))
                {
                    return ErrorMessage;
                }
            }

            return string.Empty;
        }

        #endregion IValidate 成员
    }
}