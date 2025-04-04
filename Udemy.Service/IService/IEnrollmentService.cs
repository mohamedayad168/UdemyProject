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

        Task<CourseRatingRDTO> GetCourseRatingsAsync(int courseId);
        Task<EnrollmentRDTO?> GetEnrollmentAsync(int studentId, int courseId);
        Task<EnrollmentRDTO> CreateEnrollmentAsync(EnrollmentCDTO enrollmentDto);
        Task UpdateEnrollmentAsync(int studentId, int courseId, EnrollmentUDTO enrollmentDto);
        Task DeleteEnrollmentAsync(int studentId, int courseId);
    }

    public class CourseRatingRDTO
    {
        public int CourseId { get; set; }
        public decimal Rating { get; set; }
        public int TotalReviews { get; set; }
        public int InstructorId { get; set; }
        public IEnumerable<RatingRDTO> Ratings { get; set; }
    }
    public class RatingRDTO
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public DateTime date { get; set; }

        public decimal Rating { get; set; }
        public string Comment { get; set; } = string.Empty;

    }
}