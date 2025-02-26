using System.ComponentModel.DataAnnotations;

namespace Udemy.Core.Entities;
public class CourseGoals
{
    [StringLength(50)]
    public string Goal { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }
}
