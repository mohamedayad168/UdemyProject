using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Core.Entities
{
    public class CourseRequirement
    {
        [Key] // Primary key
        public int Id { get; set; }

        [StringLength(50)]
        public string Requirement { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; } = false;

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
