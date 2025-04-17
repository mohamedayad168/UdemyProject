using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;

namespace Udemy.Core.IRepository;
public interface IAnswerRepository:IRepositoryBase<Answer>          
{
    void CreateAnswer(Answer answer);
    void DeleteAnswer(Answer answer);
    Task<IEnumerable<Answer>> GetAllUserAskAnswersAsync(int userId , int askId , bool trackChanges , RequestParamter requestParamter);
    Task<Answer?> GetUserAskAnswerByIdAsync(int userId , int askId , int id , bool trackChanges);
}
