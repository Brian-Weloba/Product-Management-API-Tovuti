namespace ProductManagementAPI.Entities
{
    public record ProductCategory
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description{get;init;}
    }
}