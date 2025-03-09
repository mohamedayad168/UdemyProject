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
  
    
        public class CourseRequirementService(IRepositoryManager repository, IMapper mapper) : ICourseRequirementService
        {
            public async Task<IEnumerable<CourseRequirementRDTO>> GetAllAsync(bool trackChanges)
            {
            var courseRequirements = await repository.CourseRequirements.FindAll(trackChanges).ToListAsync();
                return mapper.Map<IEnumerable<CourseRequirementRDTO>>(courseRequirements);
            }

            public async Task<CourseRequirementRDTO?> GetByIdAsync(int id, bool trackChanges)
            {
            var courseRequirement = await repository.CourseRequirements.FindByCondition(cr => cr.Id == id, trackChanges).FirstOrDefaultAsync();
                return mapper.Map<CourseRequirementRDTO?>(courseRequirement);
            }

            public async Task<CourseRequirementRDTO> CreateAsync(CourseRequirementCTO courseRequirementCTO)
            {
                var courseRequirement = mapper.Map<CourseRequirement>(courseRequirementCTO);
                repository.CourseRequirements.Create(courseRequirement);
                await repository.SaveAsync();
                return mapper.Map<CourseRequirementRDTO>(courseRequirement);
            }

            public async Task UpdateAsync(int id, CourseRequirementUTO courseRequirementUTO)
            {
            var existingRequirement = await repository.CourseRequirements.FindByCondition(cr => cr.Id == id, true).FirstOrDefaultAsync();
                if (existingRequirement == null) throw new Exception("Course requirement not found!");

                mapper.Map(courseRequirementUTO, existingRequirement);
                await repository.SaveAsync();
            }

            public async Task DeleteAsync(int id)
            {
                var courseRequirement = await repository.CourseRequirements.FindByCondition(cr => cr.Id == id, true).FirstOrDefaultAsync();
                if (courseRequirement == null) throw new Exception("Course requirement not found!");

                repository.CourseRequirements.Delete(courseRequirement);
                await repository.SaveAsync();
            }
        }
    }