using System;

namespace ProductManagementAPI.Entities
{
    //Product categories model
    public record ProductCategory
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductCategory()
        {
            Id = Guid.NewGuid();
        }
    }
}