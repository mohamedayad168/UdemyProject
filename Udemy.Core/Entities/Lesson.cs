using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Core.Entities
{
    public class Lesson : BaseEntity
    {
        public int Id { get; set; }
        public string? ArticleContent { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public decimal Duration { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string Title { get; set; }
        public string Type { get; set; }
        public string VideoUrl { get; set; }


        // Navigation Properties
        [ForeignKey("Section")]
        public int SectionId { get; set; }
        public Section Section { get; set; }


        // new table 'progress' navigational property
        public List<Progress> Progresses { get; set; }
    }
}
