using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
//using Microsoft.AspNetCore.Http;
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
        public string CourseLevel { get; set; }
        [Range(0, 100000)]
        public decimal Price { get; set; }
        public decimal CurrentPrice { get{ return Price; } }
        [StringLength(20)]
        public string Language { get; set; } = "en";
        [StringLength(500)]
        public IFormFile? Image { get; set; }
        [StringLength(500)]
        public IFormFile? Video { get; set; }
        public bool IsFree { get; set; }
        public bool IsApproved { get { return false; } }
        public bool IsDeleted { get { return false; } }
        public int SubCategoryId { get; set; }
        public int InstructorId { get; set; }
        public decimal Rating { get { return 0; } }
        public int NoSubscribers { get { return 0; } }
        public DateTime CreatedDate { get { return DateTime.Now; } }
        public decimal Discount { get { return 0; } }

    }
}
