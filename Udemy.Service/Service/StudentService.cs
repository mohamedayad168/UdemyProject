using Udemy.Core.IRepository;
using Udemy.Service.DataTransferObjects;
using Udemy.Service.IService;

namespace Udemy.Service.Service;
public class StudentService : IStudentService
{
    private readonly IRepositoryManager repository;
    public StudentService(IRepositoryManager repository)
    {
        this.repository = repository;
    }

    public async Task<StudentDto> GetStudentByIdAsync(int id, bool trackChanges)
    {
        var student = await repository.Student.GetStudentAsync(id , trackChanges);
        var studentDto = new StudentDto()
        {
            FirstName = student.FirstName,
            LastName = student.LastName,
            Gender = student.Gender,
            CountryName = student.CountryName,
            City = student.City,
            State = student.State,
            Age = student.Age,
            Bio =  student.Bio,
            Title = student.Title,
        };

        return studentDto;
    }
    public async Task<IEnumerable<StudentDto>> GetAllStudentAsync(bool trackChanges)
    {
        var students = await repository.Student.GetAllStudentsAsync(trackChanges);
        var stdudentsDto = new List<StudentDto>();
        foreach(var student in students)
        {
            stdudentsDto.Add(new StudentDto
            {
                FirstName = student.FirstName ,
                LastName = student.LastName ,
                Gender = student.Gender ,
                CountryName = student.CountryName ,
                City = student.City ,
                State = student.State ,
                Age = student.Age ,
                Bio = student.Bio ,
                Title = student.Title ,
            });
        }

        return stdudentsDto;
    }
}
