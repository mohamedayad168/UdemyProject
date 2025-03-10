using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;

namespace Udemy.Core.IRepository;
public interface IAskRepository
{
    void CreateAsk(Ask ask);
    void DeleteAsk(Ask ask);
    Task<IEnumerable<Ask?>> GetAllAsksAsync(bool trackChanges , RequestParamter requestParamter);
    Task<Ask> GetAskByIdAsync(int id , bool trackChanges);
}
