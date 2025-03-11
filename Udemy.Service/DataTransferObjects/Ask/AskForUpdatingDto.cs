using System.ComponentModel.DataAnnotations;

namespace Udemy.Service.DataTransferObjects.Ask;
public class AskForUpdatingDto
{
    [StringLength(20 , ErrorMessage = "Maximum length for the Title is 20 characters.")]
    public string Title { get; set; }
    public string Content { get; set; }
}
