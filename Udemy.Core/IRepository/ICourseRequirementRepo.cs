using Udemy.Core.Entities;

namespace Udemy.Core.IRepository
{
    public interface ICourseRequirementRepo : IRepositoryBase<CourseRequirement>
    {
        Task<IEnumerable<CourseRequirement>> GetAllRequirementsAsync(bool trackChanges);
        Task<CourseRequirement?> GetRequirementByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<CourseRequirement>> GetRequirementsByCourseIdAsync(int courseId, bool trackChanges);
        Task CreateRequirementAsync(CourseRequirement requirement);
        Task DeleteRequirementAsync(CourseRequirement requirement);
        void CreateRequirement(CourseRequirement requirement);
        void DeleteRequirement(CourseRequirement requirement);


    }
}
