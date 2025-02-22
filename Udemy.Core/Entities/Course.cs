using System.ComponentModel.DataAnnotations;
using Udemy.Core.Enums;

namespace Udemy.Core.Entities;
public class Course : BaseEntity
{
    [StringLength(20)]
    public string Title { get; set; }
    [StringLength(50)]
    public string Description { get; set; }
    public CourseStatus Status { get; set; }
    public string Level { get; set; }
    public decimal Discount { get; set; }
    public decimal Price { get; set; }
    public int Duration { get; set; }
    [StringLength(20)]
    public string Language { get; set; }
    public DateTime CreationDate { get; set; }
    [StringLength(50)]
    public string ImageUrl { get; set; }
    [StringLength(50)]
    public string VideoUrl { get; set; }
    public int No_Subscribers { get; set; }
    public bool IsPaid { get; set; }
    public bool IsApproved { get; set; }

    public int InstructorId { get; set; }
    public Instructor Instructor { get; set; }

    public List<Question> Questions { get; set; }
    public List<CourseGoals> CourseGoals { get; set; }
}
