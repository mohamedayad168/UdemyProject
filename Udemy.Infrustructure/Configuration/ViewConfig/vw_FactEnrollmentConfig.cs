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
    internal class vw_FactEnrollmentConfig : IEntityTypeConfiguration<vw_FactEnrollment>
    {
        public void Configure(EntityTypeBuilder<vw_FactEnrollment> builder)
        {
            builder.HasKey(e => new { e.CourseId, e.StudentId });
        }
    }
}
