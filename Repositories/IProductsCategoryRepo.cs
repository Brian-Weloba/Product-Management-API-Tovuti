using System.Collections.Generic;
using ProductManagementAPI.Entities;

namespace ProductManagementAPI.Repositories{
    public interface IProductsCategoryRepo
    {
        void CreateProductCategory(ProductCategory productCategory);
        void DeleteProductCategory(int id);
        IEnumerable<ProductCategory> getProductCategories();
        ProductCategory GetProductCategory(int id);
        void UpdateProductCategory(ProductCategory updatedProductCategory);
    }
}