using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects;

namespace Udemy.Service.AutoMapperConfigration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StudentDto, Student>()
                .ForMember(dest => dest.FirstName, opt => opt.Condition(src => !string.IsNullOrEmpty(src.FirstName)))
                 .ForMember(dest => dest.LastName, opt => opt.Condition(src => !string.IsNullOrEmpty(src.LastName)))
                 .ForMember(dest => dest.Email, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Email)))
                 .ForMember(dest => dest.Gender, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Gender)))
                 .ForMember(dest => dest.Bio, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Bio)))
                 .ForMember(dest => dest.Title, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Title)))
                 .ForMember(dest => dest.State, opt => opt.Condition(src => !string.IsNullOrEmpty(src.State)))
                 .ForMember(dest => dest.City, opt => opt.Condition(src => !string.IsNullOrEmpty(src.City)))
                 .ForMember(dest => dest.CountryName, opt => opt.Condition(src => !string.IsNullOrEmpty(src.CountryName)))
                 .ForMember(dest => dest.Age, opt => opt.Condition(src => src.Age.HasValue));
        }
    }
}
