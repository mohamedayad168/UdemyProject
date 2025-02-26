using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Core.Entities
{
    public class Section : BaseEntity
    {
        [StringLength(20)]
        public string Title { get; set; }

        public int Order { get; set; } //newly Added

        public int Duration { get; set; }
        public int NoLessons { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public Course Course { get; set; }
        public List<Lesson> Lessons { get; set; } = new();
    }
}
