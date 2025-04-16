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
    public class SectionRepo : RepositoryBase<Section>, Isectionrepo
    {
        private readonly ApplicationDbContext dbContext;
        public SectionRepo(ApplicationDbContext context) : base(context)
        {
            dbContext = context;
        }
        public async Task CreatesectionAsync(Section section)
        {

            await dbContext.Set<Section>().AddAsync(section);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeletesectionAsync(Section section)
        {
               section.IsDeleted = true;
             dbContext.Set<Section>().Update(section);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Section>> GetAllAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).Where(i => i.IsDeleted == false || i.IsDeleted == null).ToListAsync();
        }

        public async Task<Section> GetByIdAsync(int sectionId, bool trackChanges)
        {
            return await FindByCondition(s => s.Id == sectionId && !s.IsDeleted, trackChanges)
                         .FirstOrDefaultAsync();
        }
    }
}