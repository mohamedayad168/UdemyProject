using Udemy.Core.IRepository;
using Udemy.Service.IService;

namespace Udemy.Service.Service;
public class ServiceManager : IServiceManager
{
    private readonly Lazy<IStudentService> studentService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        studentService = new Lazy<IStudentService>(() => new StudentService(repositoryManager));
    }

    public IStudentService StudentService => studentService.Value;
}
