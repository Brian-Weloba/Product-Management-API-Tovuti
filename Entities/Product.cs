using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Entities
{
    //Model for a basic product
    public record Product
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
        [Key]
        public Guid SKU { get; set; }
        public List<ProductAttributes> Attributes { get; set; }
        public Product()
        {
            SKU = Guid.NewGuid();
        }


    }
}