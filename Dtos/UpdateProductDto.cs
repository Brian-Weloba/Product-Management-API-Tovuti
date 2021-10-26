using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Dtos
{
    public class UpdateProductDto
    {

        [Required]
        public string Name { get; init; }
        [Required]
        public string Brand { get; init; }
        [Required]
        public decimal Price { get; init; }
        [Required]
        [Range(1, 1000)]
        public int Quantity { get; init; }
    }
}
