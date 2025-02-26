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
    public class QuizQuestion : BaseEntity
    {
        public QuestionTypes QuestionType { get; set; }

        [StringLength(50)]
        [Column(TypeName = "Question_Text")]
        public string QuestionText { get; set; }

        public string? Choise1 { get; set; }
        public string? Choise2 { get; set; }
        public string? Choise3 { get; set; }

        public string AnswerText { get; set; }

        public Quiz Quiz { get; set; }
        [Column(TypeName = "Quiz_Id")]
        public int QuizId { get; set; }
    }
}
