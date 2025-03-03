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
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasOne(a => a.User)
                .WithMany(user => user.Answers)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);  // Keep Cascade

            builder.HasOne(a => a.Ask)
                .WithMany(ask => ask.Answers)
                .HasForeignKey(a => a.AskId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
