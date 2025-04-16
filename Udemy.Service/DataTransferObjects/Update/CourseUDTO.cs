using System.ComponentModel.DataAnnotations;

namespace Udemy.Service.DataTransferObjects.Update
{
    public class CourseUDTO
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;

        [StringLength(20)]
        [Required]
        public string Title { get; set; }

        [StringLength(50)]
        [Required]
        public string Description { get; set; }

        public string CourseLevel { get; set; }
        public decimal? Discount { get; set; }
        public decimal Price { get; set; }

        [StringLength(20)]
        public string Language { get; set; }

        public string? ImageUrl { get; set; }
        public string? VideoUrl { get; set; }

        public int SubCategoryId { get; set; }

        public int InstructorId { get; set; }

        // ✅ New fields
        public string Goals { get; set; } 
        public string Requirements { get; set; } 

        public int? CategoryId { get; set; } // optional if needed
    }
}
