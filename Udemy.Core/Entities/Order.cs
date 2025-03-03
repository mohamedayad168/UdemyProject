using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Enums;

namespace Udemy.Core.Entities
{
    public class Order:BaseEntity
    {
        public int StudentId { get; set; } 
        [Required] 
        public string PaymentMethod { get; set; } 

        [Required] 
        public string Status { get; set; } 

        [Required] 
        public int TotalAmount { get; set; }

        [Column(TypeName = "decimal(8,2)")] 
        public decimal? Discount { get; set; }

        // Navigation Property
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        public ICollection<Course> courses { set; get; } = new List<Course>();
    
    }
}
