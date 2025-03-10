using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;

namespace Udemy.Core.IRepository
{
    public interface IEnrollmentRepository : IRepositoryBase<Enrollment>
    {
        
        Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId, bool trackChanges);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseIdAsync(int courseId, bool trackChanges);
        Task<Enrollment?> GetEnrollmentAsync(int studentId, int courseId, bool trackChanges);
    }
}
