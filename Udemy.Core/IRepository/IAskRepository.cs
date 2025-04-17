using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;

namespace Udemy.Core.IRepository;
public interface IAskRepository:IRepositoryBase<Ask>
{
    void CreateAsk(Ask ask);
    void DeleteAsk(Ask ask);
    Task<IEnumerable<Ask>> GetAllUserCourseAsksAsync(int userId , int courseId , bool trackChanges , RequestParamter requestParamter);
    
    Task<Ask?> GetUserCourseAskByIdAsync(int userId , int courseId , int id , bool trackChanges);
    Task<bool> CheckIfAskExistsAsync(int id);
}
