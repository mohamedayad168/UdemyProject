using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Service.DataTransferObjects.Read
{
 
        public class EnrollmentRDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty; 
        public int CourseId { get; set; }
        public string CourseTitle { get; set; } = string.Empty; 
        public DateTime StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal? Rating { get; set; }
        public string? Comment { get; set; }
        public string? CertificationUrl { get; set; }
        public decimal? ProgressPercentage { get; set; }
    }
}
