using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;

namespace Udemy.Core.IRepository;
public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges, RequestParamter requestParamter);
    Task<Student> GetStudentAsync(int id, bool trackChanges);
    //Task<IEnumberable<Student>> GetStudentsPage(bool trackChanges,int pageNumber);
    Task Create(Student student);
    void Update(Student student);
    void Delete(Student student);
}
