using Udemy.Core.Enums;

namespace Udemy.Core.Entities
{
    public class Progress:BaseEntity
    {
        public int ProgressPercentage { get; set; } //0-100

        public ProgressStatus Status { get; set; }

        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }



    }
}