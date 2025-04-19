using System.ComponentModel.DataAnnotations;

namespace Udemy.Service.DataTransferObjects.Create
{
    public class LessonCDto
    {
        public string ArticleContent { get; set; }
        public string Title { get; set; }
        public string VideoUrl { get; set; }

       
        public decimal Duration { get; set; }
        public bool? IsDeleted { get; set; }
        public string Type { get; set; }

        public int SectionId { get; set; } 


    }
}

