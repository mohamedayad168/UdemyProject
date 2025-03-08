using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;

namespace Udemy.Service.DataTransferObjects.Read
{
    public class CourseRDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        [StringLength(20)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Level { get; set; }
        public decimal? Discount { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        [StringLength(20)]
        public string Language { get; set; }
        public string? ImageUrl { get; set; }
        public string? VideoUrl { get; set; }
        public int NoSubscribers { get; set; }
        public bool IsFree { get; set; }
        public bool IsApproved { get; set; }
        public decimal CurrentPrice { get; private set; }
        [Range(0.0, 5.0)]
        public decimal? Rating { get; set; }
        public int SubCategoryId { get; set; }
        public int InstructorId { get; set; }
    }
}
