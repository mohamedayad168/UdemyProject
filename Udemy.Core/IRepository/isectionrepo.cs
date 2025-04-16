using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;

namespace Udemy.Core.IRepository
{
    public interface Isectionrepo:IRepositoryBase<Section>

    {
        public Task<IEnumerable<Section>> GetAllAsync(bool trackChanges);
        public Task<Section> GetByIdAsync(int lessonId, bool trackchange);

        Task<IEnumerable<Section>> GetSectionsByCourseIdAsync(int courseId, bool trackChanges);

        public Task CreatesectionAsync(Section section);
        public Task DeletesectionAsync(Section section);

    }
}
