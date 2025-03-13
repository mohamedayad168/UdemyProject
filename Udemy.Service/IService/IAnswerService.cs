using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.IService;
public interface IAnswerService
{
    Task<AnswerDto> CreateUserAskAnswerAsync(AnswerForCreationDto answerDto , int courseId , int userId , int askId);
    Task DeleteUserAskAnswerAsync(int courseId , int userId , int askId , int answerId);
    Task<IEnumerable<AnswerDto>> GetAllUserAskAnswersAsync(int userId , int askId , int courseId , bool trackChanges , RequestParamter requestParamter);
    Task<AnswerDto> GetUserAskAnswerByIdAsync(int userId , int askId , int courseId , int answerId);
    Task UpdateUserAskAnswerAsync(AnswerForUpdatingDto answerDto , int courseId , int userId , int askId , int answerId);
}
