using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Service.Service
{


    public class CourseRequirementService(ICourseRequirementRepo repository, IMapper mapper) : ICourseRequirementService
    {
        public async Task<IEnumerable<CourseRequirementRDTO>> GetAllRequirementsAsync(bool trackChanges)
        {
            var courseRequirements = await repository.GetAllRequirementsAsync(trackChanges);
            return mapper.Map<IEnumerable<CourseRequirementRDTO>>(courseRequirements);
        }

        public async Task<CourseRequirementRDTO?> GetRequirementByIdAsync(string requirement, int courseId, bool trackChanges)
        {
            var courseRequirement = await repository.GetRequirementByIdAsync(requirement, courseId, trackChanges);
            return mapper.Map<CourseRequirementRDTO?>(courseRequirement);
        }

        public async Task<IEnumerable<CourseRequirementRDTO>> GetRequirementsByCourseIdAsync(int courseId, bool trackChanges)
        {
            var courseRequirements = await repository.GetRequirementsByCourseIdAsync(courseId, trackChanges);
            return mapper.Map<IEnumerable<CourseRequirementRDTO>>(courseRequirements);
        }

        public async Task<CourseRequirementRDTO> CreateRequirementAsync(CourseRequirementCTO requirementDTO)
        {
            if (requirementDTO == null) throw new ArgumentNullException(nameof(requirementDTO));

            var requirementEntity = mapper.Map<CourseRequirement>(requirementDTO);
            await repository.CreateRequirementAsync(requirementEntity);

            return mapper.Map<CourseRequirementRDTO>(requirementEntity);
        }

        public async Task<bool> SoftDeleteRequirementAsync(string requirement, int courseId)
        {
            var existingRequirement = await repository.GetRequirementByIdAsync(requirement, courseId, true);
            if (existingRequirement == null) return false;

            await repository.SoftDeleteRequirementAsync(requirement, courseId);
            return true;
        }
    }
}