using System.ComponentModel.DataAnnotations;

namespace Udemy.Core.Entities;

public class Student: ApplicationUser
{
    [ MaxLength(50)]
    public string? Title { get; set; }
    public string? Bio { get; set; }

    public decimal Wallet { get; set; }


   
    public Cart Cart { get; set; } 
    // Navigation Properties
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<StudentGrade> StudentGrades { get; set; } = new List<StudentGrade>();
    public ICollection<Progress> Progresses { get; set; } = new List<Progress>();
}
