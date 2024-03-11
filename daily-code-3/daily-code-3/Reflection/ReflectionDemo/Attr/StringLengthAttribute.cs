using System;

namespace ReflectionDemo.Attr
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class StringLengthAttribute : Attribute, Inter.IValidate
    {
        public int MaxLength { get; set; }

        public string ErrorMessage { get; set; }

        public string Validate(object value)
        {
            if (value != null && value.ToString().Length > MaxLength)
            {
                return ErrorMessage;
            }
            return string.Empty;
        }
    }
}