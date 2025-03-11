using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;

namespace Udemy.Infrastructure.Repository;
public class AskRepository(ApplicationDbContext dbContext)
    : RepositoryBase<Ask>(dbContext), IAskRepository
{
    private readonly ApplicationDbContext dbContext = dbContext;

    public async Task<IEnumerable<Ask>> GetAllAsksAsync(bool trackChanges , RequestParamter requestParamter)
    {
        return await FindAll(trackChanges)
            .Where(x => x.IsDeleted != true)
            .Skip((requestParamter.PageNumber - 1) * requestParamter.PageSize)
            .Take(requestParamter.PageSize)
            .ToListAsync();
    }

    public async Task<Ask?> GetAskByIdAsync(int id , bool trackChanges)
    {
        return await FindByCondition(c => c.Id == id && c.IsDeleted != true , trackChanges)
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
