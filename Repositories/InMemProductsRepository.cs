using System;
using System.Collections.Generic;
using System.Linq;
using ProductManagementAPI.Entities;

namespace ProductManagementAPI.Repositories
{
    public class InMemProductsRepository : IProductsRepository
    {
        private readonly List<Product> products = new()
        {
            new Product {  Name = "Toothpaste", Brand = "Aquafresh", Price = 250, Quantity = 5, CreatedDate = System.DateTimeOffset.UtcNow },
            new Product {  Name = "Toothpaste", Brand = "Colgate", Price = 200, Quantity = 7, CreatedDate = System.DateTimeOffset.UtcNow },
            new Product {  Name = "Toothpaste", Brand = "Aquafresh", Price = 260, Quantity = 9, CreatedDate = System.DateTimeOffset.UtcNow,SKU = Guid.NewGuid() }
        };

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public Product GetProduct(Guid sku)
        {
            return products.Where(product => product.SKU == sku).SingleOrDefault();
        }

        public void CreateProduct(Product product)
        {
            products.Add(product);
        }

        public void UpdateProduct(Product updatedProduct)
        {
            var index = products.FindIndex(existingProduct => existingProduct.SKU == updatedProduct.SKU);
            products[index] = updatedProduct;
        }

        public void DeleteProduct(Guid sku)
        {
            var index = products.FindIndex(existingProduct => existingProduct.SKU == sku);
            products.RemoveAt(index);
        }
    }
}