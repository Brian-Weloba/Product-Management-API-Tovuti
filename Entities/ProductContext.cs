using Microsoft.EntityFrameworkCore;

namespace ProductManagementAPI.Entities
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products {get; set;}
    }
}