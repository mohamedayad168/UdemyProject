using Udemy.Core.Entities;

namespace Udemy.Service.DataTransferObjects.Create
{
    public class QuizCDTO
    {
        public int CourseId { get; set; }

        public List<QuizQuestionCDTO> QuizQuestions { get; set; }

        public Quiz MapToEntity()
        {
            return new Quiz
            {
                CourseId = CourseId,
                QuizQuestion = QuizQuestions.Select(q => new QuizQuestion
                {

                    Type = q.Type,
                    QuestionTxt = q.QuestionTxt,
                    ChoiceA = q.ChoiceA,
                    ChoiceB = q.ChoiceB,
                    ChoiceC = q.ChoiceC,
                    AnswerTxt = q.AnswerTxt

                }).ToList()
            };
        }

    }

    public class QuizQuestionCDTO
    {
       
        public string Type { get; set; }
        public string QuestionTxt { get; set; }
        public string? ChoiceA { get; set; }
        public string? ChoiceB { get; set; }
        public string? ChoiceC { get; set; }
        public string AnswerTxt { get; set; }


        

    }

}
