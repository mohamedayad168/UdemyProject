using AutoMapper;

namespace Udemy.Service.IService;
public interface IServiceManager
{
    IStudentService StudentService { get; }
    ICoursesService CoursesService { get; }
    ICourseRequirementService CourseRequirementService { get; }
    IInstructorService InstructorService { get; }
    IEnrollmentService EnrollmentService { get; }
    IUserService UserService { get; }
    IAnswerService AnswerService { get; }
    IAskService AskService { get; }
}
