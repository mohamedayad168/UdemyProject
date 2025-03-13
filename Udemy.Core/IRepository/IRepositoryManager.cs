namespace Udemy.Core.IRepository;
public interface IRepositoryManager
{
    ICoursesRepository Courses { get; }
    ICategoriesRepository Categories { get; }
    //public IRatingRepository Rating { get; }
    ICourseRequirementRepo CourseRequirement { get; }

    ISocialMediaRepository SocialMedia { get; }
    IInstructorRepo Instructors { get; }

    IEnrollmentRepository Enrollments { get; }

    IStudentRepository Student { get; }
    IUserRepository User { get; }
    IAskRepository Ask { get; }
    IAnswerRepository Answer { get; }
    ICartRepository Cart { get; }

    Task SaveAsync();
}
