using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Service.DataTransferObjects.Create
{
   public class SectionCDTO
    {
        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        [Required]
        public int CourseId { get; set; }
        public int NoLessons { get; set; }

        public List<LessonCDto> Lessons { get; set; } = new List<LessonCDto>();
    }

}
