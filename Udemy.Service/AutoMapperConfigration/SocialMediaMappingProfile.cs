using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects;

namespace Udemy.Service.AutoMapperConfigration
{
    public class SocialMediaMappingProfile : Profile
    {
        public SocialMediaMappingProfile()
        {
            CreateMap<SocialMedia, SocialMediaDto>().ReverseMap();

        }
    }
}
