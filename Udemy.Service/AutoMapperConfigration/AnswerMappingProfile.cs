using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects.Answer;

namespace Udemy.Service.AutoMapperConfigration;
public class AnswerMappingProfile: Profile
{
    public AnswerMappingProfile()
    {
        CreateMap<Answer, AnswerDto>().ReverseMap();
        CreateMap<Answer, AnswerForCreationDto>().ReverseMap();
        CreateMap<Answer, AnswerForUpdatingDto>().ReverseMap();
    }
}
