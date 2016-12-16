using System;

namespace ConApp.Class
{
    public class ValidateAgeAttribute : Attribute
    {
        public ValidateAgeAttribute()
        {
        }

        public ValidateAgeAttribute(int maxAge, string validateResult)
        {
            MaxAge = maxAge;
            ValidateResult = validateResult;
        }

        /// <summary>
        /// 允许的最大年龄
        /// </summary>
        public int MaxAge { get; set; }

        /// <summary>
        /// 验证结果
        /// </summary>
        public string ValidateResult { get; set; }

        public void Validate(int age)
        {
            if (age > MaxAge)
            {
                ValidateResult = string.Format("无法通过验证：age({0})>MaxAge({1})", age, MaxAge);
            }
            else if (age <= MaxAge)
            {
                ValidateResult = string.Format("验证通过：age({0})<=MaxAge({1})", age, MaxAge);
            }
        }
    }
}