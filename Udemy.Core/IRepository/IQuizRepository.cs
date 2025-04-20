using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;

namespace Udemy.Core.IRepository
{
    public interface IQuizRepository:IRepositoryBase<Quiz>
    {
        Task<Quiz> GetQuizWithQuestionsByCourseIdAsync(int courseId, bool trackChanges);
        Task AddQuizWithQuestionsAsync(Quiz quiz,List<QuizQuestion> quizQuestions);
    }


}
