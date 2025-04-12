using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;

namespace Udemy.Core.IRepository
{
   public interface IlessonRepo:IRepositoryBase<Lesson>
    {
        public Task<IEnumerable<Lesson>> GetAllAsync(bool trackChanges);
        public Task<Lesson> GetByIdAsync(int lessonId,bool trackchange);

        public Task<IEnumerable<Lesson>> GetLessonsBySectionIdAsync(int sectionId, bool trackChanges);
      public  Task CreatelessonAsync(Lesson lesson);
     public   Task DeletelesssonAsync(Lesson lesson);
    }
}
