﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.Enums;
using Udemy.Core.Exceptions;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Service.Service
{
    public class CoursesService(IRepositoryManager repository, IMapper mapper, ICloudService cloudService) : ICoursesService
    {
        public async Task<IEnumerable<CourseRDTO>> GetAllAsync(bool trackChanges)
        {
            var courses = await repository.Courses.GetAllAsync(false);

            return mapper.Map<IEnumerable<CourseRDTO>>(courses);
        }


        public async Task<PaginatedRes<CourseRDTO>> GetPageAsync(PaginatedSearchReq searchReq, DeletionType deletionType, bool trackChanges)

        {
            var paginatedCourseRes = await repository.Courses.GetPageAsync(searchReq, deletionType, trackChanges);

            var paginatedDtoRes = new PaginatedRes<CourseRDTO>
            {
                Data = mapper.Map<IEnumerable<CourseRDTO>>(paginatedCourseRes.Data),
                PageSize = searchReq.PageSize,
                CurrentPage = searchReq.PageNumber,
                TotalItems = paginatedCourseRes.TotalItems
            };

            return paginatedDtoRes;
        }



        public async Task<CourseDetailsRDto> GetCourseDetailsAsync(int id, bool trackChanges)
        {
            //var course = await repository.Courses.FindByCondition(c => c.Id == id, trackChanges)
            //            .Include(c => c.Instructor)
            //            .Include(c => c.SubCategory)
            //            .ThenInclude(sc => sc.Category)
            //            .Include(c => c.CourseGoals)
            //            .Include(c => c.Instructor)
            //            .Include(c => c.CourseRequirements)
            //            .Include(c => c.Sections.Where(s => s.IsDeleted == false))
            //            .ThenInclude(s => s.Lessons.Where(l => l.IsDeleted == false))
            //            .FirstOrDefaultAsync();

            var course = await repository.Courses.GetCourseDetailsAsync(id, trackChanges);

            var courseRating = await repository.Enrollments.FindByCondition(e => e.CourseId == id, trackChanges).AverageAsync(e => e.Rating);

            if (course is not null)
                course.Rating = courseRating;

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
        public async Task<bool> GetByTitleForValidation(string title, bool trackChanges)
        {
            var course = await repository.Courses.GetByTitleAsync(title, true);
            if (course?.Title == title)
            {
                return true;
            }

            return false;
        }

        public async Task<CourseRDTO> CreateAsync(CourseCDTO courseDto)
        {
            string? imageUrl = null;
            string? videoUrl = null;

            if (courseDto.ImageUrl != null)
                imageUrl = await cloudService.UploadImageAsync(courseDto.ImageUrl);

            if (courseDto.VideoUrl != null)
                videoUrl = await cloudService.UploadVideoAsync(courseDto.VideoUrl);

            var course = mapper.Map<Course>(courseDto);
            course.ImageUrl = imageUrl;
            course.VideoUrl = videoUrl;



            var instructorExists = await repository.Instructors
                .FindByCondition(i => i.Id == courseDto.InstructorId, false).AnyAsync();

            if (!instructorExists)
                throw new NotFoundException($"instructor doesnt exist with id: {courseDto.InstructorId}");

            repository.Courses.Create(course);

            await repository.SaveAsync();

            var courseRDTO = mapper.Map<CourseRDTO>(course);
            var instructor = await repository.Instructors.GetInstructorByIdAsync(courseRDTO.InstructorId, false);
            courseRDTO.InstructorName = instructor.UserName;
            return courseRDTO;


        }

        public async Task<CourseRDTO> UpdateAsync(CourseUDTO courseDto)
        {

            var course = await repository.Courses.GetByIdAsync(courseDto.Id, true);
            if (course == null)
            {
                throw new NotFoundException($"Course with ID {courseDto.Id} not found");
            }

            mapper.Map(courseDto, course);

            string? imageUrl = null;
            string? videoUrl = null;

            if (courseDto.ImageUrl != null)
                imageUrl = await cloudService.UploadImageAsync(courseDto.ImageUrl);

            if (courseDto.VideoUrl != null)
                videoUrl = await cloudService.UploadVideoAsync(courseDto.VideoUrl);

            course.ImageUrl = imageUrl;
            course.VideoUrl = videoUrl;



            await repository.Courses.UpdateAsync(course);
            await repository.Courses.SaveChangesAsync();


            return mapper.Map<CourseRDTO>(course);
        }


        public async Task<bool> ToggleApprovedAsync(int id)
        {
            await repository.Courses.ToggleApprovedAsync(id);

            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var course = await repository.Courses.FindAll(true, DeletionType.All).Where(c => c.Id == id).FirstAsync();
            if (course == null)
                throw new Exception("Course not found");

            await repository.Courses.DeleteCourseAsync(course);
        }

        public async Task<Course> GetByIdAsync2(int id)
        {
            var course = await repository.Courses.FindAll(true, DeletionType.All).Where(c => c.Id == id).FirstAsync();
            if (course == null)
                throw new Exception("Course not found");
            return course;
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

        public async Task<PaginatedRes<CourseSearchDto>> GetAllWithSearchAsync(CourseRequestParameter requestParamter)
        {
            var courses = await repository.Courses.GetAllWithSearchAsync(requestParamter);

            var coursesCount = await repository.Courses.GetAllWithSearchCountAsync(requestParamter);

            var coursesDto = mapper.Map<IEnumerable<CourseSearchDto>>(courses);

            var paginResult = new PaginatedRes<CourseSearchDto>()
            {
                Data = coursesDto,
                CurrentPage = requestParamter.PageNumber,
                PageSize = requestParamter.PageSize,
                TotalItems = coursesCount
            };

            return paginResult;
        }

    }
}
