using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.Enums;
using Udemy.Core.Exceptions;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;
using Udemy.Infrastructure.Extensions;

namespace Udemy.Infrastructure.Repository
{
    public class CoursesRepository(ApplicationDbContext context) : RepositoryBase<Course>(context), ICoursesRepository
    {
        public async Task DeleteAsync(int id)
        {
            var course = await GetByIdAsync(id, true) ??
                throw new NotFoundException($"Course with id: {id} doesn't exist");

            course.IsDeleted = true;
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAllAsync(bool trackChanges)
        {
            return await FindByCondition(c => !c.IsDeleted, trackChanges).ToListAsync();
        }


        public async Task<Course> UpdateAsync(Course course)
        {

            var existingCourse = await context.Courses
                .FirstOrDefaultAsync(c => c.Id == course.Id && !c.IsDeleted);

            if (existingCourse == null)
            {
                throw new NotFoundException($"Course with ID {course.Id} not found.");
            }


            existingCourse.Title = course.Title;
            existingCourse.Description = course.Description;
            existingCourse.Duration = course.Duration;
            existingCourse.Price = course.Price;
            existingCourse.InstructorId = course.InstructorId;
            existingCourse.SubCategoryId = course.SubCategoryId;
            existingCourse.IsApproved = course.IsApproved;
            existingCourse.IsDeleted = course.IsDeleted;

            await context.SaveChangesAsync();

            return existingCourse;
        }


        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }


        public async Task<PaginatedRes<Course>> GetPageAsync(PaginatedSearchReq searchReq, DeletionType deletionType, bool trackChanges)
        {

            IQueryable<Course> query;

            if (searchReq.SearchTerm!.Length > 0)
            {
                query = FindAll(trackChanges, deletionType)
                .Where(x =>
                    x.Title.ToLower().Contains(searchReq.SearchTerm!.Trim().ToLower()) ||
                    x.SubCategory.Name.ToLower().Contains(searchReq.SearchTerm.Trim().ToLower()) ||
                    x.SubCategory.Category.Name.ToLower().Contains(searchReq.SearchTerm.Trim().ToLower())
                 );
            }
            else
            {
                query = FindAll(trackChanges, deletionType);
            }


            var courses = await query
                .Sort(searchReq.OrderBy!)
                .Skip((searchReq.PageNumber - 1) * searchReq.PageSize)
                .Take(searchReq.PageSize)
                .Include(c => c.Instructor)
                .Include(c => c.SubCategory)
                .ToListAsync();

            var response = new PaginatedRes<Course>
            {
                CurrentPage = searchReq.PageNumber,
                PageSize = searchReq.PageSize,
                TotalItems = await query.CountAsync(),
                Data = courses,
            };
            return response;
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

        public async Task ToggleApprovedAsync(int id)
        {
            var course = await GetByIdAsync(id, true) ??
                throw new NotFoundException($"Course with id: {id} not found");

            course.IsApproved = !course.IsApproved;
            await SaveChangesAsync();
        }

        public async Task<bool> CheckIfCourseExistsAsync(int id)
        {
            return await context.Courses.AnyAsync(c => c.Id == id);
        }



        public async Task<IEnumerable<Course>> GetAllByCategoryId(int categoryId)
        {
            var courses = await context.Courses.Include(x => x.SubCategory).Where(x => x.SubCategory.CategoryId == categoryId).Take(20).AsNoTracking().ToListAsync();
            return courses;
        }
        public async Task<IEnumerable<Course>> GetAllBySubcategoryId(int subcategoryId)
        {
            var courses = await context.Courses
                .Where(c => c.SubCategoryId == subcategoryId && !c.IsDeleted)
                .ToListAsync();
            return courses;
        }

        public async Task<IEnumerable<Course>> GetAllWithSearchAsync(CourseRequestParameter requestParamter)
        {
            var courses = await FindAll(false)
                            .Where(x =>
                                x.Title.ToLower().Contains(requestParamter.SearchTerm.Trim().ToLower()) ||
                                x.SubCategory.Name.ToLower().Contains(requestParamter.SearchTerm.Trim().ToLower()) ||
                                x.SubCategory.Category.Name.ToLower().Contains(requestParamter.SearchTerm.Trim().ToLower())
                            )
                            .Include(c => c.Instructor)
                            .Include(c => c.CourseGoals)
                            .Sort(requestParamter.OrderBy)
                            .Skip((requestParamter.PageNumber - 1) * requestParamter.PageSize)
                            .Take(requestParamter.PageSize)
                            .ToListAsync();

            return courses;
        }

        public async Task<int> GetAllWithSearchCountAsync(CourseRequestParameter requestParamter)
        {
            var coursesCount = await FindAll(false)
                            .Where(x =>
                                x.Title.ToLower().Contains(requestParamter.SearchTerm.Trim().ToLower()) ||
                                x.SubCategory.Name.ToLower().Contains(requestParamter.SearchTerm.Trim().ToLower()) ||
                                x.SubCategory.Category.Name.ToLower().Contains(requestParamter.SearchTerm.Trim().ToLower())
                            )
                            .Include(c => c.Instructor)
                            .Include(c => c.CourseGoals)
                            .CountAsync();

            return coursesCount;
        }

        public async Task DeleteCourseAsync(Course course)
        {
            course.IsDeleted = true;
            context.Courses.Update(course);
            await context.SaveChangesAsync();
        }


    }
}