using Udemy.Core.Entities;

namespace Udemy.Service.DataTransferObjects.Read;

public class AskRDTO
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public AskRDTO()
    {

    }

    public AskRDTO(Ask ask)
    {
        Id = ask.Id;
        UserName = $"{ask.User.FirstName} {ask.User.LastName}";
        UserId = ask.UserId;
        Title = ask.Title;
        Content = ask.Content;
        CreatedDate = ask.CreatedDate;

    }


}
