using Microsoft.AspNetCore.Http;

namespace Udemy.Service.DataTransferObjects.Create
{
    public class LessonCDto
    {
        public string? ArticleContent { get; set; }

        public int Duration { get; set; }
        public bool? IsDeleted { get { return false; } }

        public string Title { get; set; }
        public string Type { get; set; }
        public IFormFile VideoUrl { get; set; }
        public int SectionId { get; set; }
    }
}

