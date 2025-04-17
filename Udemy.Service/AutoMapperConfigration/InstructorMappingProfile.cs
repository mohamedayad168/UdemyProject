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
        //CreateMap<Instructor, Instructor>()
        //    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        CreateMap<Core.Entities.Instructor, InstructorRDTO>().ReverseMap();
        CreateMap<Instructor, InstructorRDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

        CreateMap<Core.Entities.Instructor, InstructorCDTO>().ReverseMap();
        CreateMap<Core.Entities.Instructor, InstructorUTO>().ReverseMap();

        

        CreateMap<Instructor, Instructor>();
    }
}
