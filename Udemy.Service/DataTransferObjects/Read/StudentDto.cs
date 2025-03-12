using System.ComponentModel.DataAnnotations;

namespace Udemy.Service.DataTransferObjects.Read;
public class StudentDto : UserDto
{
    public string Title { get; set; }
    public string? Bio { get; set; }
    public decimal Wallet { get; set; }
}
