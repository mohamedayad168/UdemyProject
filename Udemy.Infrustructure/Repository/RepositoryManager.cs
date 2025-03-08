using Udemy.Core.IRepository;
using Udemy.Infrastructure.Repository.EntityRepos;

namespace Udemy.Infrastructure.Repository;
public class RepositoryManager : IRepositoryManager
{
    private readonly ApplicationDbContext applicationDbContext;
    private readonly Lazy<IStudentRepository> studentRepository;
    private readonly Lazy<ICoursesRepo> coursesRepo;
    public RepositoryManager(ApplicationDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
        studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(applicationDbContext));
        coursesRepo = new Lazy<ICoursesRepo>(() => new CoursesRepo(applicationDbContext));
    }

    public IStudentRepository Student => studentRepository.Value;
    public ICoursesRepo Courses => coursesRepo.Value;
    public async Task SaveAsync()
    {
        await applicationDbContext.SaveChangesAsync();
    }
}
