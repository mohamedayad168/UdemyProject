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
            .Skip((requestParamter.PageNumber - 1) * requestParamter.PageSize)
            .Take(requestParamter.PageSize)
            .ToListAsync();
    }

    public async Task<Ask?> GetAskByIdAsync(int id , bool trackChanges)
    {
        return await FindByCondition(c => c.Id == id , trackChanges)
            .FirstOrDefaultAsync();
    }

    public void CreateAsk(Ask ask)
    {
        Create(ask);
    }

    public void DeleteAsk(Ask ask)
    {
        Delete(ask);
    }
}
