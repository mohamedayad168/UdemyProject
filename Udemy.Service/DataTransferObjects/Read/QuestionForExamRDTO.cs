using Udemy.Core.Entities;

namespace Udemy.Service.DataTransferObjects.Read
{
    public class QuestionForExamRDTO
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string Type { get; set; }
        public string QuestionTxt { get; set; }
        public string? ChoiceA { get; set; }
        public string? ChoiceB { get; set; }
        public string? ChoiceC { get; set; }

        public QuestionForExamRDTO()
        {
            
        }

        public QuestionForExamRDTO(QuizQuestion quizQuestion)
        {
            
            Id = quizQuestion.Id;
            QuizId = quizQuestion.QuizId;
            Type = quizQuestion.Type;
            QuestionTxt = quizQuestion.QuestionTxt;
            ChoiceA = quizQuestion.ChoiceA;
            ChoiceB = quizQuestion.ChoiceB;
            ChoiceC = quizQuestion.ChoiceC;

        }

    }

}
