using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.IService
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<EnrollmentRDTO>> GetEnrollmentsByStudentIdAsync(int studentId);
        Task<IEnumerable<EnrollmentRDTO>> GetEnrollmentsByCourseIdAsync(int courseId);

        Task<IEnumerable<StudentCourseRDTO>> GetStudentCoursesAsync(int studentId);

        Task<CourseRatingRDTO> GetCourseRatingsAsync(int courseId);

        Task<CourseRatingCDTO> CreateCourseRatingsAsync(int studentId,CourseRatingCDTO courseRatingDto);
        Task<EnrollmentRDTO?> GetEnrollmentAsync(int studentId, int courseId);
        Task<EnrollmentRDTO> CreateEnrollmentAsync(EnrollmentCDTO enrollmentDto);
        Task UpdateEnrollmentAsync(int studentId, int courseId, EnrollmentUDTO enrollmentDto);
        Task DeleteEnrollmentAsync(int studentId, int courseId);
        Task EnrollCoursesToStudentAsync(int studentId , IEnumerable<int> coursesId);
    }


}