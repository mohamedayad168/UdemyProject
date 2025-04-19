using Udemy.Core.Entities;
using Udemy.Core.IRepository;

namespace Udemy.Infrastructure.Repository
{
    public class StudentGradeRepository:RepositoryBase<StudentGrade>, IStudentGradeRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentGradeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._context = dbContext;
        }


    }




}
