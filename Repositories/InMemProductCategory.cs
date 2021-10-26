using System.Collections.Generic;
using ProductManagementAPI.Entities;

namespace ProductManagementAPI.Repositories
{
    public class InMemProductsCategory
    {
        private readonly List<ProductCategory> productCategories = new()
        {
            new ProductCategory { id = 1, Name = "Personal Hygene", Description = "Soaps" },
            new ProductCategory { id = 2, Name = "Personal Hygene", Description = "Soaps" }
        };
}
}