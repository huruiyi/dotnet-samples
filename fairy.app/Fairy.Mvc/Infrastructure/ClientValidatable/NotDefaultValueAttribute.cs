using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fairy.Mvc.Infrastructure.ClientValidatable
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class NotDefaultValueAttribute : ValidationAttribute, IClientValidatable
    {
        public string InputString { get; set; }
        public NotDefaultValueAttribute()
        {
            ErrorMessage = "请选其中一项";
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule rule = new ModelClientValidationRule
            {
                ValidationType = "notdefaultvalue",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationParameters =
                {
                    ["inputstring"] = InputString
                }
            };

            yield return rule;
        }
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;
            string inputString = (string)value;
            if (inputString.Contains(InputString))
            {
                return false;
            }
            return true;
        }
    }
}