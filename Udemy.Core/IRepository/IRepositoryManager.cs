namespace Udemy.Core.IRepository;
public interface IRepositoryManager
{
    public IStudentRepository Student { get; }
    public ICoursesRepository Courses { get; }
    //public IRatingRepository Rating { get; }
    ICourseRequirementRepo CourseRequirements { get; }
    ISocialMediaRepository SocialMedia { get; }
    IInstructorRepo Instructors { get; }

    IEnrollmentRepository Enrollments { get; }
    Task SaveAsync();
}
