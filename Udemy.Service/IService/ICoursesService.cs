using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Read;

namespace Udemy.Service.IService
{
    public interface ICoursesService
    {
        public Task<IEnumerable<CourseRDTO>> GetAllAsync(bool trackChanges);
        public Task<IEnumerable<CourseRDTO>> GetPageAsync(bool trackChanges, RequestParamter requestParamter);
        public Task<CourseRDTO?> GetByTitleAsync(string title, bool trackChanges);


    }
}
