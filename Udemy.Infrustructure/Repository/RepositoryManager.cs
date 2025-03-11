using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Infrastructure.Repository.EntityRepos;

namespace Udemy.Infrastructure.Repository;
public class RepositoryManager : IRepositoryManager
{
    private readonly ApplicationDbContext applicationDbContext;
    private readonly Lazy<IStudentRepository> studentRepository;
    private readonly Lazy<ICoursesRepository> coursesRepo;
    private readonly Lazy<ICourseRequirementRepo> courseRequirementRepo;
    private readonly Lazy<ISocialMediaRepository> socialMediaRepository;
    private readonly Lazy<IInstructorRepo> instructorRepo;
    private readonly Lazy<IEnrollmentRepository> enrollmentRepo;


    private readonly Lazy<IAskRepository> askRepository;
    private readonly Lazy<IAnswerRepository> answerRepository;
    private readonly Lazy<ICartRepository> cartRepository;
    private readonly Lazy<IUserRepository> userRepository;

    public RepositoryManager(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
    {
        this.applicationDbContext = applicationDbContext;
        studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(applicationDbContext));
        coursesRepo = new Lazy<ICoursesRepository>(() => new CoursesRepository(applicationDbContext));
        courseRequirementRepo = new Lazy<ICourseRequirementRepo>(() => new CourseRequirementRepo(applicationDbContext));
        socialMediaRepository = new Lazy<ISocialMediaRepository>(() => new SocialMediaRepository(applicationDbContext));
        instructorRepo = new Lazy<IInstructorRepo>(() => new InstructorRepo(applicationDbContext));
        enrollmentRepo = new Lazy<IEnrollmentRepository>(() => new EnrollmentRepository(applicationDbContext));

        askRepository = new Lazy<IAskRepository>(() => new AskRepository(applicationDbContext));
        answerRepository = new Lazy<IAnswerRepository>(() => new AnswerRepository(applicationDbContext));
        cartRepository = new Lazy<ICartRepository>(() => new CartRepository(applicationDbContext));
        userRepository = new Lazy<IUserRepository>(() => new UserRepository(applicationDbContext,userManager));
        studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(applicationDbContext));
    }

    

    public ICoursesRepository Courses => coursesRepo.Value;
    public ICourseRequirementRepo CourseRequirements => courseRequirementRepo.Value;
    public ISocialMediaRepository SocialMedia => socialMediaRepository.Value;

    public IInstructorRepo Instructors => instructorRepo.Value;
    public IEnrollmentRepository Enrollments => enrollmentRepo.Value; 



    public IStudentRepository Student => studentRepository.Value;
    public IAskRepository Ask => askRepository.Value;
    public IAnswerRepository Answer => answerRepository.Value;
    public ICartRepository Cart => cartRepository.Value;
    public IUserRepository User => userRepository.Value;

    public async Task SaveAsync()
    {
        await applicationDbContext.SaveChangesAsync();
    }
}
