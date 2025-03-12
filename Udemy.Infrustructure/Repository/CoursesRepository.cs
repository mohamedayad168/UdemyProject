using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.Exceptions;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Read;

namespace Udemy.Infrastructure.Repository
{
    public class CoursesRepository(ApplicationDbContext context) : RepositoryBase<Course>(context), ICoursesRepository
    {

        public async Task DeleteAsync(int id)
        {
            var course = await GetByIdAsync(id, false) ?? throw new NotFoundException($"course with id: {id} doesn't exist");

            Delete(course);

            try
            {
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at course delete with id: " + id);
            }
        }

        public async Task<IEnumerable<Course>> GetAllAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(c => c.Id == id, trackChanges)
                .FirstOrDefaultAsync() ?? throw new NotFoundException($"Course with id: {id} doesn't exist");
        }

        public async Task<Course?> GetByTitleAsync(string title, bool trackChanges)
        {
            return await FindByCondition(e => e.Title == title, trackChanges).FirstOrDefaultAsync(); 
        }

        public async Task<IEnumerable<Course>> GetPageAsync(RequestParamter requestParamter, bool trackChanges)
        {
            return await FindAll(trackChanges)
                .Skip((requestParamter.PageNumber - 1) * requestParamter.PageSize)
                .Take(requestParamter.PageSize)
                .ToListAsync();
        }

        public async Task ToggleApprovedAsync(int id)
        {
            var course = await GetByIdAsync(id, true) ?? throw new NotFoundException($"with id: {id} not found");

            course.IsApproved = !course.IsApproved;
            try
            {
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at course toggle status with id: " + id);
            }
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
