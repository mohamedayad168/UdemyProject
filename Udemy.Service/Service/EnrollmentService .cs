using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Service.Service
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public EnrollmentService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EnrollmentRDTO>> GetEnrollmentsByStudentIdAsync(int studentId)
        {
            var enrollments = await _repository.Enrollments.GetEnrollmentsByStudentIdAsync(studentId, trackChanges: false);
            return _mapper.Map<IEnumerable<EnrollmentRDTO>>(enrollments);
        }

        public async Task<IEnumerable<EnrollmentRDTO>> GetEnrollmentsByCourseIdAsync(int courseId)
        {
            var enrollments = await _repository.Enrollments.GetEnrollmentsByCourseIdAsync(courseId, trackChanges: false);
            return _mapper.Map<IEnumerable<EnrollmentRDTO>>(enrollments);
        }

        public async Task<EnrollmentRDTO?> GetEnrollmentAsync(int studentId, int courseId)
        {
            var enrollment = await _repository.Enrollments.GetEnrollmentAsync(studentId, courseId, trackChanges: false);
            return _mapper.Map<EnrollmentRDTO?>(enrollment);
        }

        public async Task<EnrollmentRDTO> CreateEnrollmentAsync(EnrollmentCDTO enrollmentDto)
        {
            var enrollment = _mapper.Map<Enrollment>(enrollmentDto);
            _repository.Enrollments.Create(enrollment);
            await _repository.SaveAsync();

            return _mapper.Map<EnrollmentRDTO>(enrollment);
        }

        public async Task UpdateEnrollmentAsync(int studentId, int courseId, EnrollmentUDTO enrollmentDto)
        {
            var enrollment = await _repository.Enrollments.GetEnrollmentAsync(studentId, courseId, trackChanges: true);
            if (enrollment == null)
                throw new KeyNotFoundException("Enrollment not found.");

            _mapper.Map(enrollmentDto, enrollment);
            await _repository.SaveAsync();
        }

        public async Task DeleteEnrollmentAsync(int studentId, int courseId)
        {
            var enrollment = await _repository.Enrollments.GetEnrollmentAsync(studentId, courseId, trackChanges: true);
            if (enrollment == null)
                throw new KeyNotFoundException("Enrollment not found.");

            enrollment.IsDeleted = true; 
            await _repository.SaveAsync();
        }
    }
}