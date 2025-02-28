using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.Core.Entities;

namespace Udemy.Infrastructure.Configuration;
public class CourseRequirementConfiguration : IEntityTypeConfiguration<CourseRequirement>
{
    public void Configure(EntityTypeBuilder<CourseRequirement> builder)
    {
        builder.HasKey(x => new {x.Requirement , x.CourseId });
    }
}
