using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

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
