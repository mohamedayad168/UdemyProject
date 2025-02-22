namespace Udemy.Core.Entities
{
    public class Subcategory : BaseEntity
    {
        public string Name { get; set; }


        //Navigation Properties
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<CourseSubcategory> CourseSubcategories { get; set; } = new();
    }
}
