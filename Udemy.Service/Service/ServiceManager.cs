using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Service.IService;

namespace Udemy.Service.Service;
public class ServiceManager : IServiceManager
{

    private readonly Lazy<ICoursesService> coursesService;
    private readonly Lazy<ICategoriesService> categoriesService;

    private readonly Lazy<ISocialMediaService> socialMediaService;

    private readonly Lazy<ICourseRequirementService> courseRequirementService;
    private readonly Lazy<IInstructorService> instructorService;
    private readonly Lazy<IEnrollmentService> enrollmentService;

    private readonly Lazy<IStudentService> studentService;
    private readonly Lazy<IUserService> userService;
    private readonly Lazy<IAnswerService> answerService;
    private readonly Lazy<IAskService> askService;

    public ServiceManager(
        IRepositoryManager repositoryManager, 
        IMapper mapper)
    {
        coursesService = new Lazy<ICoursesService>(() => new CoursesService(repositoryManager, mapper));
        categoriesService = new Lazy<ICategoriesService>(() => new CategoriesService(repositoryManager, mapper));

        socialMediaService = new Lazy<ISocialMediaService>(() => new SocialMediaService(repositoryManager));
        courseRequirementService = new Lazy<ICourseRequirementService>(() => new CourseRequirementService(repositoryManager, mapper));
        instructorService = new Lazy<IInstructorService>(() => new InstructorService(repositoryManager, mapper));
        enrollmentService = new Lazy<IEnrollmentService>(() => new EnrollmentService(repositoryManager, mapper)); 

        studentService = new Lazy<IStudentService>(() => new StudentService(repositoryManager, mapper));
        userService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper));
        answerService = new Lazy<IAnswerService>(() =>  new AnswerService(repositoryManager,mapper));
        askService = new Lazy<IAskService>(() =>  new AskService(repositoryManager,mapper));
    }

    public ICoursesService CoursesService => coursesService.Value;
    public ICategoriesService CategoriesService => categoriesService.Value;
    public ISocialMediaService SocialMediaService => socialMediaService.Value;
    public ICourseRequirementService CourseRequirementService => courseRequirementService.Value;
    public IInstructorService InstructorService => instructorService.Value;
    public IEnrollmentService EnrollmentService => enrollmentService.Value;

    public IStudentService StudentService => studentService.Value;
    public IUserService UserService => userService.Value;
    public IAnswerService AnswerService => answerService.Value;
    public IAskService AskService => askService.Value;

}
