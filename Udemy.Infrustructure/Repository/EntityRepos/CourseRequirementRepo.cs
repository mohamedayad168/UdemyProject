using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;

namespace Udemy.Infrastructure.Repository.EntityRepos
{
    public class CourseRequirementRepo : RepositoryBase<CourseRequirement>, ICourseRequirementRepo
    {
        private readonly ApplicationDbContext dbContext;

        public CourseRequirementRepo(ApplicationDbContext context) : base(context)
        {
            dbContext = context;
        }

        public async Task<IEnumerable<CourseRequirement>> GetAllRequirementsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .Where(r => r.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<CourseRequirement?> GetRequirementByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(r => r.CourseId == id && r.IsDeleted == false, trackChanges)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CourseRequirement>> GetRequirementsByCourseIdAsync(int courseId, bool trackChanges)
        {
            return await FindByCondition(r => r.CourseId == courseId && r.IsDeleted == false, trackChanges)
                .ToListAsync();
        }

        public async Task CreateRequirementAsync(CourseRequirement requirement)
        {
            await dbContext.Set<CourseRequirement>().AddAsync(requirement);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteRequirementAsync(CourseRequirement requirement)
        {
            requirement.IsDeleted = true;
            dbContext.Set<CourseRequirement>().Update(requirement);
            await dbContext.SaveChangesAsync();
        }

        void ICourseRequirementRepo.CreateRequirement(CourseRequirement requirement)
        {
            Create(requirement);
        }

        void ICourseRequirementRepo.DeleteRequirement(CourseRequirement requirement)
        {
            requirement.IsDeleted = true;
            Update(requirement);
        }

        
    }
}