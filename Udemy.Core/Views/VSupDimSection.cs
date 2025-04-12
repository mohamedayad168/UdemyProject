using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Views
{
    public class VSupDimSection
    {
        public int? SectionId { get; set; }
        public int? CourseId { get; set; }
        public string? Title { get; set; }
        public decimal? Duration { get; set; }
        public int? NoLessons { get; set; }
        public int? VideoCount { get; set; }
        public int? ArticleCount { get; set; }
    }
}
