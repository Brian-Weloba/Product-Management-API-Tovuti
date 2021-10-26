using ProductManagementAPI.Dtos;
using ProductManagementAPI.Entities;

namespace ProductManagementAPI
{
    public static class Extensions
    {
        public static ProductDto AsDto(this Product product)
        {
            return new ProductDto
            {
                Name = product.Name,
                Brand = product.Brand,
                Price = product.Price,
                Quantity = product.Quantity,
                CreatedDate = product.CreatedDate,
                Attributes = product.Attributes,
                SKU = product.SKU
            };
        }
    }
}