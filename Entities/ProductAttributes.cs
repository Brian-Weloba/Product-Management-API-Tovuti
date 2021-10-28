using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ProductManagementAPI.Entities
{
    public record ProductAttributes
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProductSKU { get; set; }
        public string Name { get; set; }
        public string Attributes{get;set;}
        [NotMapped]
        public List<string> AttributeValues { 
            get { return Attributes.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(t => t).ToList(); }
        set { Attributes = string.Join(",", value); }
        }
        public ProductAttributes()
        {
            Id = Guid.NewGuid();
        }
    }
}