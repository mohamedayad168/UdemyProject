using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Core.Entities;
public class Question : BaseEntity
{
    [StringLength(20)]
    public string QuestionTitle { get; set; }
    public string QuestionContent { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }

    public int UserId { get; set; }
    public ApplicationUser User { get; set; }

    public List<Answer> Answers { get; set; }
}
