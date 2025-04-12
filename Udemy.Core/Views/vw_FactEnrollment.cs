using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Views
{
    public class vw_FactEnrollment
    {
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public int? StartDateKey { get; set; }
        public int? CompletionDateKey { get; set; }
        public string? Status { get; set; }
        public decimal? Rating { get; set; }
        public string? Comment { get; set; }
        public string? CertificationUrl { get; set; }
        public decimal? ProgressPercentage { get; set; }
        public decimal? Grade { get; set; }
        public int? GradeDateKey { get; set; }
    }
}
