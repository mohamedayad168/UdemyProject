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
    public class CourseOrderConfiguration : IEntityTypeConfiguration<CourseOrder>
    {
        public void Configure(EntityTypeBuilder<CourseOrder> builder)
        {
            builder.HasKey(x => new { x.OrderId, x.CourseId });
            // Define Relationship: Order ↔ OrderCourse
            builder.HasOne(oc => oc.Order)
                   .WithMany(o => o.OrderCourses)
                   .HasForeignKey(oc => oc.OrderId)
                   .OnDelete(DeleteBehavior.NoAction); // Adjust as needed

            // Define Relationship: Course ↔ OrderCourse
            builder.HasOne(oc => oc.Course)
                   .WithMany(c => c.OrderCourses)
                   .HasForeignKey(oc => oc.CourseId)
                   .OnDelete(DeleteBehavior.Cascade); // Adjust as needed
        }
    }
}
