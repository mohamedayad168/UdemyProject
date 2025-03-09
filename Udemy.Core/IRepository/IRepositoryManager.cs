namespace Udemy.Core.IRepository;
public interface IRepositoryManager
{
    public IStudentRepository Student { get; }
    public ICoursesRepo Courses { get; }
    //public IRatingRepository Rating { get; }
    ICourseRequirementRepo CourseRequirements { get; }
    Task SaveAsync();
}
