using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects.Student;

namespace Udemy.Service.AutoMapperConfigration;
public class StudentMappingProfile: Profile
{
    public StudentMappingProfile()
    {
        CreateMap<Student, StudentDto>().ReverseMap();
        CreateMap<Student, StudentForCreationDto>().ReverseMap();
        CreateMap<Student, StudentForUpdatingDto>().ReverseMap();
    }
}
