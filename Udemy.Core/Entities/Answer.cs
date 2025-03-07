using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Core.Entities;
public class Answer : BaseEntity
{
    public string Content { get; set; }

    public int AskId { get; set; }
    [ForeignKey("AskId")]
    public Ask Ask { get; set; }

    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public ApplicationUser User { get; set; }
}
