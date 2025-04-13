using System.ComponentModel.DataAnnotations;
using Udemy.Core.Attribute;

namespace Udemy.Service.DataTransferObjects.Create
{
    public class InstructorCDTO
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Email Is Required Field")]
        [EmailAddress]

        public string Email { get; set; }

        [Required(ErrorMessage = "Username is Required Field")]
        [UniquUsername]
        public string UserName { get; init; }




        [IdentityPassword]
        public string? Password { get; init; }
        public string? ConfirmPassword { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }


        [StringLength(20, ErrorMessage = "Maximum length for the First Name is 20 characters.")]
        public string? FirstName { get; set; }


        [StringLength(20, ErrorMessage = "Maximum length for the Last Name is 20 characters.")]
        public string? LastName { get; set; }


        [StringLength(20, ErrorMessage = "Maximum length for the Country Name is 20 characters.")]
        public string? CountryName { get; set; }


        [StringLength(20, ErrorMessage = "Maximum length for the City is 20 characters.")]
        public string? City { get; set; }

        [StringLength(20, ErrorMessage = "Maximum length for the State is 20 characters.")]
        public string? State { get; set; }


        [Range(minimum: 16, maximum: 65, ErrorMessage = "The Age must be between 16 and 65.")]
        public int? Age { get; set; }


        [StringLength(1, ErrorMessage = "Maximum length for the Gender is 1 character.")]
        public string? Gender { get; set; }

        [StringLength(50)]
        public string? Title { get; set; }

        public string? Bio { get; set; }
    }
}
