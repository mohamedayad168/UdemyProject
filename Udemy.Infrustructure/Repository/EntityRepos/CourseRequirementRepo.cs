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
                .Where(r => !r.IsDeleted)
                .ToListAsync();
        }

        public async Task<CourseRequirement?> GetRequirementByIdAsync(string requirement, int courseId, bool trackChanges)
        {
            return await FindByCondition(r => r.Requirement == requirement && r.CourseId == courseId && !r.IsDeleted, trackChanges)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CourseRequirement>> GetRequirementsByCourseIdAsync(int courseId, bool trackChanges)
        {
            return await FindByCondition(r => r.CourseId == courseId && !r.IsDeleted, trackChanges)
                .ToListAsync();
        }

        public async Task CreateRequirementAsync(CourseRequirement requirement)
        {
            await dbContext.Set<CourseRequirement>().AddAsync(requirement);
        }

        public async Task SoftDeleteRequirementAsync(string requirement, int courseId)
        {
            var req = await GetRequirementByIdAsync(requirement, courseId, true);
            if (req != null)
            {
                req.IsDeleted = true;
                dbContext.Set<CourseRequirement>().Update(req);
            }
        }
    }
