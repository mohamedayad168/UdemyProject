using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.Exceptions;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;

namespace Udemy.Infrastructure.Repository
{
    public class CoursesRepository : RepositoryBase<Course>, ICoursesRepository
    {
        private readonly ApplicationDbContext _context;

        public CoursesRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var course = await GetByIdAsync(id, false) ??
                throw new NotFoundException($"Course with id: {id} doesn't exist");

            course.IsDeleted = true; 
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAllAsync(bool trackChanges)
        {
            return await FindByCondition(c => !c.IsDeleted, trackChanges).ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(c => c.Id == id && !c.IsDeleted, trackChanges)
                .FirstOrDefaultAsync() ??
                throw new NotFoundException($"Course with id: {id} doesn't exist");
        }

        public async Task<Course?> GetByTitleAsync(string title, bool trackChanges)
        {
            return await FindByCondition(c => c.Title == title && !c.IsDeleted, trackChanges)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Course>> GetPageAsync(RequestParamter requestParamter, bool trackChanges)
        {
            return await FindByCondition(c => !c.IsDeleted, trackChanges)
                .Skip((requestParamter.PageNumber - 1) * requestParamter.PageSize)
                .Take(requestParamter.PageSize)
                .Include(c => c.Instructor)
                .Include(c => c.SubCategory)
                .ToListAsync();
        }

        public async Task ToggleApprovedAsync(int id)
        {
            var course = await GetByIdAsync(id, true) ??
                throw new NotFoundException($"Course with id: {id} not found");

            course.IsApproved = !course.IsApproved;
            await SaveChangesAsync();
        }

        public async Task<bool> CheckIfCourseExistsAsync(int id)
        {
            return await _context.Courses.AnyAsync(c => c.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}