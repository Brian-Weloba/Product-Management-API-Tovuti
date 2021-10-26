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
            new Product { Vendor = "Nakumatt", Name = "Toothpaste", Brand = "Aquafresh", Price = 250, Quantity = 5, CreatedDate = System.DateTimeOffset.UtcNow },
            new Product { Vendor = "Naivas", Name = "Toothpaste", Brand = "Colgate", Price = 200, Quantity = 7, CreatedDate = System.DateTimeOffset.UtcNow },
            new Product { Vendor = "Quickmatt", Name = "Toothpaste", Brand = "Aquafresh", Price = 260, Quantity = 9, CreatedDate = System.DateTimeOffset.UtcNow }
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
    }
}