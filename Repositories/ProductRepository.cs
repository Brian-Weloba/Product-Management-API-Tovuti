using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Entities;

namespace ProductManagementAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public async Task CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Guid sku)
        {
            var itemToDelete = await _context.Products.FindAsync(sku);
            if (itemToDelete is null)
                throw new NullReferenceException();

            _context.Products.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProduct(Guid sku)
        {
            return await _context.Products.FindAsync(sku);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task UpdateProduct(Product updatedProduct)
        {
            var itemToUpdate = await _context.Products.FindAsync(updatedProduct.SKU);
            if (itemToUpdate is null)
                throw new NullReferenceException();

            itemToUpdate = updatedProduct with
            {
                Name = updatedProduct.Name,
                Brand = updatedProduct.Brand,
                Price = updatedProduct.Price,
                Quantity = updatedProduct.Quantity,
            };

            await _context.SaveChangesAsync();
        }
    }
}