using Fairy.Mvc.Infrastructure.ClientValidatable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Fairy.Mvc.Models
{
    public class TestModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }


        [DisplayName("出生日期")]
        [AgeRange(18, 25, ErrorMessage = "年龄必须在{0}到{1}周岁之间！")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? BirthDate { get; set; }
    }
}