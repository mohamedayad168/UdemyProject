using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Udemy.Core.Exceptions;
using Udemy.Core.IRepository;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Service.Service
{
    public class InstructorService(IRepositoryManager repository, IMapper mapper) : IInstructorService
    {
        public async Task<IEnumerable<InstructorRDTO>> GetAllAsync(bool trackChanges)
        {
            var instructors = await repository.Instructors.FindAll(trackChanges).ToArrayAsync();
            return mapper.Map<IEnumerable<InstructorRDTO>>(instructors);
        }

        public async Task<InstructorRDTO> GetByIdAsync(int id, bool trackChanges)
        {
            var instructor = await repository.Instructors.GetInstructorByIdAsync(id, trackChanges);
            return mapper.Map<InstructorRDTO>(instructor);
        }

        public async Task<DataTransferObjects.Read.InstructorRDTO> GetByTitleAsync(string title, bool trackChanges)
        {
            var instructor = await repository.Instructors.GetInstructorByTitleAsync(title, trackChanges);
            return mapper.Map<InstructorRDTO>(instructor);
        }


        public async Task<Core.Entities.Instructor> CreateAsync(InstructorCDTO dto)
        {
            var instructorEntity = mapper.Map<Core.Entities.Instructor>(dto);

            await repository.Instructors.CreateInstructorAsync(instructorEntity);
            return instructorEntity;

        }

        public async Task<bool> UpdateAsync(int id, InstructorUTO dto)
        {
            var instructor = await repository.Instructors.GetInstructorByIdAsync(id, true);
            if (instructor == null)
                return false;

            mapper.Map(dto, instructor);
            await repository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var instructor = await repository.Instructors.GetInstructorByIdAsync(id, true);
            if (instructor == null)
                return false;

            instructor.IsDeleted = true;
            await repository.SaveAsync();
            return true;
        }




        public async Task<IEnumerable<CourseRDTO>> GetCoursesByInstructor(int instructorId)
        {
            // Fetch the courses associated with the given instructorId
            var courses = await repository.Instructors.GetCoursesByInstructorIdAsync(instructorId);

            if (courses == null || !courses.Any())
            {
                throw new NotFoundException("No courses found for this instructor.");
            }

            // Map courses to CourseRDTO (you can use AutoMapper or manually map them)
            var courseRDTOs = courses.Select(course => new CourseRDTO
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                InstructorName = $"{course.Instructor.FirstName} {course.Instructor.LastName}",
                Price = course.Price,


            }).ToList();

            return courseRDTOs;
        }

        public async Task<InstructorRDTO> GetInstructorDetails(int instructorId)
        {
            // Fetch the instructor details based on instructorId
            var instructor = await repository.Instructors.GetInstructorByIdAsync(instructorId, true);

            if (instructor == null)
            {
                throw new NotFoundException("Instructor not found.");
            }

            // Map the instructor entity to InstructorRDTO
            var instructorRDTO = new InstructorRDTO
            {
                Id = instructor.Id,
                Name = instructor.FirstName + "" + instructor.LastName,
                Title = instructor.Title,
                Bio = instructor.Bio,
                UserName = instructor.UserName,
                Email = instructor.Email,

                TotalCourses = instructor.TotalCourses,
                TotalReviews = instructor.TotalReviews,
                TotalStudents = instructor.TotalStudents
            };

            return instructorRDTO;
        }


    }
}
