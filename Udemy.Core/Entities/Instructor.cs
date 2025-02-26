using System.ComponentModel.DataAnnotations;

namespace Udemy.Core.Entities;
public class Instructor : ApplicationUser
{
    [StringLength(20)]
    public string? Title { get; set; }
    [StringLength(50)]
    public string? Bio { get; set; }
    public int? TotalCourses { get; set; }
    public int? TotalReviews { get; set; }
    public int? TotalStudents { get; set; }

    public List<Course> Courses { get; set; }
}
