using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;

namespace Udemy.Service.DataTransferObjects.Create
{
    public class CourseCDTO
    {
        [StringLength(20)]
        public string Title { get; set; }
        [StringLength(1500)]
        public string Description { get; set; }
        [StringLength(100)]
        public string Status { get; set; }
        [StringLength(100)]
        public string Level { get; set; }
        [Range(0,100000)]
        public decimal Price { get; set; }
        [StringLength(20)]
        public string Language { get; set; }
        [StringLength(500)]
        public string? ImageUrl { get; set; }
        [StringLength(500)]
        public string? VideoUrl { get; set; }
        public bool IsFree { get; set; }
        public int SubCategoryId { get; set; }
        public int InstructorId { get; set; }
    }
}
