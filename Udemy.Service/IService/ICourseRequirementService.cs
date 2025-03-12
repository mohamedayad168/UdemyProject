using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;

namespace Udemy.Service.IService
{
  
    public interface ICourseRequirementService
    {
        Task<IEnumerable<CourseRequirementRDTO>> GetAllRequirementsAsync(bool trackChanges);
        Task<CourseRequirementRDTO?> GetRequirementByIdAsync(string requirement, int courseId, bool trackChanges);
        Task<IEnumerable<CourseRequirementRDTO>> GetRequirementsByCourseIdAsync(int courseId, bool trackChanges);
        Task<CourseRequirementRDTO> CreateRequirementAsync(CourseRequirementCTO requirementDTO);
        Task<bool> SoftDeleteRequirementAsync(string requirement, int courseId);
    }
}
