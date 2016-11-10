using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCSample.Models
{
   public class Person
    {
       [DisplayName("姓名")]
       [Required]
       [NotEqual("abcd")]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Telephone { get; set; }

        public string Comment { get; set; }
    }
}
