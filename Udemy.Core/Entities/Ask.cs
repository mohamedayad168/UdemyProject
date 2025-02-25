using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Core.Entities;
public class Ask : BaseEntity
{
    [StringLength(20)]
    public string Title { get; set; }
    public string Content { get; set; }

    public int CourseId { get; set; }
    [ForeignKey("CourseId")]
    public Course Course { get; set; }

    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public ApplicationUser User { get; set; }

    public List<Answer> Answers { get; set; }
}
