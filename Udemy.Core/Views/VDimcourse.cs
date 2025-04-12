using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Views
{
    public class VDimcourse
    {
        [Key]
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? CourseLevel { get; set; }
        public decimal? Discount { get; set; }
        public decimal? OriginalPrice { get; set; }
        public decimal? CurrentPrice { get; set; }
        public decimal? Duration { get; set; }
        public int? NoSubscribers { get; set; }
        public decimal? Rating { get; set; }
        public bool? IsFree { get; set; }
        public bool? IsApproved { get; set; }
        public string? Language { get; set; }
        public string? BestSeller { get; set; }
        public string? Category { get; set; }
        public string? SubCategory { get; set; }
        public int? InstructorId { get; set; }
    }
}
