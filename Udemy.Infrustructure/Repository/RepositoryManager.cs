using Udemy.Core.IRepository;
using Udemy.Infrastructure.Repository.EntityRepos;

namespace Udemy.Infrastructure.Repository;
public class RepositoryManager : IRepositoryManager
{
    private readonly ApplicationDbContext applicationDbContext;
    private readonly Lazy<IStudentRepository> studentRepository;
    private readonly Lazy<ICoursesRepo> coursesRepo;
    private readonly Lazy<ICourseRequirementRepo> courseRequirementRepo;
    private readonly Lazy<ISocialMediaRepository> socialMediaRepository;

    public RepositoryManager(ApplicationDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
        studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(applicationDbContext));
        coursesRepo = new Lazy<ICoursesRepo>(() => new CoursesRepo(applicationDbContext));
        courseRequirementRepo = new Lazy<ICourseRequirementRepo>(() => new CourseRequirementRepo(applicationDbContext));
        socialMediaRepository = new Lazy<ISocialMediaRepository>(() => new SocialMediaRepository(applicationDbContext));
    }

    public IStudentRepository Student => studentRepository.Value;
    public ICoursesRepo Courses => coursesRepo.Value;
    public ICourseRequirementRepo CourseRequirements => courseRequirementRepo.Value;
    public ISocialMediaRepository SocialMedia => socialMediaRepository.Value;



    public async Task SaveAsync()
    {
        await applicationDbContext.SaveChangesAsync();
    }
}
