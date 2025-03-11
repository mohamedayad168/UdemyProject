using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;

namespace Udemy.Core.IRepository;
public interface IStudentRepository
{
    Task CreateStudent(Student student);
    void DeleteStudent(Student student);
    Task<IEnumerable<Student?>> GetAllStudentsAsync(bool trackChanges , RequestParamter requestParamter);
    Task<Student?> GetStudentByIdAsync(int id , bool trackChanges);
}
