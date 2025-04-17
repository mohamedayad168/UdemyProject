using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.IService;
public interface IAskService
{
    Task<IEnumerable<AskRDTO>> GetAllUserCourseAsksAsync(int userId , int courseId , bool trackChanges , RequestParamter requestParamter);

    Task<IEnumerable<AskRDTO>> GetAsksByCourseIdAsync(int courseId ,RequestParamter requestParamter , bool trackChanges);

    Task<AskDto?> GetUserCourseAskByIdAsync(int id , int userId , int courseId , bool trackChanges);
    Task<AskDto> CreateUserCourseAskAsync(AskForCreationDto askDto , int courseId , int userId);
    Task DeleteUserCourseAskAsync(int courseId , int userId , int askId);
    Task UpdateUserCourseAskAsync(AskForUpdatingDto askDto , int courseId , int userId , int askId);
}
