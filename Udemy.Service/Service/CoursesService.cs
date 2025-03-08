using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.IService;

namespace Udemy.Service.Service
{
    public class CoursesService : ICoursesService
    {
        private readonly IRepositoryManager repository;
        public CoursesService(IRepositoryManager repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<CourseRDTO>> GetCoursesPageAsync(bool trackChanges,RequestParamter requestParamter)
        {
            var courses = await repository.Courses.GetCoursesPageAsync(trackChanges, requestParamter);
            return await 
        }
    }
}
