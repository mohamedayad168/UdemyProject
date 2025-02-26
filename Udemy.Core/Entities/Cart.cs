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

        public decimal? Amount { get; set; }

        // Navigation Property
        public Student Student { get; set; }


        public List<Course> CartCourses { get; set; } = new List<Course>(); // navigation property Added


    }
}

