using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Core.Entities;

public class Student: ApplicationUser
{
    public string? Title { get; set; }

    public string? Bio { get; set; }

    [Required(ErrorMessage = "Wallet Is Required Field")]
    public decimal Wallet { get; set; }


   
    public Cart Cart { get; set; } 
    // Navigation Properties
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<StudentGrade> StudentGrades { get; set; } = new List<StudentGrade>();
    public ICollection<Progress> Progresses { get; set; } = new List<Progress>();
}
