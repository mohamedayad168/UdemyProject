using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Student: ApplicationUser
    {
        [Required, MaxLength(20)]
        public string StudentTitle { get; set; }

        [Required, MaxLength(50)]
        public string StudentBio { get; set; }

        // Navigation Properties
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Cart> Carts { get; set; } = new List<Cart>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        // new table 'progress' navigational property
        public List<Progress> Progresses { get; set; }
    }

}
