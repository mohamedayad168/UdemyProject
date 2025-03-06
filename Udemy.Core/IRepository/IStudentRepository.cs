using Udemy.Core.Entities;

namespace Udemy.Core.IRepository;
public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges);
    Task<Student> GetStudentAsync(int id , bool trackChanges);
}
