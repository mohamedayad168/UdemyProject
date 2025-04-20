using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;

namespace Udemy.Core.IRepository
{
    public interface IQuizQuestionRepository : IRepositoryBase<QuizQuestion>
    {
        Task<IEnumerable<QuizQuestion>> GetQuestionsByQuizIdAsync(int quizId, RequestParamter requestParamter, bool trackChanges);
    }

}
