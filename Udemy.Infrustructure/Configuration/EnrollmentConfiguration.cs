using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.Core.Entities;

namespace Udemy.Infrastructure.Configuration;
public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(x => new {x.StudentId , x.CourseId});
        builder.HasOne(x=> x.Student)
            .WithMany(x => x.Enrollments)
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        builder.HasOne(x => x.Course).WithMany(x => x.Enrollments).HasForeignKey(x => x.CourseId).OnDelete(DeleteBehavior.ClientSetNull);


        


    }
}
