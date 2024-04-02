using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Mvc;

namespace WebApp.Models
{
    public class Product1 : IValidatableObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Index("Ix_ProductName", Order = 1, IsUnique = true)]
        [Remote("IsProductNameExist", "Product1", AdditionalFields = "Id", ErrorMessage = "Product Name already exists")]
        public string ProductName { get; set; }

        [Required]
        public int ProductQuantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            ProductDbContext db = new ProductDbContext();
            var validateName = db.Product1s.FirstOrDefault(x => x.ProductName == ProductName && x.Id != Id);
            if (validateName != null)
            {
                ValidationResult errorMessage = new ValidationResult("Product name already exists.", new[] { "ProductName" });
                yield return errorMessage;
            }
            else
            {
                yield return ValidationResult.Success;
            }
        }

        //IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        //{
        //    ProductDbContext db = new ProductDbContext();
        //    List<ValidationResult> validationResult = new List<ValidationResult>();
        //    var validateName = db.Products.FirstOrDefault(x => x.ProductName == ProductName && x.Id != Id);
        //    if (validateName != null)
        //    {
        //        ValidationResult errorMessage = new ValidationResult("Product name already exists.", new[] { "ProductName" });
        //        validationResult.Add(errorMessage);
        //        return validationResult;
        //    }

        //    else
        //    {
        //        return validationResult;
        //    }

        //}
    }
}