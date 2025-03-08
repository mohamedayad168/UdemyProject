using Udemy.Core.ReadOptions;
using Udemy.Service.DataTransferObjects;

namespace Udemy.Service.IService;
public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetAllStudentAsync(bool trackChanges, RequestParamter requestParamter);
    Task<StudentDto> GetStudentByIdAsync(int id, bool trackChanges);

}
