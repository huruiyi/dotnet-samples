using ReflectionDemo.Attr;

namespace ReflectionDemo.Model
{
    public class Student
    {
        [Required("学生名称不能为空")]
        [StringLength(MaxLength = 10, ErrorMessage = "姓名长度不能高于10")]
        public string Name { get; set; }

        [Compare("Name", ErrorMessage = "您输入的两次名称不一致")]
        public string ReName { get; set; }

        [Required(ErrorMessage = "年龄不能为空")]
        public string Age { get; set; }

        [RegexExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "学生的邮箱地址格式不正确")]
        public string Email { get; set; }

        public override string ToString()
        {
            return string.Format("姓名：{0},年龄：{1}", Name, Age);
        }
    }
}