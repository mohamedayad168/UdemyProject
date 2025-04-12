using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Views
{
    public class VSupDimQuiz
    {
        public int? CourseId { get; set; }
        public int? QuizId { get; set; }
        public int? MultipleChoiceCount { get; set; }
        public int? TrueOrFalseCount { get; set; }
    }
}
