using Udemy.Core.Entities;
using Udemy.Core.Enums;
using Udemy.Core.ReadOptions;

namespace Udemy.Core.IRepository
{
    public interface IInstructorRepo : IRepositoryBase<Instructor>
    {
        Task<IEnumerable<Instructor>> GetAllInstructorsAsync(bool trackChanges);

        public Task<PaginatedRes<Instructor>> GetPageAsync(PaginatedSearchReq searchReq, DeletionType isDeleted, bool trackChanges);


        Task<Instructor?> GetInstructorByIdAsync(int id, bool trackChanges);
        Task<Instructor?> GetInstructorByTitleAsync(string title, bool trackChanges);
        Task CreateInstructorAsync(Instructor instructor);
        Task DeleteInstructorAsync(Instructor instructor);
        Task<IEnumerable<Course>> GetCoursesByInstructorIdAsync(int instructorId);
    }
}
