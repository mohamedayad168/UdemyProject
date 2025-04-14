using Udemy.Core.Entities;
using Udemy.Core.ReadOptions;

namespace Udemy.Core.IRepository;
public interface IStudentRepository : IRepositoryBase<Student>
{
    Task CreateStudent(Student student);
    void DeleteStudent(Student student);
    Task<PaginatedRes<Student?>> GetAllStudentsAsync(bool trackChanges, PaginatedSearchReq paginatedReq);
    public Task<int> GetStudentCount(IQueryable<Student> query);
    Task<Student?> GetStudentByIdAsync(int id , bool trackChanges);
}
