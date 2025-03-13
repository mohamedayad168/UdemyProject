using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.AutoMapperConfigration;
public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<ApplicationUser , UserDto>().ReverseMap();
        CreateMap<ApplicationUser , UserForCreationDto>().ReverseMap();
        CreateMap<ApplicationUser , UserForUpdatingDto>().ReverseMap();
    }
}
