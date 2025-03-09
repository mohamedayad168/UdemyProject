﻿using Udemy.Core.IRepository;
using Udemy.Infrastructure.Repository.EntityRepos;

namespace Udemy.Infrastructure.Repository;
public class RepositoryManager : IRepositoryManager
{
    private readonly ApplicationDbContext applicationDbContext;
    private readonly Lazy<IStudentRepository> studentRepository;
    private readonly Lazy<ICoursesRepository> coursesRepo;
    private readonly Lazy<ICourseRequirementRepo> courseRequirementRepo;

    public RepositoryManager(ApplicationDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
        studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(applicationDbContext));
        coursesRepo = new Lazy<ICoursesRepository>(() => new CoursesRepository(applicationDbContext));
        courseRequirementRepo = new Lazy<ICourseRequirementRepo>(() => new CourseRequirementRepo(applicationDbContext));
    }

    public IStudentRepository Student => studentRepository.Value;
    public ICoursesRepository Courses => coursesRepo.Value;
    public ICourseRequirementRepo CourseRequirements => courseRequirementRepo.Value;

    public async Task SaveAsync()
    {
        await applicationDbContext.SaveChangesAsync();
    }
}
