using System.ComponentModel.DataAnnotations;

namespace Udemy.Service.DataTransferObjects.Create
{
    public class CourseRatingCDTO
    {
        [Required]
        public int CourseId { get; set; }
 
      
        public decimal? Rating { get; set; }
        public string? Comment { get; set; }
    }
}