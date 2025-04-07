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
        Task<EnrollmentRDTO?> GetEnrollmentAsync(int studentId, int courseId);
        Task<EnrollmentRDTO> CreateEnrollmentAsync(EnrollmentCDTO enrollmentDto);
        Task UpdateEnrollmentAsync(int studentId, int courseId, EnrollmentUDTO enrollmentDto);
        Task DeleteEnrollmentAsync(int studentId, int courseId);
    }

    public class StudentCourseRDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string InstructorName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string CourseProgress { get; set; } = string.Empty;

        public decimal? ProgressPercentage { get; set; } = 0; //Added new property


    }


}