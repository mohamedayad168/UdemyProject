using System.ComponentModel.DataAnnotations;

namespace Udemy.Service.DataTransferObjects.Create;
public class AskForCreationDto
{
    [StringLength(20 , ErrorMessage = "Maximum length for the Title is 20 characters.")]
    public string Title { get; set; }
    public string Content { get; set; }
}
