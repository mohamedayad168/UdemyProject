using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.Enums;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;
using Udemy.Infrastructure.Extensions;

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



        public async Task<PaginatedRes<Instructor>> GetPageAsync(PaginatedSearchReq searchReq, DeletionType deletionType, bool trackChanges)
        {
            IQueryable<Instructor> query;

            if (searchReq.SearchTerm!.Length > 0)
            {
                query = FindAll(trackChanges, deletionType)
                .Where(x =>
                    x.FirstName.ToLower().Contains(searchReq.SearchTerm!.Trim().ToLower()) ||
                    x.LastName.ToLower().Contains(searchReq.SearchTerm.Trim().ToLower()) ||
                    x.Title.ToLower().Contains(searchReq.SearchTerm.Trim().ToLower())
                 );
            }
            else
            {
                query = FindAll(trackChanges, deletionType);
            }


            var instructors = await query
                .Sort(searchReq.OrderBy!)
                .Skip((searchReq.PageNumber - 1) * searchReq.PageSize)
                .Take(searchReq.PageSize)
                .ToListAsync();

            var response = new PaginatedRes<Instructor>
            {
                CurrentPage = searchReq.PageNumber,
                PageSize = searchReq.PageSize,
                TotalItems = await query.CountAsync(),
                Data = instructors,
            };
            return response;
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



            dbContext.Entry(instructor).State = EntityState.Modified;
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
                                 .Where(course => course.InstructorId == instructorId && !course.IsDeleted)
                                 .ToListAsync();
        }
    }
}
