using Microsoft.AspNetCore.Identity;

namespace Udemy.Core.Entities
{
    public class Role : IdentityRole<int>
    {

        public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}
