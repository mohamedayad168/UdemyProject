using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Views;

namespace Udemy.Infrastructure.Configuration.ViewConfig
{
    internal class VSupDimQuizConfig : IEntityTypeConfiguration<VSupDimQuiz>
    {
        public void Configure(EntityTypeBuilder<VSupDimQuiz> builder)
        {
            builder.HasKey(e => new { e.CourseId, e.QuizId });
        }
    }
}
