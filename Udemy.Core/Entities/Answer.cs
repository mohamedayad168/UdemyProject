using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Core.Entities;
public class Answer : BaseEntity
{
    public string Content { get; set; }

    public int QuestionId { get; set; }
    [ForeignKey("QuestionId")]
    public Ask Question { get; set; }

    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public ApplicationUser User { get; set; }
}
