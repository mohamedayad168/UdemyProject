using System.ComponentModel.DataAnnotations;

namespace Udemy.Core.Entities
{
    public class Cart : BaseEntity
    {


     
        [Required]
        public int StudentId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime? LastModified { get; set; }

        public int  Amount { get; set; }

        // Navigation Property
        public Student Student { get; set; }


<<<<<<< HEAD
        public List<Course> CartCourses { get; set; } = new List<Course>(); // navigation property Added
=======
        
>>>>>>> be133051c75e59a83283caae166ed9280c71f0c0


    }
}

