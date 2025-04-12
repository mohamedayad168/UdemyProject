using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.Exceptions;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Service.Service
{
    public class CoursesService(IRepositoryManager repository, IMapper mapper) : ICoursesService
    {
        public async Task<IEnumerable<CourseRDTO>> GetAllAsync(bool trackChanges)
        {
            var courses = await repository.Courses.GetAllAsync(false);

            return mapper.Map<IEnumerable<CourseRDTO>>(courses);
        }
      
        public async Task<IEnumerable<CourseRDTO>> GetPageAsync(RequestParamter requestParamter, bool trackChanges)
        {
            var courses = await repository.Courses.GetPageAsync(requestParamter, trackChanges);

            return mapper.Map<IEnumerable<CourseRDTO>>(courses);
        }



        public async Task<CourseDetailsRDto> GetCourseDetailsAsync(int id, bool trackChanges)
        {
            var course = await repository.Courses.FindByCondition(c => c.Id == id, trackChanges)
                        .Include(c => c.Instructor)
                        .Include(c => c.SubCategory)
                        .ThenInclude(sc => sc.Category)
                        .Include(c => c.CourseGoals)
                        .Include(c => c.CourseRequirements)
                        .Include(c => c.Sections)
                        .ThenInclude(s => s.Lessons)
                        .FirstOrDefaultAsync();

            return course is null ?
                throw new NotFoundException($"course with id: {id} doesn't exist")
                : new CourseDetailsRDto(course);

            ;

        }


        public async Task<CourseRDTO> GetByIdAsync(int id, bool trackChanges)
        {
            var course = await repository.Courses.GetByIdAsync(id, false);

            return mapper.Map<CourseRDTO>(course);
        }

        public async Task<CourseRDTO?> GetByTitleAsync(string title, bool trackChanges)
        {
            var course = await repository.Courses.GetByTitleAsync(title, false)
                ?? throw new NotFoundException($"couldn't find course with title: {title}");

            return mapper.Map<CourseRDTO>(course);
        }

        public async Task<CourseRDTO> CreateAsync(CourseCDTO courseDto)
        {


            var course = mapper.Map<Course>(courseDto);

            var instructorExists = await repository.Instructors
                .FindByCondition(i => i.Id == courseDto.InstructorId, false).AnyAsync();

            if (!instructorExists)
                throw new NotFoundException($"instructor doesnt exist with id: {courseDto.InstructorId}");

            repository.Courses.Create(course);

            await repository.SaveAsync();

            return mapper.Map<CourseRDTO>(course);


        }

        public async Task<CourseRDTO> UpdateAsync(CourseUDTO courseDto)
        {
            var course = mapper.Map<Course>(courseDto);

            var courseWithSameTitle = await GetByTitleAsync(course.Title, false);

            //check if same new title exists BUT can rename same course with same title
            if (courseWithSameTitle is not null && course.Id != courseWithSameTitle.Id)
                throw new BadRequestException($"title: {course.Title} already exists");

            repository.Courses.Update(course);
            await repository.SaveAsync();

            return mapper.Map<CourseRDTO>(course);
        }

        public async Task<bool> ToggleApprovedAsync(int id)
        {
            await repository.Courses.ToggleApprovedAsync(id);

            return true;
        }

        public async Task DeleteAsync(int id)
        {
            await repository.Courses.DeleteAsync(id);

        }
        public async Task<IEnumerable<CourseRDTO>> GetAllBySubcategoryId(int subcategoryId)
        {
            var courses = await repository.Courses.FindByCondition(c => c.SubCategoryId == subcategoryId, false)
                                                  .ToListAsync();
            return mapper.Map<IEnumerable<CourseRDTO>>(courses);

        }
        public async Task<IEnumerable<CourseRDTO>> GetAllByCategoryId(int categoryId)
        {
            var courses = await repository.Courses.GetAllByCategoryId(categoryId);

            return mapper.Map<IEnumerable<CourseRDTO>>(courses);
        }



    }
}
