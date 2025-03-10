using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;

namespace Udemy.Infrastructure.Repository;
public class AnswerRepository(ApplicationDbContext dbContext) 
    : RepositoryBase<Answer>(dbContext), IAnswerRepository
{
    private readonly ApplicationDbContext dbContext1 = dbContext;

    public async Task<IEnumerable<Answer>> GetAllAnswerAsync(bool trackChanges , RequestParamter requestParamter)
    {
        return await FindAll(trackChanges)
            .Skip((requestParamter.PageNumber - 1) * requestParamter.PageSize)
            .Take(requestParamter.PageSize)
            .ToListAsync();
    }

    public async Task<Answer?> GetAnswerByIdAsync(int id , bool trackChanges)
    {
        return await FindByCondition(c => c.Id == id , trackChanges)
            .FirstOrDefaultAsync();
    }

    public void CreateAnswer(Answer answer)
    {
        Create(answer);
    }

    public void DeleteAnswer(Answer answer)
    {
        Delete(answer);
    }
}
