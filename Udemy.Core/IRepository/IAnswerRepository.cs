using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;

namespace Udemy.Core.IRepository;
public interface IAnswerRepository
{
    void CreateAnswer(Answer answer);
    void DeleteAnswer(Answer answer);
    Task<IEnumerable<Answer?>> GetAllAnswerAsync(bool trackChanges , RequestParamter requestParamter);
    Task<Answer> GetAnswerByIdAsync(int id , bool trackChanges);
}
