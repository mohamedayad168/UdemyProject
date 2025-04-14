﻿using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.IService
{
    public interface IInstructorService
    {
        Task<IEnumerable<InstructorRDTO>> GetAllAsync(bool trackChanges);
        Task<InstructorRDTO> GetByIdAsync(int id, bool trackChanges);
        Task<InstructorRDTO> GetByTitleAsync(string title, bool trackChanges);
        Task<Instructor> CreateAsync(InstructorCDTO dto);
        Task<bool> UpdateAsync(int id, InstructorUTO dto);
        Task<bool> DeleteAsync(int id);
        Task<InstructorRDTO> GetInstructorDetails(int instructorId);
        Task<IEnumerable<CourseRDTO>> GetCoursesByInstructor(int instructorId);
    }
}
