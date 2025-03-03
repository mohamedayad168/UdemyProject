using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Udemy.Core.Entities;

namespace Udemy.Infrastructure.Configuration;
public class StudentGradeConfiguration : IEntityTypeConfiguration<StudentGrade>
{
    public void Configure(EntityTypeBuilder<StudentGrade> builder)
    {
        builder.HasKey(x => new {x.StudentId , x.QuizId});

        builder
           .HasOne(sc => sc.Student)
           .WithMany(s => s.StudentGrades)
           .HasForeignKey(sc => sc.StudentId)
           .OnDelete(DeleteBehavior.NoAction); // Avoid cascade issue

        builder
           .HasOne(sc => sc.Quiz)
           .WithMany(s => s.StudentGrades)
           .HasForeignKey(sc => sc.QuizId)
           .OnDelete(DeleteBehavior.NoAction); // Avoid cascade issue
      

    }
}
