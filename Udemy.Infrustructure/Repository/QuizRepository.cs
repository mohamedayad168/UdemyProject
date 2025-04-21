using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;

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

        public async Task AddQuizWithQuestionsAsync(Quiz quiz, List<QuizQuestion> quizQuestions)
        {
             using var transaction =  _context.Database.BeginTransaction();

            try
            {
                // Create and save the quiz first to generate its ID
                await _context.Quizzes.AddAsync(quiz);
                await _context.SaveChangesAsync();

                int maxId = await _context.QuizQuestions
                    .Where(q => q.QuizId == quiz.Id)
                    .MaxAsync(q => (int?)q.Id) ?? 0;

                     int nextId = maxId + 1;
                foreach (var question in quizQuestions)
                {
                    
                    question.QuizId = quiz.Id;
                    question.Id =nextId++ ;
                }
                // Create and save the quiz question
                quiz.QuizQuestion=quizQuestions;
                await _context.SaveChangesAsync();
               
                // Commit transaction if everything succeeded
                await transaction.CommitAsync();
            }
            catch
            {
                // Rollback if anything fails
                await transaction.RollbackAsync();
                throw; // Re-throw the exception
            }


        }

       public void DeleteQuizWithQuestionsAsync(Quiz quiz)
        {
            foreach(var question in quiz.QuizQuestion)
            {
               question.IsDeleted = true;
            }
            Delete(quiz);

        }

    }




}
