﻿using AutoMapper;
using Udemy.Core.IRepository;
using Udemy.Service.IService;

namespace Udemy.Service.Service;
public class ServiceManager : IServiceManager
{

    private readonly Lazy<IStudentService> studentService;
    private readonly Lazy<ICoursesService> coursesService;
    private readonly Lazy<ISocialMediaService> socialMediaService;

    private readonly Lazy<ICourseRequirementService> courseRequirementService;
    private readonly Lazy<IInstructorService> instructorService;
    private readonly Lazy<IEnrollmentService> enrollmentService;
    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
    {

        studentService = new Lazy<IStudentService>(() => new StudentService(repositoryManager));
        coursesService = new Lazy<ICoursesService>(() => new CoursesService(repositoryManager, mapper));
        socialMediaService = new Lazy<ISocialMediaService>(() => new SocialMediaService(repositoryManager));
        courseRequirementService = new Lazy<ICourseRequirementService>(() => new CourseRequirementService(repositoryManager, mapper));
        instructorService = new Lazy<IInstructorService>(() => new InstructorService(repositoryManager, mapper));
        enrollmentService = new Lazy<IEnrollmentService>(() => new EnrollmentService(repositoryManager, mapper)); 
    }

    public IStudentService StudentService => studentService.Value;
    public ICoursesService CoursesService => coursesService.Value;
    public ISocialMediaService SocialMediaService => socialMediaService.Value;
    public ICourseRequirementService CourseRequirementService => courseRequirementService.Value;
    public IInstructorService InstructorService => instructorService.Value;
    public IEnrollmentService EnrollmentService => enrollmentService.Value;

}
