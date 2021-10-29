using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Entities;

namespace ProductManagementAPI.Repositories
{
    public class CompositeProductRepository : ICompositeRepository
    {

        public readonly ProductDbContext _context;
        public CompositeProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task AddCategoryId(CompositeProduct product)
        {
            var itemToUpdate = await _context.CompositeProduct.FindAsync(product.SKU);
            if (itemToUpdate is null)
                throw new NullReferenceException();

            itemToUpdate.CategoryId = product.CategoryId;
            await _context.SaveChangesAsync();
        }

        public async Task CreateCompositeProduct(CompositeProduct compositeProduct)
        {
            _context.CompositeProduct.Add(compositeProduct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCompositeProduct(Guid sku)
        {
            var itemToDelete = await _context.CompositeProduct.FindAsync(sku);
            if (itemToDelete is null)
                throw new NullReferenceException();

            _context.CompositeProduct.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<CompositeProduct> GetCompositeProduct(Guid sku)
        {
            return await _context.CompositeProduct.FindAsync(sku);
        }

        public async Task<IEnumerable<CompositeProduct>> GetCompositeProducts
            ()
        {
            return await _context.CompositeProduct.ToListAsync();
        }

        public async Task UpdateCompositeProduct(CompositeProduct updatedCompositeProduct)
        {
            var itemToUpdate = await _context.CompositeProduct.FindAsync(updatedCompositeProduct.SKU);
            if (itemToUpdate is null)
                throw new NullReferenceException();

            itemToUpdate.CompProduct = updatedCompositeProduct.CompProduct;
            itemToUpdate.CreatedDate = updatedCompositeProduct.CreatedDate;
            itemToUpdate.Quantity = updatedCompositeProduct.Quantity;
            itemToUpdate.CategoryId = updatedCompositeProduct.CategoryId;
            await _context.SaveChangesAsync();
        }
    }
}