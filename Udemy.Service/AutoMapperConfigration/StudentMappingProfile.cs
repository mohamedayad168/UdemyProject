using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

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
