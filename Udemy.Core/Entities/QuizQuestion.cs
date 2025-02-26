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
        public QuestionTypes Type { get; set; }

        [StringLength(50)]
        public string QuestionText { get; set; }

        public string? ChoiceA { get; set; }
        public string? ChoiceB { get; set; }
        public string? ChoiceC { get; set; }

        public string AnswerTxt { get; set; }

        public Quiz Quiz { get; set; }
       // [Column(TypeName = "Quiz_Id")]
        [ForeignKey("Quiz")]
        public int QuizId { get; set; }
    }
}
