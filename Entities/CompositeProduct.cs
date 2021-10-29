using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ProductManagementAPI.Entities
{
    public record CompositeProduct
    {
        public readonly ProductDbContext _context;
        public CompositeProduct(ProductDbContext context)
        {
            _context = context;
        }

        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        [Key]
        public Guid SKU { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public string InclProducts { get; set; }

        [NotMapped]
        public List<string> CompProduct
        {
            get {
                return  InclProducts.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(t => t).ToList();
            }
            set { 
                InclProducts = string.Join(",", value);
            }
        }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price {
            get; set;
        }

        public CompositeProduct()
        {
            SKU = Guid.NewGuid();
        }
    }
}