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

        public async Task<Quiz> GetQuizWithQuestionsByCourseIdAsync(int courseId, bool trackChanges)
        {
            var quizes = await _context.Set<Quiz>().AnyAsync(q => q.CourseId == courseId && !q.IsDeleted);
            var quiz = await _context.Quizzes.Include(q => q.QuizQuestion).FirstOrDefaultAsync(q => q.CourseId == courseId && !q.IsDeleted);
                
            return quiz;
        }
    }




}
