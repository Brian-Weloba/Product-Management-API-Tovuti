using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementAPI.Entities
{
    //Model for a basic product
    public record Product
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
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