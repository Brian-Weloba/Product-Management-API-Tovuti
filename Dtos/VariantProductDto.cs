using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProductManagementAPI.Entities;

namespace ProductManagementAPI.Dtos
{
    public class VariantProductDto
    {
        public string Name { get; init; }
        public string Brand { get; init; }
        public decimal Price { get; init; }
        public int Quantity { get; init; }
        [Key]
        public Guid SKU { get; init; }
        public List<ProductAttributes> Attributes { get; init; }
    }
}