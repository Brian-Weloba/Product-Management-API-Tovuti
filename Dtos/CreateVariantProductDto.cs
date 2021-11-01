using System;
using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Dtos
{
    public record CreateVariantProductDto
    {
        public Guid SKU;
        [Required]
        public string Name { get; init; }
        [Required]
        public string Brand { get; init; }
        [Required]
        public decimal Price { get; init; }
        [Required]
        [Range(1, 1000)]
        public int Quantity { get; init; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
    }
}