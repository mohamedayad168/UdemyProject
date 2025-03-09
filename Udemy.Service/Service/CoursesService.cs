using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class CoursesService(IRepositoryManager repository, IMapper mapper) : ICoursesService
    {

        public async Task<IEnumerable<CourseRDTO>> GetPageAsync(bool trackChanges, RequestParamter requestParamter)
        {
            var courses = await repository.Courses.GetCoursesPageAsync(trackChanges, requestParamter);

            return mapper.Map<IEnumerable<CourseRDTO>>(courses);
        }

        public async Task<CourseRDTO?> GetByTitleAsync(string title, bool trackChanges)
        {
            var course = await repository.Courses.GetCourseByTitleAsync(title, trackChanges);
            return mapper.Map<CourseRDTO?>(course);
        }

        public async Task<IEnumerable<CourseRDTO>> GetAllAsync(bool trackChanges)
        {
            var courses = await repository.Courses.FindAll(trackChanges).ToArrayAsync();


            if (courses is null) return [];


            return mapper.Map<IEnumerable<CourseRDTO>>(courses);
        }


    }
}
