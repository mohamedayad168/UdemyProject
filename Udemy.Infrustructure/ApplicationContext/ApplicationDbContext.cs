using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Infrustructure.Configuration;

namespace Udemy.Infrustructure.ApplicationContext;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser , IdentityRole<int> , int>
{
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Ask> Asks { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseGoals> CourseGoals { get; set; }
    public DbSet<CourseRequirement> CourseRequirements { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Progress> Progresses { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<QuizQuestion> QuizQuestions { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<StudentGrade> StudentGrades { get; set; }
    public DbSet<Subcategory> Subcategories { get; set; }



    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(CourseGoalsConfiguration).Assembly);
        base.OnModelCreating(builder);
    }
}