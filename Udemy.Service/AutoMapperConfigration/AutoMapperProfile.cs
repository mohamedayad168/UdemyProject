using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects;

namespace Udemy.Service.AutoMapperConfigration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StudentDto, Student>();

        }
    }
}
