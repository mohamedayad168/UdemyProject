using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Entities
{
    public class Cart:BaseEntity
    {


     
        [Required]
        public int StudentId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime? LastModified { get; set; }

        public int  Amount { get; set; }

        // Navigation Property
        public Student Student { get; set; }


        public List<CartCourse> CartCourses { get; set; } = new List<CartCourse>(); // navigation property Added
        public List<Course> Courses { get; set; }

    } 
}

