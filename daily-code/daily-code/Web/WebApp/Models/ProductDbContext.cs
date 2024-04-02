using System.Data.Entity;

namespace WebApp.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext() : base("ProductDbContext")
        {
        }

        public DbSet<Product1> Product1s { get; set; }

        public DbSet<Product2> Product2s { get; set; }
    }
}