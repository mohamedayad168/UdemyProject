using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;

namespace Udemy.Infrastructure.Repository
{
    public class CoursesRepository(ApplicationDbContext context) : RepositoryBase<Course>(context), ICoursesRepository
    {
        public async Task<Course?> GetCourseByTitleAsync(string title, bool trackChanges)
        {
            return await FindByCondition(e => e.Title == title, trackChanges).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesPageAsync(bool trackChanges, RequestParamter requestParamter)
        {
            return await FindAll(trackChanges)
                .Skip((requestParamter.PageNumber - 1) * requestParamter.PageSize)
                .Take(requestParamter.PageSize)
                .ToListAsync();
        }
    }
}
