using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.IService
{

    public interface ICourseRequirementService
    {
        Task<IEnumerable<CourseRequirementRDTO>> GetAllRequirementsAsync(bool trackChanges);
        Task<CourseRequirementRDTO?> GetRequirementAsync(string requirement, int courseId, bool trackChanges);
        Task<IEnumerable<CourseRequirementRDTO>> GetRequirementsByCourseIdAsync(int courseId, bool trackChanges);
        Task<CourseRequirementRDTO> CreateRequirementAsync(CourseRequirementCTO requirementDTO);
        Task<CourseRequirementRDTO> UpdateRequirementAsync(CourseRequirementUTO requirementDTO);
        Task DeleteRequirementAsync(string requirement, int courseId);
    }
}