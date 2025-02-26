using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Udemy.Core.Enums;

namespace Udemy.Core.Entities
{


    public class Enrollment : BaseEntity
    {


        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? CompletionDate { get; set; }
<<<<<<< HEAD

        public CourseStatus CourseStatus { get; set; }
        public decimal? Rating { get; set; }

        [MaxLength(255)]
        public string? CertificationUrl { get; set; }

        [MaxLength(50)]
        public string? comment { get; set; }
=======
        
>>>>>>> be133051c75e59a83283caae166ed9280c71f0c0
        public decimal? ProgressPercentage { get; set; } = 0; //Added new property

        // Navigation Properties
        public Student Student { get; set; }
        public Course Course { get; set; }
    }

}