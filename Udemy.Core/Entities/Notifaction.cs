using System.ComponentModel.DataAnnotations;

namespace Udemy.Core.Entities
{
    public class Notifaction
    {
        [Key]
        public int NotifactionId { get; set; }


        [Required(ErrorMessage = "Content is Required")]

        public string NotifactionContent { get; set; }

        public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}
