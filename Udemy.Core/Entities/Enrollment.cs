using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        
        public decimal? ProgressPercentage { get; set; } = 0; //Added new property

        // Navigation Properties
        public Student Student { get; set; }
        public Course Course { get; set; }
    }

}