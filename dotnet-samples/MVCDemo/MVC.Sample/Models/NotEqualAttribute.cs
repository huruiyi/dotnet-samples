using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC.Sample.Models
{
    public class NotEqualAttribute : ValidationAttribute, IClientValidatable
    {
        public NotEqualAttribute(string notEqualValue)
        {
            this.NotEqualValue = notEqualValue;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("{0}不能够等于 {1}", name, NotEqualValue);
        }

        public string NotEqualValue { get; private set; }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var validationRule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.DisplayName),
                ValidationType = "notequal",
            };
            validationRule.ValidationParameters.Add("value", NotEqualValue);

            yield return validationRule;
        }
    }
}