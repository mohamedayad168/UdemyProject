using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Entities
{
   public class Rating:BaseEntity
    {

        [Required]
        public int CourseId { get; set; }



        [Required]
        public int StudentId { get; set; }

        [Required]
        [Range(0, 10)]
        [Column(TypeName = "decimal(8,2)")]
        public decimal RatingValue { get; set; }

        [Required, MaxLength(50)]
        public string Comment { get; set; }

        // Navigation Properties
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}

