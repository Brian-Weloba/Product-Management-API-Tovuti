using System.Collections.Generic;
using ProductManagementAPI.Entities;

namespace ProductManagementAPI.Dtos
{
    public class UpdateProductAttributesDto
    {
        public string Name { get; set; }
        public List<ProductAttributes> Attributes { get; init; }
    }
}