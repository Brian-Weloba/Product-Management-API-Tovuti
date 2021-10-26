using System;
using System.Collections.Generic;
using ProductManagementAPI.Entities;

namespace ProductManagementAPI.Repositories{
 public interface IProductsRepository
    {
        Product GetProduct(Guid sku);
        IEnumerable<Product> GetProducts();
    }
}