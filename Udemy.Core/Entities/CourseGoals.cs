using System.ComponentModel.DataAnnotations;

namespace Udemy.Core.Entities;
public class CourseGoals: BaseEntityWithoutId
{
    [StringLength(50)]
    public string Goal { get; set; }
    //public DateTime CreatedDate { get; set; } = DateTime.Now;
    //public DateTime? ModifiedDate { get; set; }
    //public bool? IsDeleted { get; set; } = false;

    public int CourseId { get; set; }
    public Course Course { get; set; }
}
