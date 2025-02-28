using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.Core.Entities;

namespace Udemy.Infrastructure.Configuration;
public class CourseGoalsConfiguration : IEntityTypeConfiguration<CourseGoals>
{
    public void Configure(EntityTypeBuilder<CourseGoals> builder)
    {
        builder.HasKey(k => new {k.CourseId , k.Goal});
    }
}
