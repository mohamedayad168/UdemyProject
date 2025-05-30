﻿using AutoMapper;
using Udemy.Core.Entities;
using Udemy.Service.DataTransferObjects.Create;
using Udemy.Service.DataTransferObjects.Read;
using Udemy.Service.DataTransferObjects.Update;

namespace Udemy.Service.AutoMapperConfigration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Course, CourseRDTO>().ReverseMap();
            CreateMap<Course, CourseCDTO>().ReverseMap();
            CreateMap<Course, CourseUDTO>().ReverseMap();

            CreateMap<Category, CategoryRDTO>().ReverseMap();
            CreateMap<Category, CategoryCDTO>().ReverseMap();
            CreateMap<Category, CategoryUDTO>().ReverseMap();


            CreateMap<CourseRequirement, CourseRequirementRDTO>().ReverseMap(); ;
            CreateMap<CourseRequirementCTO, CourseRequirement>();
            CreateMap<CourseRequirementUTO, CourseRequirement>();


            CreateMap<Lesson, LessonRDto>().ReverseMap();
            CreateMap<LessonCDto, Lesson>()

           .ForMember(dest => dest.VideoUrl, opt => opt.Ignore());
            CreateMap<Lesson, LessonCDto>();
            CreateMap<Lesson, LessonUDto>().ReverseMap();

            CreateMap<Section, SectionRDTO>().ReverseMap();
            CreateMap<Section, SectionCDTO>().ReverseMap();
            CreateMap<Section, SectionUDTO>().ReverseMap();

            CreateMap<Instructor, InstructorRDTO>().ReverseMap();
            CreateMap<Instructor, InstructorCDTO>().ReverseMap();
            CreateMap<Instructor, InstructorUTO>().ReverseMap();

        }

    }
}
