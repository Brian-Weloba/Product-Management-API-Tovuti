using Microsoft.EntityFrameworkCore;

namespace ProductManagementAPI.Entities
{
    public class ProductContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=ProductManagement;Trusted_Connection=True");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductAttributes> ProductAttributes { get; set; }

    }
}