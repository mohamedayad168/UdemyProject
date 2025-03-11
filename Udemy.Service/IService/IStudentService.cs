using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects;
using Udemy.Service.DataTransferObjects.Student;

namespace Udemy.Service.IService;
public interface IStudentService
{
    Task<StudentDto> CreateStudentAsync(StudentForCreationDto studentDto);
    Task DeleteStudentAsync(int id);
    Task<IEnumerable<StudentDto>> GetAllStudentAsync(bool trackChanges , RequestParamter requestParamter);
    Task<StudentDto> GetStudentByIdAsync(int id , bool trackChanges);
    Task UpdateStudentAsync(int id , StudentForUpdatingDto studentDto);
}
