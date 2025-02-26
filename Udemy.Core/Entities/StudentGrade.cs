using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Core.Entities;
public class StudentGrade
{
    public decimal Grade { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? ModifiedDate { get; set; }
    public bool? IsDeleted { get; set; } = false;

    [Column("Student_id")]
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public string QuizId { get; set; }
    public Quiz Quiz { get; set; }
}
