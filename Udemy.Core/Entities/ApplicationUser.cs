using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Udemy.Core.Entities;
public class ApplicationUser : IdentityUser<int>
{
    [Required(ErrorMessage = "First Name Is Required")]
    [StringLength(50)]

    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name Is Required")]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "This Field Is Required")]
    [StringLength(50)]
    public string CountryName { get; set; }

    [Required(ErrorMessage = "This Field Is Required")]
    [StringLength(50)]
    public string City { get; set; }

    [Required(ErrorMessage = "This Field Is Required")]
    [StringLength(50)]
    public string? State { get; set; }

    [Required(ErrorMessage = "This Field Is Required")]
    [Range(minimum: 16, maximum: 65)]
    public int Age { get; set; } // TINYINT maps to byte

    [Required]
    [StringLength(1)]
    public string Gender { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? ModifiedDate { get; set; }
    public bool? IsDeleted { get; set; } = false;


    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    public ICollection<SocialMedia> SocialMedia { get; set; } = new List<SocialMedia>();
    public ICollection<Ask> Asks { get; set; } = new List<Ask>();
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();

}
