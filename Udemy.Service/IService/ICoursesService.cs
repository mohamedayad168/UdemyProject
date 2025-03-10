using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.IService
{
    public interface ICoursesService
    {
        //read
        public Task<IEnumerable<CourseRDTO>> GetAllAsync(bool trackChanges);
        public Task<IEnumerable<CourseRDTO>> GetPageAsync(RequestParamter requestParamter, bool trackChanges);
        public Task<CourseRDTO?> GetByTitleAsync(string title, bool trackChanges);
        public Task<CourseRDTO?> GetByIdAsync(int id, bool trackChanges);

        //write
        public Task<int?> CreateAsync(CourseCDTO course);
        public Task UpdateAsync(CourseUDTO course);

        //
        public Task DeleteAsync(int id);

    }
}
