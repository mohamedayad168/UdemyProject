using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Entities
{
    public class CourseRequirement:BaseEntity
    {
        [ForeignKey("Course")]
        [Required]
        public int CourseId { get; set; }

        [StringLength(50)]
        public required string Requirement { get; set; }
        public Course Course { get; set; }
    }
}
