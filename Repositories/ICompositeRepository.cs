using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManagementAPI.Entities;

namespace ProductManagementAPI.Repositories
{
    public interface ICompositeRepository
    {
        Task<CompositeProduct> GetCompositeProduct(Guid sku);
        Task<IEnumerable<CompositeProduct>> GetCompositeProducts();
        Task CreateCompositeProduct(CompositeProduct compositeProduct);
        Task UpdateCompositeProduct(CompositeProduct updatedCompositeProduct);
        Task DeleteCompositeProduct(Guid sku);
        Task AddCategoryId(CompositeProduct product);
    }
}