using System.ComponentModel.DataAnnotations;

namespace Udemy.Core.Entities
{
    public class SocialMedia
    {
        [Key]
        public int SocialMediaId { get; set; }

        [Required]
        [StringLength(20)]
        public string SocialMediaName { get; set; }

        [Required]
        public byte[] SocialMediaImage { get; set; }


        public ICollection<SocialMediaLink> SocialMediaLinks { get; set; } = new List<SocialMediaLink>();
    }
}
