using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Entities{
    public record ProductAttributes{
        [Key]
        public Guid ProductSKU{get;set;}
        public List<string> attributeValues{get;init;} 
    }
}