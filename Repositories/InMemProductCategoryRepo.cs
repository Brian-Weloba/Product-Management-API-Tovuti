using System.Collections.Generic;
using System.Linq;
using ProductManagementAPI.Entities;

namespace ProductManagementAPI.Repositories
{

    public class InMemProductsCategoryRepo : IProductsCategoryRepo
    {
        private readonly List<ProductCategory> productCategories = new()
        {
            new ProductCategory { Id = 1, Name = "Personal Hygene", Description = "Soaps" },
            new ProductCategory { Id = 2, Name = "Personal Hygene", Description = "Soaps" }
        };

        public IEnumerable<ProductCategory> getProductCategories()
        {
            return productCategories;
        }

        public ProductCategory GetProductCategory(int id)
        {
            return productCategories.Where(productCategory => productCategory.Id == id).SingleOrDefault();
        }

        public void CreateProductCategory(ProductCategory productCategory)
        {
            productCategories.Add(productCategory);
        }

        public void UpdateProductCategory(ProductCategory updatedProductCategory)
        {
            var index = productCategories.FindIndex(existingProductCategory => existingProductCategory.Id == updatedProductCategory.Id);
            productCategories[0] = updatedProductCategory;
        }

        public void DeleteProductCategory(int id)
        {
            var index = productCategories.FindIndex(existingProductCategory => existingProductCategory.Id == id);
            productCategories.RemoveAt(index);
        }
    }
}