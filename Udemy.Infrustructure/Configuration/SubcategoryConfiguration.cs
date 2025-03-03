using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.Core.Entities;

namespace Udemy.Infrastructure.Configuration;
public class SubcategoryConfiguration : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> builder)
    {
    }
}
