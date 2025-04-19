using Udemy.Core.Entities;

namespace Udemy.Service.DataTransferObjects.Read
{
    public class StudentGradeRDTO
    {
        public int StudentId { get; set; }
        public int QuizId { get; set; }
        public decimal Grade { get; set; }
        public DateTime CreatedDate { get; set; }
        public StudentGradeRDTO()
        {
            
        }
        public StudentGradeRDTO(StudentGrade studentGrade)
        {
            StudentId = studentGrade.StudentId;
            QuizId = studentGrade.QuizId;
            Grade = studentGrade.Grade;
            CreatedDate = studentGrade.CreatedDate;
            
        }

    }

}
