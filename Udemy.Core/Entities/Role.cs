using System.ComponentModel.DataAnnotations;

namespace Udemy.Core.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }
        public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}
