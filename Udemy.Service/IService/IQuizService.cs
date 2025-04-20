using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;

namespace Udemy.Service.IService
{
    public interface IQuizService
    {
          Task<QuizForExamRDTO> GetQuizWithQuestionsByCourseIdAsync(int courseId, bool trackChanges = false);
          Task<StudentGradeRDTO> EvaluateQuizAsync(int userId,QuizAnswersForEvaluationCDTO quizAnswersForEvaluationCDTO);
          Task<StudentGradeRDTO> GetStudentGradeByCourseIdAsync(int studentId, int courseId);
          Task<QuizWithAnswersRDTO> GetQuizWithQuestionsAndAnswersByCourseIdAsync(int courseId);
          Task<QuizWithAnswersRDTO> CreateQuizAsync(QuizCDTO quizCDTO);
        

            
          

    }

}
