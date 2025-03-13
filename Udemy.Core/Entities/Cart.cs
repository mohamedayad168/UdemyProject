using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Core.Entities
{
    public class Cart : BaseEntity
    {
        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        private int? amount;
        public int? Amount
        {
            get
            {
                return Convert.ToInt32(
                    CartCourses
                    .Where(cc => cc.Course != null)
                    .Sum(cc => cc.Course.CurrentPrice)
                );
            }
            set
            {
                this.amount = value;
            }
        }

        // Navigation Property
        public Student Student { get; set; }

        public List<CartCourse> CartCourses { get; set; } = new List<CartCourse>();
    }
}

