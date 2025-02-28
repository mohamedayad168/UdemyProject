using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Udemy.Core.Enums;
using Udemy.Core.Utils;

namespace Udemy.Core.Entities
{
    public class Progress : BaseEntity
    {
        public int StudentId { get; set; }
        public int LessonId { get; set; }
        public string Status { get; set; } = ProgressStatus.NOT_STARTED;


        // Navigation Properties
        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
    }
}