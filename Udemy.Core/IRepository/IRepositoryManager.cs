namespace Udemy.Core.IRepository;
public interface IRepositoryManager
{
    public IStudentRepository Student { get; }
    public IRatingRepository Rating { get; }
    Task SaveAsync();
}
