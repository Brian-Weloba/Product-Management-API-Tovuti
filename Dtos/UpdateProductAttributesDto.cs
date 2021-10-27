using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProductManagementAPI.Entities;

namespace ProductManagementAPI.Dtos
{
    public class UpdateProductAttributesDto
    {
        public List<ProductAttributes> Attributes { get; init; }
    }
}