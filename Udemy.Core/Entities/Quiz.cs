using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Core.Entities
{
    public class Quiz : BaseEntity
    {
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        public List<QuizQuestion> QuizQuestion { get; set; } = new List<QuizQuestion>();
        public List<StudentGrade> StudentGrades { get; set; } = new List<StudentGrade>();
    }
}
