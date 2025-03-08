using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Read;

namespace Udemy.Service.IService
{
    public interface ICoursesService
    {
        public Task<IEnumerable<CourseRDTO>> GetCoursesPageAsync(bool trackChanges, RequestParamter requestParamter);
    }
}
