namespace Udemy.Core.Entities
{
    public class CourseSubcategory : BaseEntity
    {
        public int CourseId { get; set; }
        public int SubcategoryId { get; set; }

        public Course Course { get; set; }
        public Subcategory Subcategory { get; set; }
    }
}
