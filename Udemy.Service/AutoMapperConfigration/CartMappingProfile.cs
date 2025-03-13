using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.AutoMapperConfigration;
public class CartMappingProfile : Profile
{
    public CartMappingProfile()
    {
        CreateMap<Cart , CartDto>()
            .ForMember(
                dest => dest.StudentUsername ,
                opt => opt.MapFrom(
                    src => src.Student.UserName ?? ""
                )
            )
            .ForMember(
                dest => dest.StudentId,
                opt => opt.MapFrom(
                    src => src.Student.Id
                )
            )
            .ForMember(
                dest => dest.Courses ,
                opt => opt.MapFrom(
                    src => src.CartCourses.Select(cc => cc.Course) 
                )
            )
            .ReverseMap();

        CreateMap<CartForCreationDto , Cart>()
            .ForMember(
                dest => dest.CartCourses , 
                opt => opt.MapFrom(
                    src => src.CourseIds.Select(
                        courseId => new CartCourse { CourseId = courseId }
                    )
                )
            )
            .AfterMap((src , dest) =>
            {
                foreach (var cartCourse in dest.CartCourses)
                {
                    cartCourse.CartId = dest.Id;
                }
            });

    }
}
