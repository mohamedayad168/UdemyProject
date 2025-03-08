using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;

namespace Udemy.Infrastructure.Repository.EntityRepos
{
    public class CoursesRepo(ApplicationDbContext context) : RepositoryBase<Course>(context),ICoursesRepo
    {
        public async Task<IEnumerable<Course>> GetCoursesPageAsync(bool trackChanges, RequestParamter requestParamter)
        {
            return await FindAll(trackChanges)
                .Skip((requestParamter.PageNumber - 1) * requestParamter.PageSize)
                .Take(requestParamter.PageSize)
                .ToListAsync();
        }
    }
}
