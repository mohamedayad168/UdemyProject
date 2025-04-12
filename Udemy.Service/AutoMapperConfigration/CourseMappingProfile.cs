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
            // Mapping from Course to CourseRDTO
            CreateMap<Course, CourseRDTO>()
                .ForMember(dto => dto.InstructorName, e => e.MapFrom(src => src.Instructor.FirstName + " " + src.Instructor.LastName))
                .ForMember(dto => dto.CategoryId, e => e.MapFrom(src => src.SubCategory.CategoryId))
                  .ForMember(dto => dto.Price, opt => opt.MapFrom(src => src.Price)) 
                  .ForMember(dto => dto.Discount, opt => opt.MapFrom(src => src.Discount ?? 0m))
                .ReverseMap();

            // Mapping from Course to CourseCDTO and vice versa
            CreateMap<Course, CourseCDTO>().ReverseMap();

            // Mapping from Course to CourseUDTO and vice versa
            CreateMap<Course, CourseUDTO>().ReverseMap();
        }
    }
  

            
          

          
 


}
