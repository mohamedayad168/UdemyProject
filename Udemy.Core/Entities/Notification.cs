using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Core.Entities
{
    public class Notification : BaseEntity
    {
        [Required(ErrorMessage = "Content is Required")]
        public string Content { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}
