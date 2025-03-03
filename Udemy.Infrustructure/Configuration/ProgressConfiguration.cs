using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.Core.Entities;

namespace Udemy.Infrastructure.Configuration;
public class ProgressConfiguration : IEntityTypeConfiguration<Progress>
{
    public void Configure(EntityTypeBuilder<Progress> builder)
    {
       // builder.HasKey(x => new {x.StudentId , x.LessonId});


        builder
           .HasOne(sc => sc.Student)
           .WithMany(s => s.Progresses)
           .HasForeignKey(sc => sc.StudentId)
           .OnDelete(DeleteBehavior.NoAction); // Avoid cascade issue

        builder
           .HasOne(sc => sc.Lesson)
           .WithMany(s => s.Progresses)
           .HasForeignKey(sc => sc.LessonId)
           .OnDelete(DeleteBehavior.NoAction); // Avoid cascade issue
    }
}
