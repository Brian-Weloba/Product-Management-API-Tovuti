using System;

namespace ProductManagementAPI.Dtos
{
    public record CreateProductDto
    {
        public string Name { get; init; }
        public string Brand { get; init; }
        public decimal Price { get; init; }
        public int Quantity { get; init; }
        public string Vendor { get; init; }
        // public Guid SKU { get; init; }
        // public CreateProductDto()
        // {
        //     SKU = Guid.NewGuid();
        // }
    }
}