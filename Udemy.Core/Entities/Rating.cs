using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Entities
{
   public class Rating
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [Required]
        [Range(0, 10)]
        public decimal RatingValue { get; set; }

        [Required, MaxLength(50)]
        public string Comment { get; set; }

        // Navigation Properties
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}

