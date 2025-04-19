using Microsoft.AspNetCore.Http;

using System.ComponentModel.DataAnnotations;

namespace Udemy.Service.DataTransferObjects.Create
{
    public class LessonCDto
    {
        public string? ArticleContent { get; set; }

        public decimal Duration { get; set; }
        public bool? IsDeleted { get; set; }

        public string Title { get; set; }
        public string Type { get; set; }
        public IFormFile VideoUrl { get; set; }
        public int SectionId { get; set; }
    }
}

