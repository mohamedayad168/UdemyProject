using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;

namespace Udemy.Infrastructure.Repository;
public class AnswerRepository(ApplicationDbContext dbContext)
    : RepositoryBase<Answer>(dbContext), IAnswerRepository
{
    private readonly ApplicationDbContext dbContext = dbContext;

    public async Task<IEnumerable<Answer>> GetAllUserAskAnswersAsync(
        int userId ,
        int askId ,
        bool trackChanges ,
        RequestParamter requestParamter)
    {
        return await FindByCondition(x => 
                x.AskId == askId &&
                x.UserId == userId &&
                x.IsDeleted != true ,
                trackChanges
            )
            .Skip((requestParamter.PageNumber - 1) * requestParamter.PageSize)
            .Take(requestParamter.PageSize)
            .ToListAsync();
    }

    public async Task<Answer?> GetUserAskAnswerByIdAsync(
        int userId ,
        int askId ,
        int id , 
        bool trackChanges
    )
    {
        return await FindByCondition(c => 
                c.Id == id && 
                c.UserId == userId &&
                c.AskId == askId &&
                c.IsDeleted != true ,
                trackChanges
             )
            .FirstOrDefaultAsync();
    }

    public void CreateAnswer(Answer answer)
    {
        Create(answer);
    }

    public void DeleteAnswer(Answer answer)
    {
        answer.IsDeleted = true;
    }
}
