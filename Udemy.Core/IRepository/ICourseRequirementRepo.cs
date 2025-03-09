using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;

namespace Udemy.Core.IRepository
{
    public interface ICourseRequirementRepo : IRepositoryBase<CourseRequirement>
    {
        Task<IEnumerable<CourseRequirement>> GetAllRequirementsAsync(bool trackChanges);
        Task<CourseRequirement?> GetRequirementByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<CourseRequirement>> GetRequirementsByCourseIdAsync(int courseId, bool trackChanges);
        void CreateRequirement(CourseRequirement requirement);
       void  DeleteRequirement(CourseRequirement requirement);
      

    }
}
