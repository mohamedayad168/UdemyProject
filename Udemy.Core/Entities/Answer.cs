namespace Udemy.Core.Entities;
public class Answer : BaseEntity
{
    public string AnswerContent { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; }

    public int UserId { get; set; }
    public ApplicationUser User { get; set; }
}
