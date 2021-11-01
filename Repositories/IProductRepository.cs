using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManagementAPI.Entities;

namespace ProductManagementAPI.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(Guid sku);
        Task<IEnumerable<Product>> GetProducts();
        Task CreateProduct(Product product);
        Task UpdateProduct(Product updatedProduct);
        Task DeleteProduct(Guid sku);
        Task AddCategoryId(Product product);
        Task<IEnumerable<Product>> GetProductByCategory(Guid categoryId);
        Task UpdateProductAtt(Product updatedProduct);
    }
}