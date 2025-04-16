using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
//using Microsoft.AspNetCore.Http;
namespace Udemy.Service.DataTransferObjects.Create
{
    public class CourseCDTO
    {

        public string Title { get; set; }
        [StringLength(1500)]
        public string Description { get; set; }

        [StringLength(100)]
        public string CourseLevel { get; set; }
        [Range(0, 100000)]
        public decimal Price { get; set; }
        public decimal CurrentPrice { get { return Price; } }
        [StringLength(20)]
        public string Language { get; set; } = "en";

        public IFormFile ImageUrl { get; set; }


        public IFormFile VideoUrl { get; set; }
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }



        public string? Status { get; set; } = "Archived";

        public int InstructorId { get; set; }
        public decimal? Discount { get { return 0; } }
        public decimal? Rating { get { return 0; } }
        public int? NoSubscribers { get { return 0; } }
        public bool? IsFree { get { return false; } }
        public bool? IsApproved { get { return false; } }
        public bool? IsDeleted { get { return false; } }
        public DateTime? CreatedDate { get { return DateTime.Now; } }

    }
}
