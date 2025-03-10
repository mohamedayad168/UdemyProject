﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.IService
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<EnrollmentRDTO>> GetEnrollmentsByStudentIdAsync(int studentId);
        Task<IEnumerable<EnrollmentRDTO>> GetEnrollmentsByCourseIdAsync(int courseId);
        Task<EnrollmentRDTO?> GetEnrollmentAsync(int studentId, int courseId);
        Task<EnrollmentRDTO> CreateEnrollmentAsync(EnrollmentCDTO enrollmentDto);
        Task UpdateEnrollmentAsync(int studentId, int courseId, EnrollmentUDTO enrollmentDto);
        Task DeleteEnrollmentAsync(int studentId, int courseId);
    }
}