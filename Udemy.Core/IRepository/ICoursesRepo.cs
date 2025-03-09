using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;

namespace Udemy.Core.IRepository
{
    public interface ICoursesRepo : IRepositoryBase<Course>
    {
        public Task<IEnumerable<Course>> GetCoursesPageAsync(bool trackChanges, RequestParamter requestParamter);
        public Task<Course?> GetCourseByTitleAsync(string title,bool trackChanges);

    }
}
