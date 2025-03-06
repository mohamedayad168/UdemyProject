namespace Udemy.Core.IRepository;
public interface IRepositoryManager
{
    public IStudentRepository Student { get; }
    Task SaveAsync();
}
