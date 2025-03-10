using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Core.Exceptions;
using Udemy.Core.IRepository;
using Udemy.Core.ReadOptions;
using Udemy.Core.Utils;
using Udemy.Service.DataTransferObjects.Student;
using Udemy.Service.DataTransferObjects.User;
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
        bool isEmailExist = !string.IsNullOrEmpty(
            (await repository.User.GetUserByEmailAsync(studentDto.Email))?.Email
        );

        if (isEmailExist)
            throw new EmailExistBadRequest(studentDto.Email);

        bool isUsernameExist = !string.IsNullOrEmpty(
            (await repository.User.GetUserByUsernameAsync(studentDto.UserName))?.UserName
        );

        if (isUsernameExist)
            throw new UsernameExistBadRequest(studentDto.UserName);

        var studentEntity = mapper.Map<Student>(studentDto);

        // handle password validation (must contain at lead chararcter, ... etc)

        var result = await repository.User.CreateUserAsync(studentEntity , studentDto.Password);

        if (result.Succeeded)
        {
            await repository.User.AddRoleToUser(studentEntity , UserRole.Student);
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
