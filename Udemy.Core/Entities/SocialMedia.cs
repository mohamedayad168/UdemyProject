using System.ComponentModel.DataAnnotations;

namespace Udemy.Core.Entities
{
    public class SocialMedia : BaseEntity
    {
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        [StringLength(20)]
        public string SocialMediaName { get; set; }

        [Required]
        public byte[] SocialMediaImage { get; set; }



    }
}
