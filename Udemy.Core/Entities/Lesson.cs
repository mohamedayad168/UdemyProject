using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Udemy.Core.Enums;

namespace Udemy.Core.Entities
{
    public class Lesson : BaseEntity
    {
        [StringLength(100)]
        public required string Title { get; set; }
        public decimal Duration { get; set; }
        public string Type { get; set; }
        public string? VideoUrl { get; set; }

        public string? ArticleContent { get; set; }
        //public int Order { get; set; }


        // Navigation Properties
        [ForeignKey("Section")]
        public int SectionId { get; set; }
        public Section Section { get; set; }


        // new table 'progress' navigational property
        public List<Progress> Progresses { get; set; }
    }
}
