using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;

namespace Udemy.Core.IRepository
{
    public interface IInstructorRepo : IRepositoryBase<Instructor>
    {
        Task<IEnumerable<Instructor>> GetAllInstructorsAsync(bool trackChanges);
        Task<Instructor?> GetInstructorByIdAsync(int id, bool trackChanges);
        Task<Instructor?> GetInstructorByTitleAsync(string title, bool trackChanges);
        Task CreateInstructorAsync(Instructor instructor);
        Task DeleteInstructorAsync(Instructor instructor);
        Task<IEnumerable<Course>> GetCoursesByInstructorIdAsync(int instructorId);
    }
}
