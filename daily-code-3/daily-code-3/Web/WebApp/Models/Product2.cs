using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Infrastructure;

namespace WebApp.Models
{
    public class Product2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [CustomRemoteValidation("IsProductNameExist", "Product2", ErrorMessage = "Product Name already exists")]
        public string ProductName { get; set; }

        public int ProductQuantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}