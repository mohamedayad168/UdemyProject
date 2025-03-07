using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;

namespace Udemy.Infrastructure.Configuration
{
    public class CartCourseConfiguration : IEntityTypeConfiguration<CartCourse>
    {
        public void Configure(EntityTypeBuilder<CartCourse> builder)
        {
            builder.HasKey(x => new { x.CartId, x.CourseId });
            // Define Relationship: Cart ↔ CartCourse
            builder.HasOne(cc => cc.Cart)
                   .WithMany(c => c.CartCourses)
                   .HasForeignKey(cc => cc.CartId)
                   .OnDelete(DeleteBehavior.NoAction); // Adjust as needed

            // Define Relationship: Course ↔ CartCourse
            builder.HasOne(cc => cc.Course)
                   .WithMany(c => c.CartCourses)
                   .HasForeignKey(cc => cc.CourseId)
                   .OnDelete(DeleteBehavior.Cascade); // Adjust as needed

        }
    }
}
