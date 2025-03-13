using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.Exceptions;
using Udemy.Core.IRepository;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Service.Service
{
    public class CourseRequirementService(IRepositoryManager repository, IMapper mapper) : ICourseRequirementService
    {
        public async Task<IEnumerable<CourseRequirementRDTO>> GetAllRequirementsAsync(bool trackChanges)
        {
            var requirements = await repository.CourseRequirement.FindAll(trackChanges).ToListAsync();
            return requirements is null ? [] : mapper.Map<IEnumerable<CourseRequirementRDTO>>(requirements);
        }

        public async Task<IEnumerable<CourseRequirementRDTO>> GetRequirementsByCourseIdAsync(int courseId, bool trackChanges)
        {
            var requirements = await repository.CourseRequirement
                .FindByCondition(r => r.CourseId == courseId, trackChanges)
                .ToListAsync();

            return requirements is null ? [] : mapper.Map<IEnumerable<CourseRequirementRDTO>>(requirements);
        }

        public async Task<CourseRequirementRDTO?> GetRequirementAsync(string requirement, int courseId, bool trackChanges)
        {
            var req = await repository.CourseRequirement
                .FindByCondition(r => r.Requirement == requirement && r.CourseId == courseId, trackChanges)
                .FirstOrDefaultAsync();

            return req is null ? throw new NotFoundException($"Requirement '{requirement}' for Course ID {courseId} doesn't exist")
                               : mapper.Map<CourseRequirementRDTO>(req);
        }

        public async Task<CourseRequirementRDTO> CreateRequirementAsync(CourseRequirementCTO requirementDTO)
        {
            // تحقق مما إذا كان المتطلب موجودًا بالفعل
            var existingRequirement = await repository.CourseRequirement
                .FindByCondition(r => r.Requirement == requirementDTO.Requirement && r.CourseId == requirementDTO.CourseId, false)
                .FirstOrDefaultAsync();

            if (existingRequirement is not null)
                throw new BadRequestException($"Requirement '{requirementDTO.Requirement}' already exists for Course ID {requirementDTO.CourseId}");

            var requirementEntity = mapper.Map<CourseRequirement>(requirementDTO);
            repository.CourseRequirement.Create(requirementEntity);

            try
            {
                await repository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at creating course requirement");
            }

            return mapper.Map<CourseRequirementRDTO>(requirementEntity);
        }

        public async Task<CourseRequirementRDTO> UpdateRequirementAsync(CourseRequirementUTO requirementDTO)
        {
            var requirement = await repository.CourseRequirement
                .FindByCondition(r => r.Requirement == requirementDTO.Requirement && r.CourseId == requirementDTO.CourseId, false)
                .FirstOrDefaultAsync();

            if (requirement is null)
                throw new NotFoundException($"Requirement '{requirementDTO.Requirement}' for Course ID {requirementDTO.CourseId} doesn't exist");

            mapper.Map(requirementDTO, requirement);
            repository.CourseRequirement.Update(requirement);

            try
            {
                await repository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at updating course requirement");
            }

            return mapper.Map<CourseRequirementRDTO>(requirement);
        }

        public async Task DeleteRequirementAsync(string requirement, int courseId)
        {
            var existingRequirement = await repository.CourseRequirement
                .FindByCondition(r => r.Requirement == requirement && r.CourseId == courseId, false)
                .FirstOrDefaultAsync();

            if (existingRequirement is null)
                throw new NotFoundException($"Requirement '{requirement}' for Course ID {courseId} doesn't exist");

            repository.CourseRequirement.Delete(existingRequirement);

            try
            {
                await repository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at deleting course requirement");
            }
        }
    }
}
