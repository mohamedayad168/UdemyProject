namespace Udemy.Core.Entities
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
        public List<Subcategory> Subcategories { get; set; } = new();
    }
}
