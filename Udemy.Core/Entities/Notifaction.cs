using System.ComponentModel.DataAnnotations;

namespace Udemy.Core.Entities
{
    public class Notifaction
    {
        [Key]

        public int Id { get; set; }
        [Required(ErrorMessage = "Content is Required")]

        public string NotifactionContent { get; set; }
    }
}
