using System.ComponentModel.DataAnnotations;

namespace Udemy.Service.DataTransferObjects.Create;
public class StudentForCreationDto : UserForCreationDto
{
    [Required(ErrorMessage = "Title is Required Field.")]
    [MaxLength(20 , ErrorMessage = "Maximum length for the Title is 20 characters.")]
    public string Title { get; set; }

    public string? Bio { get; set; }

    [Required(ErrorMessage = "Wallet is Required Field")]
    public decimal Wallet { get; set; }
}
