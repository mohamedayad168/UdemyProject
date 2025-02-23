namespace Udemy.Core.Entities
{
    public class CartCourse:BaseEntity
    {
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}