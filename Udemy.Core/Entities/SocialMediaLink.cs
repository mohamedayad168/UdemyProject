using System.ComponentModel.DataAnnotations;

namespace Udemy.Core.Entities
{
    public class SocialMediaLink
    {
        [Key]
        public int SocialMediaLinkId { get; set; }


        public int UserId { get; set; }
        public ApplicationUser User { get; set; }


        public int SocialMediaId { get; set; }

        public SocialMedia SocialMedia { get; set; }

        [Required]
        [StringLength(50)]
        public string Link { get; set; }
    }
}
