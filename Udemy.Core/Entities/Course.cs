using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Core.Entities;
public class Course : BaseEntity
{
    [StringLength(20), UniqeCourseTitle]
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string CourseLevel { get; set; } //change from level to courselevel to change database [level]
    [Column(TypeName = "DECIMAL(8, 2)")]
    public decimal? Discount { get; set; }
    [Column(TypeName = "DECIMAL(8, 2)")]
    public decimal Price { get; set; }
    public decimal Duration { get; set; }
    [StringLength(20)]
    public string Language { get; set; }
    public string? ImageUrl { get; set; }
    public string? VideoUrl { get; set; }
    public int NoSubscribers { get; set; }
    public bool IsFree { get; set; }
    public bool IsApproved { get; set; }

    [StringLength(20)]
    public string? BestSeller { get; set; }  
    public decimal CurrentPrice { get; set; }

    [Column(TypeName = "DECIMAL(2, 1)")]
    [Range(0.0, 5.0)]
    public decimal? Rating { get; set; }


    public int SubCategoryId { get; set; }
    [ForeignKey("SubCategoryId")]
    public SubCategory SubCategory { get; set; }
    public int InstructorId { get; set; }
    [ForeignKey("InstructorId")]
    public Instructor Instructor { get; set; }
    public List<CourseOrder> OrderCourses { get; set; }
    public List<CartCourse> CartCourses { get; set; }
    public List<Enrollment> Enrollments { get; set; }
    public List<Section> Sections { get; set; }
    public List<Ask> Asks { get; set; }
    public List<CourseRequirement> CourseRequirements { get; set; }
    public List<CourseGoals> CourseGoals { get; set; }
}
