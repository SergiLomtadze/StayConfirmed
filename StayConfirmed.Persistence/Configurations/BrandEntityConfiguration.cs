using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StayConfirmed.DataAccess.Entities;
using StayConfirmed.Shared.Extensions;

namespace StayConfirmed.Persistence.Configurations;

public class BrandEntityConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(200)
            .IsUnicode();
        builder.Property(b => b.Logo)
            .HasMaxLength(500)
            .IsUnicode();
        builder.Property(b => b.Emails)
            .HasJsonConversion();
    }
}
