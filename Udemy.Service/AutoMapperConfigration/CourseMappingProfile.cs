using AutoMapper;
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
            CreateMap<Course , CourseRDTO>()
                .ForMember(dto => dto.InstructorName , e => e.MapFrom(src => src.Instructor.FirstName + " " + src.Instructor.LastName))
                .ForMember(dto => dto.CategoryId , e => e.MapFrom(src => src.SubCategory.CategoryId))
                  .ForMember(dto => dto.Price , opt => opt.MapFrom(src => src.Price))
                  .ForMember(dto => dto.Discount , opt => opt.MapFrom(src => src.Discount ?? 0m))
                .ReverseMap();

            CreateMap<Course , CourseSearchDto>()
                .ForMember(dto => dto.InstructorName , e => e.MapFrom(src => src.Instructor.FirstName + " " + src.Instructor.LastName))
                .ForMember(dto => dto.Goals , opt => opt.MapFrom(src => src.CourseGoals.Select(e => e.Goal).ToList()))
                .ReverseMap();


            // Mapping from Course to CourseCDTO and vice versa
            CreateMap<CourseCDTO , Course>()
           .ForMember(dest => dest.ImageUrl , opt => opt.Ignore())
           .ForMember(dest => dest.VideoUrl , opt => opt.Ignore());


            // Mapping from Course to CourseUDTO and vice versa
            CreateMap<CourseUDTO , Course>()
                .ForMember(dest => dest.ImageUrl , opt => opt.Ignore())
                .ForMember(dest => dest.VideoUrl , opt => opt.Ignore());
        }
    }










}
