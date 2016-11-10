using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSample.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "邮箱")]
        [Required(ErrorMessage = "邮箱地址不能为空")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "邮箱地址不符合规范")]
        public string Email { get; set; }

        [Display(Name = "密码")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "确认密码和密码不一致")]
        public string RePassword { get; set; }

        [Display(Name = "手机号码")]
        [StringLength(11, ErrorMessage = "手机号码长度不能高于11")]
        public string Phone { get; set; }
    }
}