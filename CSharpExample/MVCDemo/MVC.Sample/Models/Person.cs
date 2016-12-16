using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Sample.Models
{
    public class Person
    {
        public string Blog { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DisplayName("姓名")]
        [Required]
        [NotEqual("abcd")]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Telephone { get; set; }

        public string Comment { get; set; }
    }
}