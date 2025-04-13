using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.AutoMapperConfigration;

public class EnrollmentMappingProfile : Profile
{
    public EnrollmentMappingProfile()
    {
        CreateMap<Enrollment, EnrollmentCDTO>().ReverseMap();
        CreateMap<Enrollment, EnrollmentRDTO>().ReverseMap();
        CreateMap<Enrollment, EnrollmentUDTO>().ReverseMap();
    }
    
}
