using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;

namespace Udemy.Core.IRepository
{
    public interface IQuizRepository
    {
        Task<IEnumerable<Quiz>> GetQuizzesByCourseIdAsync(int courseId, RequestParamter requestParamter, bool trackChanges);
        Task<IEnumerable<QuizQuestion>> GetQuestionsByQuizIdAsync(int quizId, RequestParamter requestParamter, bool trackChanges);
    }
}
