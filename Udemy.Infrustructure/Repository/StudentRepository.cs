using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;

namespace Udemy.Infrastructure.Repository;
public class StudentRepository : RepositoryBase<Student>, IStudentRepository
{
    private readonly ApplicationDbContext dbContext;
    public StudentRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges, RequestParamter requestParamter)
    {
        return await FindAll(trackChanges)
            .Skip((requestParamter.PageNumber - 1) * requestParamter.PageSize)
            .Take(requestParamter.PageSize)
            .ToListAsync();
    }

    public async Task<Student> GetStudentAsync(int id, bool trackChanges)
    {
        return await FindByCondition(c => c.Id == id, trackChanges)
            .FirstOrDefaultAsync();
    }
    public async Task Create(Student student)
    {
        await dbContext.Set<Student>().AddAsync(student);
        await dbContext.SaveChangesAsync();
    }
    public void Update(Student student)
    {
        dbContext.Set<Student>().Update(student);
        dbContext.SaveChanges();
    }
    public void Delete(Student student)
    {
        dbContext.Set<Student>().Remove(student);
        dbContext.SaveChanges();
    }
}
