using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;

namespace Udemy.Infrastructure.Repository
{
    public class QuizRepository : RepositoryBase<Quiz>, IQuizRepository
    {
        private readonly ApplicationDbContext _context;
        public QuizRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._context = dbContext;
        }
        public async Task<IEnumerable<Quiz>> GetQuizzesByCourseIdAsync(int courseId, RequestParamter requestParamter, bool trackChanges)
        {
            return await FindAll(trackChanges)
                .Where(q => q.CourseId == courseId && q.IsDeleted == false)
                .Skip((requestParamter.PageNumber - 1) * requestParamter.PageSize)
                .Take(requestParamter.PageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<QuizQuestion>> GetQuestionsByQuizIdAsync(int quizId, RequestParamter requestParamter, bool trackChanges)
        {
            return await _context.Set<QuizQuestion>()
                .Where(q => q.QuizId == quizId)
                .Skip((requestParamter.PageNumber - 1) * requestParamter.PageSize)
                .Take(requestParamter.PageSize)
                .ToListAsync();
        }
    }
}
