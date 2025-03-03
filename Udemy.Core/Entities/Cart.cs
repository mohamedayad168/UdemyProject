using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Core.Entities
{
    public class Cart : BaseEntity
    {
        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public int? Amount { get; set; }

        // Navigation Property
        public Student Student { get; set; }

        public List<Course>? Courses { get; set; }
    }
}

