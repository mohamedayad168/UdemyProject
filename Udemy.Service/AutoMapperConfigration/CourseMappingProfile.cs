using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.AutoMapperConfigration
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Course, CourseRDTO>().ReverseMap();
            CreateMap<Course, CourseRDTO>().ForMember(
                    dto => dto.InstructorName, e => e.MapFrom(
                        src => src.Instructor.FirstName + " " + src.Instructor.LastName
                    )
                ); 
            CreateMap<Course, CourseRDTO>().ForMember(
                    dto => dto.CategoryId, e => e.MapFrom(
                        src => src.SubCategory.CategoryId
                    )
                );

            CreateMap<Course, CourseCDTO>().ReverseMap();
            CreateMap<Course, CourseUDTO>().ReverseMap();
        }
    }
}
