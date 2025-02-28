using System.ComponentModel.DataAnnotations;

namespace Udemy.Core.Entities;

public class Student: ApplicationUser
{
    [Required, MaxLength(20)]
    public string? Title { get; set; }
    public string? Bio { get; set; }

    // Navigation Properties
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public ICollection<Cart> Carts { get; set; } = new List<Cart>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<StudentGrade> StudentGrades { get; set; } = new List<StudentGrade>();
    public ICollection<Progress> Progresses { get; set; } = new List<Progress>();
}
