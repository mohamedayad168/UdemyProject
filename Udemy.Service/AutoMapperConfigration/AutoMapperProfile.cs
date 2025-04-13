using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;
using Udemy.Service.IService;

namespace Udemy.Service.AutoMapperConfigration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Course,CourseRDTO>().ReverseMap();
            CreateMap<Course,CourseCDTO>().ReverseMap();
            CreateMap<Course,CourseUDTO>().ReverseMap();
            
            CreateMap<Category,CategoryRDTO>().ReverseMap();
            CreateMap<Category,CategoryCDTO>().ReverseMap();
            CreateMap<Category,CategoryUDTO>().ReverseMap();


            CreateMap<CourseRequirement, CourseRequirementRDTO>().ReverseMap(); ;
            CreateMap<CourseRequirementCTO, CourseRequirement>();
            CreateMap<CourseRequirementUTO, CourseRequirement>();


            CreateMap<Lesson, LessonRDto>().ReverseMap(); 
            CreateMap<Lesson, LessonCDto>().ReverseMap(); 
            CreateMap<Lesson, LessonDto>().ReverseMap();
        }

    }
}
