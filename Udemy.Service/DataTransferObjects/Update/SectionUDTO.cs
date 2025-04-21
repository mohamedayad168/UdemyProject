using System.ComponentModel.DataAnnotations;

namespace Udemy.Service.DataTransferObjects.Update
{
    public class SectionUDTO
    {
        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        [Range(0.0, 1000.0)]
        public decimal Duration { get; set; }

        [Range(0, int.MaxValue)]
        public int NoLessons { get; set; }

        [Required]
        public int CourseId { get; set; }
        public bool isDeleted { get; set; }


    }
}
