using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.AutoMapperConfigration;

public class InstructorMappingProfile : Profile
{
    public InstructorMappingProfile()
    {
        CreateMap<Instructor, InstructorRDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ReverseMap();
        CreateMap<Instructor, InstractorCDTO>().ReverseMap();
        CreateMap<Instructor, InstructorUTO>().ReverseMap();
    }
}
