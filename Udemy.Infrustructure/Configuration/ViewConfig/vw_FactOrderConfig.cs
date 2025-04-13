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
    internal class vw_FactOrderConfig : IEntityTypeConfiguration<vw_FactOrder>
    {
        public void Configure(EntityTypeBuilder<vw_FactOrder> builder)
        {
            builder.HasKey(e => new { e.OrderId, e.StudentId });
        }
    }
}
