using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Entities
{


    public class Enrollment
    {
        [Key]

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [Key]

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        [Required]
        public ProgressStatus Progress { get; set; }

        // Navigation Properties
        public Student Student { get; set; }
        public Course Course { get; set; }
    }

    public enum ProgressStatus
    {
        NotStarted,
        InProgress,
        Completed
    }

}