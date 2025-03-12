using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.AutoMapperConfigration;
public class AskMappingProfile: Profile
{
    public AskMappingProfile()
    {
        CreateMap<Ask , AskDto>().ReverseMap();
        CreateMap<Ask , AskForCreationDto>().ReverseMap();
        CreateMap<Ask , AskForUpdatingDto>().ReverseMap();
    }
}
