using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.Core.Entities;

namespace Udemy.Infrustructure.Configuration;
public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public DbSet<Instructor> Instructors { get; set; }
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.UseTptMappingStrategy();
    }
}
