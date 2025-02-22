using System.ComponentModel.DataAnnotations;

namespace Udemy.Core.Entities;
public class Instructor : BaseEntity
{
    [StringLength(20)]
    public string InstructorTitle { get; set; }
    [StringLength(50)]
    public string InstructorBio { get; set; }
    public int TotalCourses { get; set; }
    public int TotalReviews { get; set; }
    public int TotalStudents { get; set; }

    public List<Answer> Answers { get; set; }
    public List<Course> Courses { get; set; }
}
