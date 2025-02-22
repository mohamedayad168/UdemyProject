using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Enums;

namespace Udemy.Core.Entities
{
    public class QuizQuestion
    {
        public Quiz Quiz { get; set; }
        [Column(TypeName ="Quiz_Id")]
        public int QuizId { get; set; }
        public QuestionTypes QuestionType { get; set; }
        [StringLength(50)]
        [Column(TypeName = "Question_Text")]
        public string QuestionText { get; set; }
        [StringLength(50)]
        [Column(TypeName = "Answer_Text")]
        public string AnswerText { get; set; }
    }
}
