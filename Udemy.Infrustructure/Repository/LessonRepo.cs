using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;

namespace Udemy.Infrastructure.Repository
{
   public class LessonRepo : RepositoryBase<Lesson>, IlessonRepo
    {
        private readonly ApplicationDbContext dbContext;
        public LessonRepo(ApplicationDbContext Context) : base(Context)
        {
            dbContext = Context;
        }

        public async Task<IEnumerable<Lesson>> GetAllAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).Where(i => i.IsDeleted == false || i.IsDeleted == null).ToListAsync();
        }
                

        public async Task<Lesson> GetByIdAsync(int lessonId,bool trackchange)
        {
            return await FindByCondition(l => l.Id == lessonId && (l.IsDeleted == false || l.IsDeleted == null), trackchange).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Lesson>> GetLessonsBySectionIdAsync(int sectionId, bool trackChanges)
        {
         return await FindByCondition(l=>l.SectionId==sectionId && (l.IsDeleted == false || l.IsDeleted == null), trackChanges)
                .ToListAsync();
        }

     async Task IlessonRepo.CreatelessonAsync(Lesson lesson)
        {

            await dbContext.Set<Lesson>().AddAsync(lesson);
            await dbContext.SaveChangesAsync();


        } 

    async Task IlessonRepo.DeletelesssonAsync(Lesson lesson)
        {
            lesson.IsDeleted = true;
            dbContext.Set<Lesson>().Update(lesson);
            await dbContext.SaveChangesAsync();
        }
    }
}