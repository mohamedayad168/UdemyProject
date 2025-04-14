using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;

namespace Udemy.Core.IRepository
{
    public interface ICoursesRepository : IRepositoryBase<Course>
    {
        //read
        public Task<IEnumerable<Course>> GetAllAsync(bool trackChanges);
        public Task<IEnumerable<Course>> GetAllByCategoryId(int categoryId);
        public Task<PaginatedRes<Course>> GetPageAsync(PaginatedSearchReq searchReq, bool isDeleted, bool trackChanges);
        public Task<Course?> GetByTitleAsync(string title, bool trackChanges);
        public Task<Course> GetByIdAsync(int id, bool trackChanges);

        //write
        //public Task<Course> CreateAsync(Course course);
        //public Task<Course> UpdateAsync(Course course);
        public Task ToggleApprovedAsync(int id);

        //
        public Task DeleteAsync(int id);
        Task<bool> CheckIfCourseExistsAsync(int id);
        Task<IEnumerable<Course>> GetAllWithSearchAsync(CourseRequestParameter requestParamter);
        Task<int> GetAllWithSearchCountAsync(CourseRequestParameter requestParamter);
    }
}
