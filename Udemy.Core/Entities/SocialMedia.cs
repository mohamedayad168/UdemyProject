using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Core.Entities
{
    public class SocialMedia : BaseEntity
    {
        [StringLength(20)]
        public string Name { get; set; }

        public string Link { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
