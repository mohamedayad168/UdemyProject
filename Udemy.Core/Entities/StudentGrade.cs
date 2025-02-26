using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Core.Entities;
public class StudentGrade
{
    [Column(TypeName = "Student_Id")]
    public int StudentId { get; set; } 

    public int QuizId { get; set; } 

    [Required] 
    [Column(TypeName = "decimal(8,2)")] 
    public decimal Grade { get; set; }

    [Required] 
    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; } 

    public bool IsDeleted { get; set; } 

    // Navigation Properties (Assuming Student & Quiz Tables Exist)
    public Student Student { get; set; }
    public Quiz Quiz { get; set; }
}
