using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Core.Entities
{
    public class CartCourse:BaseEntity
    {
        [Required]
        public int CartId { get; set; }
        [Required]

        public int CourseId { get; set; }
       
        // Navigation Properties
        public Course Course { get; set; }
        public Cart Cart { get; set; }
    }
}