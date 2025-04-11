using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects;

namespace Udemy.Service.AutoMapperConfigration
{
    public class SocialMediaMappingProfile : Profile
    {
        SocialMediaMappingProfile()
        {
            CreateMap<SocialMedia, SocialMediaDto>().ReverseMap();
            CreateMap<List<SocialMedia>, List<SocialMediaDto>>().ReverseMap();
        }
    }
}
