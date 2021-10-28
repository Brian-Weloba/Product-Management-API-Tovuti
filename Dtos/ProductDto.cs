using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProductManagementAPI.Entities;

namespace ProductManagementAPI.Dtos
{
    public record ProductDto
    {

        private Random random = new Random();
        public string Name { get; init; }
        public string Brand { get; init; }
        public decimal Price { get; init; }
        public int Quantity { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
        [Key]
        public Guid SKU { get; init; }
        public List<ProductAttributes> Attributes { get; init; }
        public ProductDto()
        {
            SKU = Guid.NewGuid();
        }
    }
}