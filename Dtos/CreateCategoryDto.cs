namespace ProductManagementAPI.Dtos
{
    public record CreateCategoryDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
    }
}