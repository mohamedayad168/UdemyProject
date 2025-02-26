using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Core.Entities
{
    public class Subcategory : BaseEntity
    {
        [StringLength(20)]
        public required string Name { get; set; }


        //Navigation Properties

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Course> Courses { get; set; } = new();
    }
}
