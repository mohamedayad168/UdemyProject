using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Udemy.Core.Enums;

namespace Udemy.Core.Entities
{
    public class Enrollment
    {
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public CourseStatus Status { get; set; }
        [Column(TypeName = "DECIMAL(8, 2)")]
        public decimal? Rating { get; set; }
        [MaxLength(50)]
        public string? comment { get; set; }
        public string? CertificationUrl { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; } = false;
        [Column(TypeName = "decimal(8,2)")]
        public decimal? ProgressPercentage { get; set; } = 0; //Added new property

        // Navigation Properties
        public Student Student { get; set; }
        public Course Course { get; set; }
    }

}