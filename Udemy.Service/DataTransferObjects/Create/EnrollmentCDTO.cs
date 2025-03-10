using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Service.DataTransferObjects.Create
{
    public class EnrollmentCDTO
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime? CompletionDate { get; set; }

        [StringLength(50)]
        public string? Status { get; set; }

        [Range(0, 5)]
        public decimal? Rating { get; set; }

        [StringLength(50)]
        public string? Comment { get; set; }

        [StringLength(500)]
        public string? CertificationUrl { get; set; }

        [Range(0, 100)]
        public decimal? ProgressPercentage { get; set; } = 0;
    }
}