namespace Udemy.Service.DataTransferObjects.Read;
public class AnswerDto
{
    public int Id { get; set; }
    public int userId { get; set; }
    public int askId { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Content { get; set; }
}
