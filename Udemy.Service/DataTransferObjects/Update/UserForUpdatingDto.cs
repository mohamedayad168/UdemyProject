using System.ComponentModel.DataAnnotations;

namespace Udemy.Service.DataTransferObjects.Update;
public class UserForUpdatingDto
{
    [Required(ErrorMessage = "Username is Required Field")]
    public string UserName { get; init; }

    [Required(ErrorMessage = "First Name Is Required Field.")]
    [StringLength(20 , ErrorMessage = "Maximum length for the First Name is 20 characters.")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name Is Required Field")]
    [StringLength(20 , ErrorMessage = "Maximum length for the Last Name is 20 characters.")]
    public required string LastName { get; set; }

    [Required(ErrorMessage = "Country Name Is Required Field")]
    [StringLength(20 , ErrorMessage = "Maximum length for the Country Name is 20 characters.")]
    public required string CountryName { get; set; }

    [Required(ErrorMessage = "City Is Required Field")]
    [StringLength(20 , ErrorMessage = "Maximum length for the City is 20 characters.")]
    public required string City { get; set; }

    [StringLength(20 , ErrorMessage = "Maximum length for the State is 20 characters.")]
    public string? State { get; set; }

    [Required(ErrorMessage = "Age Is Required Field")]
    [Range(minimum: 16 , maximum: 65 , ErrorMessage = "The Age must be between 16 and 65.")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Gender Is Requierd Field")]
    [StringLength(1 , ErrorMessage = "Maximum length for the Gender is 1 character.")]
    public string Gender { get; set; }
}
