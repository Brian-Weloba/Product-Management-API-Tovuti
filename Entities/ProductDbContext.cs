using Microsoft.EntityFrameworkCore;

namespace ProductManagementAPI.Entities
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductAttributes> ProductAttributes { get; set; }
        public DbSet<CompositeProduct> CompositeProduct { get; set; }

    }
}