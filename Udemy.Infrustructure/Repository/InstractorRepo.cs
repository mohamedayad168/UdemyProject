using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;

namespace Udemy.Infrastructure.Repository.EntityRepos
{
    public class InstructorRepo : RepositoryBase<Instructor>, IInstructorRepo
    {
        private readonly ApplicationDbContext dbContext;


        public InstructorRepo(ApplicationDbContext context) : base(context)
        {
            dbContext = context;

        }

        public async Task<IEnumerable<Instructor>> GetAllInstructorsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .Where(i => i.IsDeleted == false || i.IsDeleted == null)
                .ToListAsync();
        }

        public async Task<Instructor?> GetInstructorByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(i => i.Id == id && (i.IsDeleted == false || i.IsDeleted == null), trackChanges)
                .FirstOrDefaultAsync();
        }

        public async Task<Instructor?> GetInstructorByTitleAsync(string title, bool trackChanges)
        {
            return await FindByCondition(i => i.Title == title && (i.IsDeleted == false || i.IsDeleted == null), trackChanges)
                .FirstOrDefaultAsync();
        }


        public async Task CreateInstructorAsync(Instructor instructor)
        {
            await dbContext.Set<Instructor>().AddAsync(instructor);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteInstructorAsync(Instructor instructor)
        {
            instructor.IsDeleted = true;
            dbContext.Set<Instructor>().Update(instructor);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByInstructorIdAsync(int instructorId)
        {
            return await dbContext.Courses
                  .Include(c => c.Instructor)
                                 .Where(course => course.InstructorId == instructorId)
                                 .ToListAsync();
        }
    }
}
