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
    internal class vw_FactCartConfig : IEntityTypeConfiguration<vw_FactCart>
    {
        public void Configure(EntityTypeBuilder<vw_FactCart> builder)
        {
            builder.HasKey(e => new { e.CourseId, e.StudentId, e.CartId });
        }
    }
}
