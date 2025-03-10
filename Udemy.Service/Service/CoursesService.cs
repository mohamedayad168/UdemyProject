using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var courses = await repository.Courses?.FindAll(trackChanges).ToListAsync();

            return courses is null ? [] : mapper.Map<IEnumerable<CourseRDTO>>(courses);
        }

        public async Task<IEnumerable<CourseRDTO>> GetPageAsync(RequestParamter requestParamter, bool trackChanges)
        {
            var courses = await repository.Courses.GetCoursesPageAsync(trackChanges, requestParamter);

            return mapper.Map<IEnumerable<CourseRDTO>>(courses);
        }

        public async Task<CourseRDTO?> GetByIdAsync(int id, bool trackChanges)
        {
            var course = await repository.Courses
                .FindByCondition(c => c.Id == id, trackChanges)
                .FirstOrDefaultAsync();

            return course is null ?
                throw new NotFoundException($"Course with id: {id} doesn't exist")
                : mapper.Map<CourseRDTO>(course);
        }

        public async Task<CourseRDTO?> GetByTitleAsync(string title, bool trackChanges)
        {
            var course = await repository.Courses.GetCourseByTitleAsync(title, trackChanges);

            return course is null ?
                throw new NotFoundException($"Course with title: {title} doesn't exist")
                : mapper.Map<CourseRDTO>(course);
        }

        public async Task<CourseRDTO> CreateAsync(CourseCDTO courseDto)
        {
            var courseWithSameTitle = await repository.Courses.GetCourseByTitleAsync(courseDto.Title, false);

            //check if same title exists
            if (courseWithSameTitle is not null)
                throw new BadRequestException($"title: {courseDto.Title} already exists");


            var course = mapper.Map<Course>(courseDto);

            //var testCourse = new Course
            //{
            //    Title = courseDto.Title,
            //    InstructorId = 22222,
            //    IsApproved = false,
            //    IsFree = true,
            //    CourseLevel = "string",
            //    Price = 121212,
            //    IsDeleted = false,
            //    SubCategoryId = 1,
            //    Description = "string",
            //    ImageUrl = "string",
            //    CreatedDate = DateTime.Now,
            //    Duration = 0,
            //    Discount = 0,
            //    VideoUrl = "string",
            //    Status = "string",
            //    Rating = 1,
            //    Language = "en",
            //    NoSubscribers = 0,
            //    BestSeller = "string",
            //    ModifiedDate = DateTime.Now,
            //};

            repository.Courses.Create(course);

            try
            {
                await repository.SaveAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at create course");
            }

            return mapper.Map<CourseRDTO>(course);

        }

        public async Task<CourseRDTO> UpdateAsync(CourseUDTO courseDto)
        {
            var courseWithSameTitle = await repository.Courses.GetCourseByTitleAsync(courseDto.Title, false);

            //check if same new title exists BUT can rename same course with same title
            if (courseWithSameTitle is not null && courseDto.Id != courseWithSameTitle.Id)
                throw new BadRequestException($"title: {courseDto.Title} already exists");


            var course = mapper.Map<Course>(courseDto);

            repository.Courses.Update(course);

            try
            {
                await repository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at create update");
            }

            return mapper.Map<CourseRDTO>(course);
        }

        public async Task DeleteAsync(int id)
        {
            var course = await repository.Courses.FindByCondition(e => e.Id == id, false).FirstOrDefaultAsync() ?? throw new NotFoundException($"course with id: {id} doesn't exist");

            repository.Courses.Delete(course);

            try
            {
                await repository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at course delete with id: " + id);
            }
        }

        public async Task<bool> ToggleApprovedAsync(int id)
        {
            var course = await GetByIdAsync(id, true) ?? throw new NotFoundException($"with id: {id} not found");

            try
            {
                course.IsApproved = !course.IsApproved;
                await repository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at course update with id: " + id);
            }

            return true;
        }
    }
}
