using System;
using System.Collections.Generic;
using ProductManagementAPI.Entities;

namespace ProductManagementAPI.Repositories{
 public interface IProductsRepository
    {
        Product GetProduct(Guid sku);
        IEnumerable<Product> GetProducts();
        void CreateProduct(Product product);
        void UpdateProduct(Product updatedProduct);
        void DeleteProduct(Guid sku);
    }
}