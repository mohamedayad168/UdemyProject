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
        [Column(TypeName = "Quiz_Id")]
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }

        [Required]
        public QuestionTypes Type { get; set; }


        [Required]
        public string QuestionTxt { get; set; }

        [StringLength(50)]
        public string? ChoiceA { get; set; }
        [StringLength(50)]
        public string? ChoiceB { get; set; }
        [StringLength(50)]
        public string? ChoiceC { get; set; }

        [Required]
        public string AnswerTxt { get; set; }

    }
}
