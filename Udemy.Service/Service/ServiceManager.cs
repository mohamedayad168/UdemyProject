using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Service.IService;

namespace Udemy.Service.Service;
public class ServiceManager : IServiceManager
{

    private readonly Lazy<ICoursesService> coursesService;
    private readonly Lazy<ISocialMediaService> socialMediaService;

    private readonly Lazy<IStudentService> studentService;
    private readonly Lazy<IUserService> userService;


    public ServiceManager(
        IRepositoryManager repositoryManager, 
        IMapper mapper)
    {
        coursesService = new Lazy<ICoursesService>(() => new CoursesService(repositoryManager, mapper));
        socialMediaService = new Lazy<ISocialMediaService>(() => new SocialMediaService(repositoryManager));

        studentService = new Lazy<IStudentService>(() => new StudentService(repositoryManager, mapper));
        userService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper));
    }

    public ICoursesService CoursesService => coursesService.Value;
    public ISocialMediaService SocialMediaService => socialMediaService.Value;

    public IStudentService StudentService => studentService.Value;
    public IUserService UserService => userService.Value;

}
