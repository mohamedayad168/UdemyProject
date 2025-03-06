using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;

namespace Udemy.Infrastructure.Repository;
public class StudentRepository : RepositoryBase<Student>, IStudentRepository
{
    public StudentRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges , RequestParamter requestParamter)
    {
        return await FindAll(trackChanges)
            .Skip((requestParamter.PageNumber - 1) * requestParamter.PageSize)
            .Take(requestParamter.PageSize)
            .ToListAsync();
    }

    public async Task<Student> GetStudentAsync(int id , bool trackChanges)
    {
        return await FindByCondition(c => c.Id == id , trackChanges)
            .FirstOrDefaultAsync();
    }
}
