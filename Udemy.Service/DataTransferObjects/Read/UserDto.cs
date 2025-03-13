using System.ComponentModel.DataAnnotations;

namespace Udemy.Service.DataTransferObjects.Read;
public class UserDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string UserName { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CountryName { get; set; }
    public string City { get; set; }
    public string? State { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
}
