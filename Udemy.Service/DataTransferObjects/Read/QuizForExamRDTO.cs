using Udemy.Core.Entities;

namespace Udemy.Service.DataTransferObjects.Read
{
    public class QuizForExamRDTO
    {
        public int Id { get; set; }
        public int courseId { get; set; }
        public List<QuestionForExamRDTO> Questions { get; set; }


        public QuizForExamRDTO()
        {
            
        }
        public QuizForExamRDTO(Quiz quiz)
        {
            Id = quiz.Id;
            courseId = quiz.CourseId;
            Questions = quiz.QuizQuestion.Select(q => new QuestionForExamRDTO(q)).ToList();
            
        }

    }

    public class QuizWithAnswersRDTO
    {
        public int Id { get; set; }
        public int courseId { get; set; }
        public List<QuestionWithAnswersRDTO> Questions { get; set; }


        public QuizWithAnswersRDTO()
        {

        }
        public QuizWithAnswersRDTO(Quiz quiz)
        {
            Id = quiz.Id;
            courseId = quiz.CourseId;
            Questions = quiz.QuizQuestion.Select(q => new QuestionWithAnswersRDTO(q)).ToList();

        }

    }

    public class QuestionWithAnswersRDTO
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string Type { get; set; }
        public string QuestionTxt { get; set; }
        public string? ChoiceA { get; set; }
        public string? ChoiceB { get; set; }
        public string? ChoiceC { get; set; }
        public string AnswerTxt { get; set; }

        public QuestionWithAnswersRDTO()
        {

        }

        public QuestionWithAnswersRDTO(QuizQuestion quizQuestion)
        {

            Id = quizQuestion.Id;
            QuizId = quizQuestion.QuizId;
            Type = quizQuestion.Type;
            QuestionTxt = quizQuestion.QuestionTxt;
            ChoiceA = quizQuestion.ChoiceA;
            ChoiceB = quizQuestion.ChoiceB;
            ChoiceC = quizQuestion.ChoiceC;
            AnswerTxt = quizQuestion.AnswerTxt;

        }
    }


    public class QuizAnswersForEvaluationCDTO
    {
        public int QuizId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public List<QuestionAnswerForEvaluationCDTO> Answers { get; set; }
    }

    public class QuestionAnswerForEvaluationCDTO
    {
        public int QuizId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
    }


}
