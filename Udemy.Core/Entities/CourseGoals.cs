using System.ComponentModel.DataAnnotations;

namespace Udemy.Core.Entities;
public class CourseGoals
{
    public int CourseId { get; set; }
    [StringLength(50)]
    public string CourseGoal { get; set; }
}
