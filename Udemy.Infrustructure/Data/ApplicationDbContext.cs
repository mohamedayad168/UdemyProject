using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Infrustructure.Configuration;

namespace Udemy.Infrustructure.Data;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser , IdentityRole<int> , int>
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(CourseGoalsConfiguration).Assembly);
        base.OnModelCreating(builder);
    }
}
