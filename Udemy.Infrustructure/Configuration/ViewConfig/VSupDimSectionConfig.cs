using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;
using Udemy.Core.Views;

namespace Udemy.Infrastructure.Configuration.ViewConfig
{
    public class VSupDimSectionConfig : IEntityTypeConfiguration<VSupDimSection>
    {
        public void Configure(EntityTypeBuilder<VSupDimSection> builder)
        {
            builder.HasKey(e => new { e.CourseId, e.SectionId });
        }
    }
}
