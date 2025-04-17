using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Udemy.Service.AutoMapperConfigration;
public class AnswerMappingProfile : Profile
{
    public AnswerMappingProfile()
    {
        CreateMap<Answer, AnswerDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
            .ReverseMap();
        CreateMap<Answer, AnswerForCreationDto>().ReverseMap();
        CreateMap<Answer, AnswerForUpdatingDto>().ReverseMap();
    }
}
