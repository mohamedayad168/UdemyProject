namespace Udemy.Core.IRepository;
public interface IRepositoryManager
{
    public IStudentRepository Student { get; }
    public ICoursesRepo Courses { get; }
    Task SaveAsync();
}
