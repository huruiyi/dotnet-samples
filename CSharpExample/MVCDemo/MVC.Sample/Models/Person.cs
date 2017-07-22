using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Sample.Models
{
    public class Person
    {
        [DisplayName("博客")]
        public string Blog { get; set; }

        [DisplayName("名")]
        public string FirstName { get; set; }

        [DisplayName("姓")]
        public string LastName { get; set; }

        [DisplayName("姓名")]
        [Required]
        [NotEqual("abcd")]
        public string Name { get; set; }

        [DisplayName("年龄")]
        public int Age { get; set; }

        [DisplayName("电话")]
        public string Telephone { get; set; }

        [DisplayName("备注")]
        public string Comment { get; set; }
    }
}