using System;

namespace ProductManagementAPI.Dtos
{
    public record ProductCategoryDto
    {
        public Guid CategoryId { get; set; }
    }
}