using System.ComponentModel.DataAnnotations;

namespace Udemy.Core.Entities;
public class Question : BaseEntity
{
    [StringLength(20)]
    public string QuestionTitle { get; set; }
    public string QuestionContent { get; set; }
    public int CourseId { get; set; }
    public int UserId { get; set; }
}
