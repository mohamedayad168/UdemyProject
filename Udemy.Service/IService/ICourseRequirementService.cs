using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Service.DataTransferObjects.Read;

namespace Udemy.Service.IService
{
    public interface ICourseRequirementService
    {
        Task<IEnumerable<CourseRequirementRDTO>> GetAllAsync(bool trackChanges);
        Task<CourseRequirementRDTO?> GetByIdAsync(int id, bool trackChanges);
    }
}
