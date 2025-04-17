using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;

namespace Udemy.Infrastructure.Repository;
public class AskRepository(ApplicationDbContext dbContext)
    : RepositoryBase<Ask>(dbContext), IAskRepository
{
    private readonly ApplicationDbContext dbContext = dbContext;

    public async Task<IEnumerable<Ask>> GetAllUserCourseAsksAsync(
        int userId ,int courseId ,bool trackChanges ,RequestParamter requestParamter
    )
    {
        return await FindByCondition(x =>
                x.UserId == userId &&
                x.CourseId == courseId &&
                x.IsDeleted != true ,
                trackChanges)
            .Include(c => c.User)
            .Skip((requestParamter.PageNumber - 1) * requestParamter.PageSize)
            .Take(requestParamter.PageSize)
            .ToListAsync();
    }

    public async Task<Ask?> GetUserCourseAskByIdAsync(
        int userId ,int courseId ,int id ,bool trackChanges
    )
    {
        return await FindByCondition(c => 
                c.Id == id && 
                c.CourseId == courseId &&
                c.UserId == userId &&
                c.IsDeleted != true ,
                trackChanges)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> CheckIfAskExistsAsync(int id) => await dbContext.Asks.AnyAsync(c => c.Id == id&& c.IsDeleted != true);


    public async Task<Ask?> GetAskByIdAsync(int id, bool trackChanges)
    {
        return await FindByCondition(x => x.Id == id && x.IsDeleted != trackChanges , trackChanges)
            .FirstOrDefaultAsync();
    } 

    public void CreateAsk(Ask ask)
    {
        Create(ask);
    }

    public void DeleteAsk(Ask ask)
    {
        ask.IsDeleted = true;
    }
}
