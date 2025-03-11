using System.ComponentModel.DataAnnotations;
using Udemy.Service.DataTransferObjects.User;

namespace Udemy.Service.DataTransferObjects.Student;
public class StudentDto : UserDto
{
    public string Title { get; set; }
    public string? Bio { get; set; }
    public decimal Wallet { get; set; }
}
