using AutoMapper;

namespace Udemy.Service.IService;
public interface IServiceManager
{
    IStudentService StudentService { get; }
    ICoursesService CoursesService { get; }
    IMapper Mapper { get; }
}
