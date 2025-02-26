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

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(CourseGoalsConfiguration).Assembly);
        base.OnModelCreating(builder);
    }
}