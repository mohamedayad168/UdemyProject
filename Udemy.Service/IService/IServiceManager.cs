using AutoMapper;

namespace Udemy.Service.IService;
public interface IServiceManager
{
    IStudentService StudentService { get; }
    ICoursesService CoursesService { get; }
    //IMapper Mapper { get; }
    ICourseRequirementService CourseRequirementService { get; }
    IInstructorService InstructorService { get; }
    IEnrollmentService EnrollmentService { get; }
}
