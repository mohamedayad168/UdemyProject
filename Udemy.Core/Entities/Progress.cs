using System.ComponentModel.DataAnnotations.Schema;
using Udemy.Core.Enums;
using Udemy.Core.Utils;

namespace Udemy.Core.Entities
{
    public class Progress : BaseEntity
    {
        public string Status { get; set; } = ProgressStatus.NOT_STARTED;

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        public int LessonId { get; set; }
        [ForeignKey("LessonId")]
        public Lesson Lesson { get; set; }
    }
}