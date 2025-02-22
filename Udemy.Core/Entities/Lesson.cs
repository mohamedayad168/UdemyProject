using Udemy.Core.Enums;

namespace Udemy.Core.Entities
{
    public class Lesson : BaseEntity
    {
     
        public required string Title { get; set; }
        public int Duration { get; set; }
        public LessonType Type { get; set; }
        public required string Url { get; set; }
        public string? ArticleContent { get; set; }
        public bool IsPreview { get; set; }= false;


        // Navigation Properties
        public int SectionId { get; set; }
        public Section Section { get; set; }
    }
}
