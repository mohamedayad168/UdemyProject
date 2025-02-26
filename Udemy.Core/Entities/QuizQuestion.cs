﻿using System;
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


        public string? ChoiceA { get; set; }
        public string? ChoiceB { get; set; }
        public string? ChoiceC { get; set; }

        [Required]
        public string AnswerTxt { get; set; } = string.Empty; 
        [Required]
       
        public Quiz Quiz { get; set; }
    }
}
