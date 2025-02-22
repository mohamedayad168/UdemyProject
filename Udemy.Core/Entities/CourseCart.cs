using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Entities
{
    public class CourseCart
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Cart")]
        public int CartId { get; set; }

        // Navigation Properties
        public Course Course { get; set; }
        public Cart Cart { get; set; }
    }
}
