﻿namespace Udemy.Service.IService;
public interface IServiceManager
{
    IStudentService StudentService { get; }
    ICoursesService CoursesService { get; }
    ICategoriesService CategoriesService { get; }
    //IMapper Mapper { get; }
    ICourseRequirementService CourseRequirementService { get; }
    IInstructorService InstructorService { get; }
    IEnrollmentService EnrollmentService { get; }
    IUserService UserService { get; }
    IAnswerService AnswerService { get; }
    IAskService AskService { get; }
    ICartService CartService { get; }
    ISubCategoriesService SubCategoriesService { get; }
    IPaymentService PaymentService { get; }
    ISocialMediaService SocialMediaService { get; }
    ILessonService LessonService { get; }
    ISectionService SectionService { get; }

    IQuizService QuizService { get; }



}
