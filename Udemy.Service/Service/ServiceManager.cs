using AutoMapper;
using Udemy.Core.IRepository;
using Udemy.Service.AutoMapperConfigration;
using Udemy.Service.IService;

namespace Udemy.Service.Service;
public class ServiceManager : IServiceManager
{
    private readonly Lazy<IMapper> _mapper;

    private readonly Lazy<IStudentService> studentService;
    private readonly Lazy<ICoursesService> coursesService;


    public ServiceManager(IRepositoryManager repositoryManager,IMapper mapper)
    {
        _mapper = new Lazy<IMapper>(() => mapper);
        studentService = new Lazy<IStudentService>(() => new StudentService(repositoryManager));
        coursesService = new Lazy<ICoursesService>(() => new CoursesService(repositoryManager));
    }

    public IStudentService StudentService => studentService.Value;
    public ICoursesService CoursesService => coursesService.Value;
    public IMapper Mapper => _mapper.Value;

}
