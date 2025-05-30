﻿using Microsoft.AspNetCore.Identity;
using Udemy.Core.Entities;
using Udemy.Core.IRepository;
using Udemy.Infrastructure.Repository.EntityRepos;
using System;
using Microsoft.Extensions.Logging;
using Udemy.Service.DataTransferObjects.Read;
using Stripe;

namespace Udemy.Infrastructure.Repository;
public class RepositoryManager : IRepositoryManager
{
    private readonly ApplicationDbContext applicationDbContext;
    private readonly Lazy<IStudentRepository> studentRepository;
    private readonly Lazy<ICoursesRepository> coursesRepo;
    private readonly Lazy<ICategoriesRepository> categoriesRepo;
    private readonly Lazy<ICourseRequirementRepo> courseRequirementRepo;
    private readonly Lazy<ISocialMediaRepository> socialMediaRepository;
    private readonly Lazy<IInstructorRepo> instructorRepo;
    private readonly Lazy<IEnrollmentRepository> enrollmentRepo;
    private readonly Lazy<IAskRepository> askRepository;
    private readonly Lazy<IAnswerRepository> answerRepository;
    private readonly Lazy<ICartRepository> cartRepository;
    private readonly Lazy<IUserRepository> userRepository;
    private readonly Lazy<ISubCategoriesRepository> subCategoriesRepository;
    private readonly Lazy<ICartCourseRepository> cartCourseRepository;
    private readonly Lazy<IlessonRepo> LessonRepo;
    private readonly Lazy<Isectionrepo> SectionRepo;
    private readonly Lazy<IQuizRepository> quizRepository;
    private readonly Lazy<IStudentGradeRepository> studentGradeRepository;


    public RepositoryManager(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
    {
        this.applicationDbContext = applicationDbContext;
        studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(applicationDbContext));
        coursesRepo = new Lazy<ICoursesRepository>(() => new CoursesRepository(applicationDbContext));
        categoriesRepo = new Lazy<ICategoriesRepository>(() => new CategoriesRepository(applicationDbContext));
        courseRequirementRepo = new Lazy<ICourseRequirementRepo>(() => new CourseRequirementRepo(applicationDbContext));
        socialMediaRepository = new Lazy<ISocialMediaRepository>(() => new SocialMediaRepository(applicationDbContext));
        instructorRepo = new Lazy<IInstructorRepo>(() => new InstructorRepo(applicationDbContext));
        enrollmentRepo = new Lazy<IEnrollmentRepository>(() => new EnrollmentRepository(applicationDbContext));
        askRepository = new Lazy<IAskRepository>(() => new AskRepository(applicationDbContext));
        answerRepository = new Lazy<IAnswerRepository>(() => new AnswerRepository(applicationDbContext));
        cartRepository = new Lazy<ICartRepository>(() => new CartRepository(applicationDbContext));
        userRepository = new Lazy<IUserRepository>(() => new UserRepository(applicationDbContext, userManager));
        subCategoriesRepository = new Lazy<ISubCategoriesRepository>(() => new SubCategoriesRepository(applicationDbContext));
        cartCourseRepository = new Lazy<ICartCourseRepository>(() => new CartCourseRepository(applicationDbContext));
        LessonRepo = new Lazy<IlessonRepo>(() => new LessonRepo(applicationDbContext));
     SectionRepo = new Lazy<Isectionrepo>(() => new SectionRepo (applicationDbContext));
        quizRepository = new Lazy<IQuizRepository>(() => new QuizRepository(applicationDbContext));
        studentGradeRepository=new Lazy<IStudentGradeRepository>(()=> new StudentGradeRepository(applicationDbContext));


    }

    public ICoursesRepository Courses => coursesRepo.Value;
    public ICategoriesRepository Categories => categoriesRepo.Value;
    public ICourseRequirementRepo CourseRequirement => courseRequirementRepo.Value;
    public ISocialMediaRepository SocialMedia => socialMediaRepository.Value;
    public IInstructorRepo Instructors => instructorRepo.Value;
    public IEnrollmentRepository Enrollments => enrollmentRepo.Value;
    public IStudentRepository Student => studentRepository.Value;
    public IAskRepository Ask => askRepository.Value;
    public IAnswerRepository Answer => answerRepository.Value;
    public ICartRepository Cart => cartRepository.Value;
    public ICartCourseRepository CartCourse => cartCourseRepository.Value;
    public IUserRepository User => userRepository.Value;

    public ISubCategoriesRepository SubCategories => subCategoriesRepository.Value;


    public IlessonRepo Lessons => LessonRepo.Value;

    public Isectionrepo Section => SectionRepo.Value;

    public IQuizRepository Quizzes => quizRepository.Value;

    public IStudentGradeRepository StudentGrades => studentGradeRepository.Value;



    public async Task SaveAsync()
    {
        await applicationDbContext.SaveChangesAsync();
    }
}
