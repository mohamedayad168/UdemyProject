using Udemy.Core.IRepository;

namespace Udemy.Infrastructure.Repository;
public class RepositoryManager : IRepositoryManager
{
    private readonly ApplicationDbContext applicationDbContext;
    private readonly Lazy<IStudentRepository> studentRepository;
    public RepositoryManager(ApplicationDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
        studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(applicationDbContext));
    }

    public IStudentRepository Student => studentRepository.Value;
    public async Task SaveAsync()
    {
        await applicationDbContext.SaveChangesAsync();
    }
}
