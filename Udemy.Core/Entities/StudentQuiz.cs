using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Entities
{
    public class StudentQuiz
    {
        public Quiz Quiz { get; set; }
        [Key]
        [Column(TypeName ="Quiz_Id")]
        public int QuizId { get; set; }
        public Course Course { get; set; }
        [Key]
        [Column(TypeName = "Course_Id")]
        public int CourseId { get; set; }
        [Column(TypeName ="decimal(8,2)")]
        public decimal Grade { get; set; }
    }
}
