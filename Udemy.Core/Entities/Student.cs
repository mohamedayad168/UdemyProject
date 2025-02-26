using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Entities
{
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;

    public class Student: ApplicationUser
    {
        [Required, MaxLength(20)]
        public string Title { get; set; }

        
        public string ?Bio { get; set; }
        [Required]  
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }  

       

        // Navigation Properties
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Cart> Carts { get; set; } = new List<Cart>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<StudentGrade> StudentGrades { get; set; } = new List<StudentGrade>();
        public ICollection<Progress> Progresses { get; set; } = new List<Progress>();
    }

}
