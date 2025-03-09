namespace Udemy.Core.IRepository;
public interface IRepositoryManager
{
    public IStudentRepository Student { get; }
    public ICoursesRepository Courses { get; }
    //public IRatingRepository Rating { get; }
    ICourseRequirementRepo CourseRequirements { get; }
    Task SaveAsync();
}
