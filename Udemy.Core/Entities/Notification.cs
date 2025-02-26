using System.ComponentModel.DataAnnotations;

namespace Udemy.Core.Entities
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }


        [Required(ErrorMessage = "Content is Required")]

        public string NotificationContent { get; set; }

        public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}
