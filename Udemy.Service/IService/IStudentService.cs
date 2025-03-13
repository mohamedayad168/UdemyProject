using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.IService;
public interface IStudentService
{
    Task<StudentDto> CreateStudentAsync(StudentForCreationDto studentDto);
    Task DeleteStudentAsync(int id);
    Task<IEnumerable<StudentDto>> GetAllStudentAsync(bool trackChanges , RequestParamter requestParamter);
    Task<StudentDto> GetStudentByIdAsync(int id , bool trackChanges);
    Task UpdateStudentAsync(int id , StudentForUpdatingDto studentDto);
}
