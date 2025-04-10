using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.IService;
public interface ICartService
{
    Task AddCourseToStudentCartAsync(int courseId , int studentId);
    Task DeleteCourseFromStudentCartAsync(int courseId , int studentId);
    Task<IEnumerable<CartDto>> GetAllStudentsCartsAsync(bool trackChanges , RequestParamter requestParamter);
    Task<CartDto> GetStudentCartAsync(int studentId , bool trackChanges);
}
