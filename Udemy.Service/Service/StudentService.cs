using AutoMapper;
using System.Text;
using Udemy.Core.Entities;
using Udemy.Core.Exceptions;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;
using Udemy.Core.Utils;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Service.Service;
public class StudentService(
    IRepositoryManager repository ,
    IMapper mapper) : IStudentService
{
    private readonly IRepositoryManager repository = repository;
    private readonly IMapper mapper = mapper;



   


    public async Task<IEnumerable<StudentDto>> GetAllStudentAsync(bool trackChanges , RequestParamter requestParamter)
    {
        var students = await repository.Student.GetAllStudentsAsync(trackChanges , requestParamter);

        var studentsDto = mapper.Map<IEnumerable<StudentDto>>(students);

        return studentsDto;
    }

    public async Task<StudentDto> GetStudentByIdAsync(int id , bool trackChanges)
    {
        var student = await GetStudentAndCheckIfItExistsAsync(id, trackChanges);

        var studentDto = mapper.Map<StudentDto>(student);

        return studentDto;
    }

    public async Task<StudentDto> CreateStudentAsync(StudentForCreationDto studentDto)
    {
        var studentEntity = mapper.Map<Student>(studentDto);

        var result = await repository.User.CreateUserAsync(studentEntity , studentDto.Password);

        if (result.Succeeded)
        {
            await repository.User.AddRoleToUser(studentEntity , UserRole.Student);
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            foreach (var error in result.Errors)
                sb.Append(error.Description);

            throw new UserCreatingBadRequest(sb.ToString());
        }

        var studentToReturn = mapper.Map<StudentDto>(studentEntity);

        return studentToReturn;
    }

    public async Task UpdateStudentAsync(int id , StudentForUpdatingDto studentDto)
    {
        var studentEntity = await GetStudentAndCheckIfItExistsAsync(id, true);

        var studentWithSameUsername = await repository.User.GetUserByUsernameAsync(studentDto.UserName);

        if (studentWithSameUsername is not null && studentWithSameUsername.Id != studentEntity.Id)
        {
            throw new UsernameExistBadRequest(studentDto.UserName);
        }

        mapper.Map(studentDto , studentEntity);

        await repository.SaveAsync();
    }

    public async Task DeleteStudentAsync(int id)
    {
        var student = await GetStudentAndCheckIfItExistsAsync(id, true);

        repository.Student.DeleteStudent(student);

        await repository.SaveAsync();
    }

    private async Task<Student> GetStudentAndCheckIfItExistsAsync(int id, bool trackChanges)
    {
        var user = await repository.Student.GetStudentByIdAsync(id, trackChanges);

        if (user is null)
            throw new UserNotFoundException($"Student With Id: {id} Deosn't Exist");

        return user;
    }

}
