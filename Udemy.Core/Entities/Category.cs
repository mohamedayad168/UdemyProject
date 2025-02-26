using System.ComponentModel.DataAnnotations;

namespace Udemy.Core.Entities
{
    public class Category : BaseEntity
    {
        [StringLength(20)]
        public required string Name { get; set; }
        public List<Subcategory> Subcategories { get; set; } = new();
    }
}
