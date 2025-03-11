using System.ComponentModel.DataAnnotations;
using Udemy.Service.DataTransferObjects.User;

namespace Udemy.Service.DataTransferObjects.Student;
public class StudentForUpdatingDto: UserForUpdatingDto
{
    [Required(ErrorMessage = "Title is Required Field.")]
    [MaxLength(20 , ErrorMessage = "Maximum length for the Title is 20 characters.")]
    public string Title { get; set; }

    public string? Bio { get; set; }

    [Required(ErrorMessage = "Wallet is Required Field")]
    public decimal Wallet { get; set; }
}
