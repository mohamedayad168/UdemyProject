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
        public int QuizId { get; set; }
        [Required]
        public QuestionTypes Type { get; set; }


        [Required]
        public string QuestionTxt { get; set; } = string.Empty;


        public string? ChoiseA { get; set; }
        public string? ChoiseB { get; set; }
        public string? ChoiseC { get; set; }

        [Required]
        public string AnswerTxt { get; set; } = string.Empty; 
        [Required]
       
        public Quiz Quiz { get; set; }
    }
}
