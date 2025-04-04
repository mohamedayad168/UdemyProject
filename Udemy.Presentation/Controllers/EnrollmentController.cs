using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Presentation.Controllers
{

    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EnrollmentController(IServiceManager service)
        {
            _service = service;
        }

       
        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetEnrollmentsByStudent(int studentId)
        {
            var enrollments = await _service.EnrollmentService.GetEnrollmentsByStudentIdAsync(studentId);
            return Ok(enrollments);
        }

        
        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetEnrollmentsByCourse(int courseId)
        {
            var enrollments = await _service.EnrollmentService.GetEnrollmentsByCourseIdAsync(courseId);
            return Ok(enrollments);
        }

        [HttpGet("ratings/{courseId}")]
        public async Task<IActionResult> GetRatingsByCourse(int courseId)
        {
            var ratings= await _service.EnrollmentService.GetCourseRatingsAsync(courseId);
            return Ok(ratings);
        }


     
        [HttpGet("{studentId}/{courseId}")]
        public async Task<IActionResult> GetEnrollment(int studentId, int courseId)
        {
            var enrollment = await _service.EnrollmentService.GetEnrollmentAsync(studentId, courseId);
            if (enrollment == null) return NotFound();
            return Ok(enrollment);
        }

       
        [HttpPost]
        public async Task<IActionResult> CreateEnrollment([FromBody] EnrollmentCDTO enrollmentDto)
        {
            if (enrollmentDto == null) return BadRequest("Invalid data.");

            var enrollment = await _service.EnrollmentService.CreateEnrollmentAsync(enrollmentDto);
            return CreatedAtAction(nameof(GetEnrollment), new { studentId = enrollment.StudentId, courseId = enrollment.CourseId }, enrollment);
        }

        
        [HttpPut("{studentId}/{courseId}")]
        public async Task<IActionResult> UpdateEnrollment(int studentId, int courseId, [FromBody] EnrollmentUDTO updateDto)
        {
            if (updateDto == null) return BadRequest("Invalid data.");

            await _service.EnrollmentService.UpdateEnrollmentAsync(studentId, courseId, updateDto);
            return NoContent();
        }

        
        [HttpDelete("{studentId}/{courseId}")]
        public async Task<IActionResult> DeleteEnrollment(int studentId, int courseId)
        {
            await _service.EnrollmentService.DeleteEnrollmentAsync(studentId, courseId);
            return NoContent();
        }
    }
}