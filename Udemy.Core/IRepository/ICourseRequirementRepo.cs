using Udemy.Core.Entities;

namespace Udemy.Core.IRepository
{
    public interface ICourseRequirementRepo : IRepositoryBase<CourseRequirement>
    {
        Task<IEnumerable<CourseRequirement>> GetAllRequirementsAsync(bool trackChanges);
        Task<CourseRequirement?> GetRequirementByIdAsync(string requirement, int courseId, bool trackChanges);
        Task<IEnumerable<CourseRequirement>> GetRequirementsByCourseIdAsync(int courseId, bool trackChanges);
        Task CreateRequirementAsync(CourseRequirement requirement);
        Task SoftDeleteRequirementAsync(string requirement, int courseId); 
    }
}
