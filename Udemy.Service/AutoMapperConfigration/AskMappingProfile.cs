using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects.Ask;

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
