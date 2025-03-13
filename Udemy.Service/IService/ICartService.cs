using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.IService;
public interface ICartService
{
    Task<CartDto> CreateStudentCartAsync(CartForCreationDto cartDto , int studentId);
    Task DeleteStudentCartAsync(int studentId);
    Task<IEnumerable<CartDto>> GetAllStudentsCartsAsync(bool trackChanges , RequestParamter requestParamter);
    Task<CartDto> GetStudentCartAsync(int studentId , bool trackChanges);
    Task UpdateStudentCartAsync(CartForUpdatingDto cartDto , int studentId);
}
