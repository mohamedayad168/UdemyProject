using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;

namespace Udemy.Infrastructure.Configuration
{
    public class AskConfiguration : IEntityTypeConfiguration<Ask>
    {
        public void Configure(EntityTypeBuilder<Ask> modelBuilder)
        {
            modelBuilder.HasOne(a => a.User)
        .WithMany(user=>user.Asks)
        .HasForeignKey(a => a.UserId)
        .OnDelete(DeleteBehavior.ClientSetNull);  // Keep Cascade


            modelBuilder.HasOne(a => a.Course)
                .WithMany(c=> c.Asks)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
