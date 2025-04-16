//using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Udemy.Service.DataTransferObjects.Update
{
    public class CourseUDTO
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        [StringLength(20)]
        public string Title { get; set; }
        public string Description { get; set; }

        public string CourseLevel { get; set; }
        public decimal? Discount { get; set; }
        public decimal Price { get; set; }

        [StringLength(20)]
        public string Language { get; set; }
        public string? ImageUrl { get; set; }
        public string? VideoUrl { get; set; }

        public bool? IsFree { get; set; } = false;



        public decimal CurrentPrice { get; private set; }

        [Range(0.0, 5.0)]
        public decimal? Rating { get; set; }


        public int SubCategoryId { get; set; }

        public int InstructorId { get; set; }
    }
}
