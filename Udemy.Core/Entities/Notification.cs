using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Core.Entities
{
    public class Notification : BaseEntity
    {



        [Required(ErrorMessage = "Content is Required")]

        public string Content { get; set; }

        [MaxLength(255)]
        public string Link { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }


    }
}
