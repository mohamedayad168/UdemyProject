using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Udemy.Core.Enums;

namespace Udemy.Core.Entities;
public class Course : BaseEntity
{
    [StringLength(20)]
    public string Title { get; set; }
    public string Description { get; set; }
    public CourseStatus Status { get; set; }
    public string Level { get; set; }
    public decimal Discount { get; set; }
    public decimal Price { get; set; }
    public int Duration { get; set; }
    [StringLength(20)]
    public string Language { get; set; }
    public string? ImageUrl { get; set; }
    public string? VideoUrl { get; set; }
    public int No_Subscribers { get; set; }
    public bool IsFree { get; set; }
    public bool IsApproved { get; set; }

    public int InstructorId { get; set; }
    [ForeignKey("InstructorId")]
    public Instructor Instructor { get; set; }

    public int QuizId { get; set; }
    [ForeignKey("QuizId")]
    public Quiz Quiz { get; set; }

    public List<Cart> Carts { get; set; }
    public List<Enrollment> Enrollments { get; set; }
    public List<Order> Orders { get; set; }
    public List<Subcategory> Subcategories { get; set; }
    public List<Section> Sections { get; set; }
    public List<Ask> Questions { get; set; }
    public List<CourseRequirement> CourseRequirements { get; set; }
    public List<CourseGoals> CourseGoals { get; set; }
}
