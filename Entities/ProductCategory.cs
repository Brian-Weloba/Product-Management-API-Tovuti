using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Entities
{
    public record ProductCategory
    {

        public int Id { get; set; }
        public string Name { get; init; }
        public string Description{get;init;}
    }
}